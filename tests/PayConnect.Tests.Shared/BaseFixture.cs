using Bogus;

namespace PayConnect.Tests.Shared;

public abstract class BaseFixture
{
    public Faker Faker { get; } = new("pt_BR");
}