using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EshopMVC.Models
{
    public class PaypalConfiguration
    {
        //variable store key
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = GetConfig();
            clientId = "Ab0AWm-7Xv_kMPSklTqvTrTK_LfGnLm5-2IY0RBA_0PHGzXF_UpB39JJKnSspzbrJDhwzg8_nE7yx8F1";
            clientSecret = "ELaXOu5G0AbRv9jh24e8X61IFPfRoT4ZpibQW6_TakVVEtRaVeyAnnpdc3GNQdG6rjojG7pdJYyToSFn";
        }

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        //access token
        private static string GetAccessToken()
        {
            string token = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            return token;
        }

        //call ApiContext invoke with token
        public static APIContext GetAPIContext()
        {
            var ApiContext = new APIContext(GetAccessToken());
            ApiContext.Config = GetConfig();
            return ApiContext;
        }
    }
}