using System.Runtime.InteropServices;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PayConnect.Infrastructure.EntityFramework.Context;
using Xunit;

namespace PayConnect.Tests.Shared;

public class DatabaseFixture : BaseFixture, IAsyncLifetime
{
    private const string Image = "postgres:latest";
    private readonly string ContainerName;
    private const string Username = "test_user";
    private const string Password = "test_password";
    private const string Database = "e2e_tests";
    private const int HostPort = 25432;

    private readonly DockerClient _dockerClient;
    public string ConnectionString { get; private set; }

    public DatabaseFixture()
    {
        ContainerName = $"e2e_tests_db_{Guid.NewGuid():N}";
        
        _dockerClient = new DockerClientConfiguration(
                new Uri(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? "npipe://./pipe/docker_engine"
                    : "unix:///var/run/docker.sock"))
            .CreateClient();
    }

    public async Task InitializeAsync()
    {
        // Pull the image if not available

        try
        {
            await RemoveExistingContainerAsync(ContainerName);

            await _dockerClient.Images.CreateImageAsync(
                new ImagesCreateParameters { FromImage = Image },
                null,
                new Progress<JSONMessage>());

            // Create the container
            var container = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = Image,
                Name = ContainerName,
                Env = new List<string>
                {
                    $"POSTGRES_USER={Username}",
                    $"POSTGRES_PASSWORD={Password}",
                    $"POSTGRES_DB={Database}"
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "5432/tcp", new List<PortBinding> { new PortBinding { HostPort = HostPort.ToString() } } }
                    }
                }
            });

           ConnectionString = $"Host=localhost;Port={HostPort};Database={Database};Username={Username};Password={Password}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


        // Start the container
        await _dockerClient.Containers.StartContainerAsync(ContainerName, new ContainerStartParameters());


        // Wait for the database to be ready
        await WaitForDatabaseAsync();
    }

    private async Task WaitForDatabaseAsync()
    {
        var retry = 10;
        while (retry-- > 0)
        {
            try
            {
                using var connection = new NpgsqlConnection(ConnectionString);
                await connection.OpenAsync();
                return;
            }
            catch
            {
                await Task.Delay(1000); // Wait 1 second before retrying
            }
        }

        throw new Exception("Database did not become ready in time.");
    }

    private async Task RemoveExistingContainerAsync(string containerName)
    {
        try
        {
            var containers =
                await _dockerClient.Containers.ListContainersAsync(new ContainersListParameters { All = true });
            var existingContainer = containers.FirstOrDefault(c => c.Names.Contains($"/{containerName}"));

            if (existingContainer != null)
            {
                Console.WriteLine($"Removing existing container: {containerName}");
                await _dockerClient.Containers.StopContainerAsync(existingContainer.ID, new ContainerStopParameters());
                await _dockerClient.Containers.RemoveContainerAsync(existingContainer.ID,
                    new ContainerRemoveParameters { Force = true });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while removing existing container: {ex.Message}");
        }
    }
    
    public async Task<ApplicationDbContext> CreateE2EDatabaseAsync()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;

        var dbContext = new ApplicationDbContext(options);
        
        await dbContext.Database.MigrateAsync();

        return dbContext;
    }
    
    public async Task DisposeAsync()
    {
        try
        {
            Console.WriteLine("Stopping and removing container...");
            await _dockerClient.Containers.StopContainerAsync(ContainerName, new ContainerStopParameters());
            await _dockerClient.Containers.RemoveContainerAsync(ContainerName,
                new ContainerRemoveParameters { Force = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while disposing container: {ex.Message}");
        }
        finally
        {
            _dockerClient.Dispose();
        }
    }
}