using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class UploadedInfo
    {
        #region Fields
   
        #endregion

        #region Constructor
        [JsonConstructorAttribute]
        public UploadedInfo()
        {

        }

        public UploadedInfo(string token)
        {
            this.Token = token;
        }
        #endregion

        #region Properties
        [JsonPropertyName("token")]
        public string Token { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UploadedInfo)) return false;

            UploadedInfo uplInfo = (UploadedInfo) obj;
            return Object.Equals(this.Token, uplInfo.Token);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Token != null ? Token.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UploadedInfo{"
                    + " token='" + Token + '\''
                    + '}';
        }
        #endregion
    }
}
