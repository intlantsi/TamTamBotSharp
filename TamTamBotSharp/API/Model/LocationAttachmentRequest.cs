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
    /// Request to attach keyboard to message
    /// </summary>
    public class LocationAttachmentRequest : AttachmentRequest
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public LocationAttachmentRequest():base()
        {

        }

        public LocationAttachmentRequest(double latitude, double longitude) : base()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        #endregion

        #region Properties
        [JsonPropertyName("latitude")]
        public double Latitude { get; init; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is LocationAttachmentRequest)) return false;

            LocationAttachmentRequest locAttReq = (LocationAttachmentRequest)obj;
            return Object.Equals(this.Latitude, locAttReq.Latitude) &&
                   Object.Equals(this.Longitude, locAttReq.Longitude);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Latitude != null ? Latitude.GetHashCode() : 0);
            result = 31 * result + (Longitude != null ? Longitude.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "LocationAttachmentRequest{" + base.ToString()
                    + " latitude='" + Latitude + '\''
                    + " longitude='" + Longitude + '\''
                    + '}';
        }
        #endregion
    }
}