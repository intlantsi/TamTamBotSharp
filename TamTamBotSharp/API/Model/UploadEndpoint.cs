using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class UploadEndpoint
    {
        #region Fields
        
        #endregion

        #region Constructor
        public UploadEndpoint(string url)
        {
            this.URL = url;
        }
        #endregion

        #region Properties
        [JsonPropertyName("url")]
        public string URL { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UploadEndpoint)) return false;

            UploadEndpoint uplEnd = (UploadEndpoint) obj;
            return Object.Equals(this.URL, uplEnd.URL);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UploadEndpoint{"
                    + " url='" + URL + '\''
                    + '}';
        }
        #endregion
    }
}
