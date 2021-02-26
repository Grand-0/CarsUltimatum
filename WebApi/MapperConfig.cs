using AutoMapper;
using WebApi.Profiles;

namespace WebApi
{
    public static class MapperConfig
    {
        public static void Init(IMapperConfigurationExpression expression)
        {
            expression.AddProfile<CarsProfile>();
            expression.AddProfile<CarsClassProfile>();
            expression.AddProfile<CompaniesProfile>();
            expression.AddProfile<CustomersProfile>();
            expression.AddProfile<OrdersProfile>();
            expression.AddProfile<UserBaseProfile>();
        }
    }
}
