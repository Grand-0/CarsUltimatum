using AutoMapper;
using BusinessLogicLayer.Profiles;

namespace BusinessLogicLayer
{
    public static class ConfigMapper
    {
        public static void Init(IMapperConfigurationExpression config)
        {
            config.AddProfile<CarProfile>();
            config.AddProfile<CarClassProfile>();
            config.AddProfile<OrderProfile>();
            config.AddProfile<CustomerProfile>();
            config.AddProfile<CompanyProfile>();
            config.AddProfile<ImageProfile>();
        }
    }
}
