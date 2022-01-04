using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Generic schema describing image object
    /// </summary>
    public class Image
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public Image()
        {

        }

        public Image(string url)
        {
            this.URL = url;
        }
        #endregion

        #region Properties
        /// <summary>
        /// URL of image
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Image)) return false;

            Image im = (Image) obj;
            return Object.Equals(this.URL, im.URL);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Image{"
                    + " url='" + URL + '\''
                    + '}';
        }
        #endregion
    }
}