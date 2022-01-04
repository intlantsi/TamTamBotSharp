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
    /// Message statistics
    /// </summary>
    public class MessageStat
    {
        #region Fields
        //private readonly int views;
        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageStat()
        {

        }

        public MessageStat(int views)
        {
            this.Views = views;
        }
        #endregion

        #region Properties
        [JsonPropertyName("views")]
        public int Views { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageStat)) return false;

            MessageStat ms = (MessageStat) obj;
            return Object.Equals(this.Views, ms.Views);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Views != null ? Views.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageStat{"
                    + " views='" + Views + '\''
                    + '}';
        }
        #endregion
    }
}