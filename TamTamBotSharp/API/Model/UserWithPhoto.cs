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
    /// UserWithPhoto
    /// </summary>
    public class UserWithPhoto:User
    {
        #region Fields

        #endregion

        #region Constructor
        public UserWithPhoto():base()
        {

        }

        public UserWithPhoto(long userId,string name, string username, bool isBot):base(userId, name, username, isBot)
        { 
        
        }
        #endregion

        #region Properties
        /// <summary>
        /// User description. Can be "null"; if user did not fill it out
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }
        /// <summary>
        /// URL of avatar
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; init; }
        /// <summary>
        /// URL of avatar of a bigger size
        /// </summary>
        [JsonPropertyName("full_avatar_url")]
        public string FullAvatarUrl { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UserWithPhoto)) return false;

            UserWithPhoto uwp = (UserWithPhoto) obj;
            return Object.Equals(this.Description, uwp.Description) &&
                Object.Equals(this.AvatarUrl, uwp.AvatarUrl) &&
                Object.Equals(this.FullAvatarUrl, uwp.FullAvatarUrl) &&
                base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            result = 31 * result + (AvatarUrl != null ? AvatarUrl.GetHashCode() : 0);
            result = 31 * result + (FullAvatarUrl != null ? FullAvatarUrl.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UserWithPhoto{" + base.ToString()
                    + " description='" + Description + '\''
                    + " avatarUrl='" + AvatarUrl + '\''
                    + " fullAvatarUrl='" + FullAvatarUrl + '\''
                    + '}';
        }
        #endregion
    }
}
