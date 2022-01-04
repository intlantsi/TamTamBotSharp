using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TamTamBotSharp.API.Extensions
{
    public static class JsonReaderExtensions
    {
        public static string GetTokenValue(this Utf8JsonReader reader, string tokenName)
        {
            Utf8JsonReader tokenRdr = reader;
            string tokenStr = "";
            while (tokenRdr.Read())
            {
                if (tokenRdr.TokenType == JsonTokenType.PropertyName
                    && tokenRdr.ValueTextEquals(tokenName))
                {
                    tokenRdr.Read();
                    tokenStr = tokenRdr.GetString();
                }
            }
            return tokenStr;
        }
    }
}
