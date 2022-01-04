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
    /// This is information you will receive as soon as an image uploaded
    /// </summary>
    public class PhotoTokens
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public PhotoTokens()
        {

        }

        public PhotoTokens(Dictionary<string, PhotoToken> photos)
        {
            this.Photos = photos;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Photos
        /// </summary>
        [JsonPropertyName("photos")]
        public Dictionary<string, PhotoToken> Photos { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is PhotoTokens)) return false;

            PhotoTokens pts = (PhotoTokens)obj;
            return Object.Equals(this.Photos, pts.Photos);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Photos != null ? Photos.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "PhotoTokens{"
                    + " photos='" + Photos + '\''
                    + '}';
        }
        #endregion
    }
}
