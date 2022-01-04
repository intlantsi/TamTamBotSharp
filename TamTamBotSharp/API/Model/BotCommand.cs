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
    /// BotCommand
    /// </summary>
    public class BotCommand
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public BotCommand()
        {

        }

        public BotCommand(string name) 
        { 
            this.Name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Command name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        /// Optional command description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            BotCommand bc = (BotCommand) obj;
            return Object.Equals(this.Name, bc.Name) &&
                   Object.Equals(this.Description, bc.Description);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Name != null ? Name.GetHashCode() : 0);
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "BotCommand{"
                    + " name='" + Name + '\''
                    + " description='" + Description + '\''
                    + '}';
        }
        #endregion
    }
}