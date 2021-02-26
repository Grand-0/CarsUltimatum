using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Options
{
    public class JWT_Options
    {
        public const string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        public const string ISSUER = "www.CarsUltimatum";
        public const string AUDIENCE = "MyDearUser";
        public const int LIFETIME = 45;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
