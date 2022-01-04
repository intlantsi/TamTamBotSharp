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
    /// After pressing this type of button user follows the link it contains
    /// </summary>
    public class LinkButton : Button
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public LinkButton():base()
        {

        }

        public LinkButton(string url,string text) : base(text)
        {
            this.URL = url;
        }
        #endregion

        #region Properties
        /// <summary>
        /// URL
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; set; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is LinkButton)) return false;

            LinkButton linkBtn = (LinkButton) obj;
            return Object.Equals(this.URL, linkBtn.URL) &&
                    base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "LinkButton{" + base.ToString()
                    + " url='" + URL + '\''
                    + '}';
        }
        #endregion
    }
}
