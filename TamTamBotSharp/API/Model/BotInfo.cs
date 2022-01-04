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
    /// BotInfo
    /// </summary>
    public class BotInfo:UserWithPhoto
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public BotInfo():base()
        {

        }

        public BotInfo(long userId, string name, string username, bool isBot):base(userId, name, username, isBot)
        { 
        
        }
        #endregion

        #region Properties
        /// <summary>
        /// Commands supported by bot
        /// </summary>
        [JsonPropertyName("commands")]
        public List<BotCommand> Commands { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            BotInfo bi = (BotInfo) obj;
            return Object.Equals(this.Commands, bi.Commands) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Commands != null ? Commands.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "BotInfo{" + base.ToString()
                    + " commands='" + Commands + '\''
                    + '}';
        }
        #endregion
    }
}
