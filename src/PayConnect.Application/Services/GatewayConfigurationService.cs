using AutoMapper;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Input;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Output;
using PayConnect.Application.Interfaces;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Exceptions;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Application.Services;

public class GatewayConfigurationService(IUnitOfWork unitOfWork, IMapper mapper) : IGatewayConfigurationService
{
    public async Task<CreateGatewayConfigurationOutModel> CreateAsync(CreateGatewayConfigurationInModel model,
        CancellationToken cancellationToken)
    {
        var configurations = (await unitOfWork.GatewayConfigurationRepository.FindAsync(x =>
            x.MerchantId == model.MerchantId && x.PaymentGatewayId == model.PaymentGatewayId)).ToList();

        
        var newConfigurations = new List<GatewayConfiguration>();
        
        foreach (var configuration in model.Configurations)
        {
            var exists = configurations.Any(x => x.Key.Equals(configuration.Key));
            if (exists) throw new DomainException($"Configuration with key {configuration.Key} already exists");
            
            newConfigurations.Add(GatewayConfiguration.Create(model.MerchantId, model.PaymentGatewayId, configuration.Key, configuration.Value, configuration.IsSensitive));
        }
        
        await unitOfWork.GatewayConfigurationRepository.AddRangeAsync(newConfigurations);
        await unitOfWork.CommitAsync();
        
        return mapper.Map<CreateGatewayConfigurationOutModel>(newConfigurations);
    }
}