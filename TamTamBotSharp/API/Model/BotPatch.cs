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
    /// BotPatch
    /// </summary>
    public class BotPatch
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public BotPatch()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Visible name of bot
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }
        /// <summary>
        /// Bot unique identifier. It can be any string 4-64 characters long containing any digit,
        /// letter or special symbols: "-"; or "_". It **must** starts with a letter
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; init; }
        /// <summary>
        /// Bot description up to 16k characters long
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }
        /// <summary>
        /// Commands supported by bot. Pass empty list if you want to remove commands
        /// </summary>
        [JsonPropertyName("commands")]
        public List<BotCommand> Commands { get; init; }
        /// <summary>
        /// Request to set bot photo
        /// </summary>
        [JsonPropertyName("photo")]
        public PhotoAttachmentRequestPayload Photo { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is BotPatch)) return false;

            BotPatch botPatch = (BotPatch) obj;
            return Object.Equals(this.Name, botPatch.Name) &&
                   Object.Equals(this.UserName, botPatch.UserName) &&
                   Object.Equals(this.Description, botPatch.Description) &&
                   Object.Equals(this.Commands, botPatch.Commands) &&
                   Object.Equals(this.Photo, botPatch.Photo);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Name != null ? Name.GetHashCode() : 0);
            result = 31 * result + (UserName != null ? UserName.GetHashCode() : 0);
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            result = 31 * result + (Commands != null ? Commands.GetHashCode() : 0);
            result = 31 * result + (Photo != null ? Photo.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "BotPatch{"
                    + " name='" + Name + '\''
                    + " username='" + UserName + '\''
                    + " description='" + Description + '\''
                    + " commands='" + Commands + '\''
                    + " photo='" + Photo + '\''
                    + '}';
        }
        #endregion
    }
}