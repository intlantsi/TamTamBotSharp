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
    /// After pressing this type of button client sends new 
    /// message with attachment of current user geo location
    /// </summary>
    public class RequestGeoLocationButton : Button
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public RequestGeoLocationButton():base()
        {

        }

        public RequestGeoLocationButton(string text) : base(text)
        {
            
        }
        #endregion

        #region Properties
        /// <summary>
        /// If *true*, sends location without asking user's confirmation
        /// </summary>
        [JsonPropertyName("quick")]
        public bool Quick { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is RequestGeoLocationButton)) return false;

            RequestGeoLocationButton rglBtn = (RequestGeoLocationButton) obj;
            return Object.Equals(this.Quick, rglBtn.Quick) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (Quick != null ? Quick.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "RequestGeoLocationButton{" + base.ToString()
                    + " quick='" + Quick + '\''
                    + '}';
        }
        #endregion
    }
}