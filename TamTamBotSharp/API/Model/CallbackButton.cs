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
    /// After pressing this type of button client sends to server payload it contains
    /// </summary>
    public class CallbackButton : Button
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public CallbackButton():base()
        {

        }

        public CallbackButton(string payload, string text) : base(text)
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Button payload
        /// </summary>
        [JsonPropertyName("payload")]
        public string Payload { get; init; }
        /// <summary>
        /// Intent of button. Affects clients representation
        /// </summary>
        [JsonPropertyName("intent")]
        public IntentTypes IntentType { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            CallbackButton clbckBtn = (CallbackButton) obj;
            return Object.Equals(this.Payload, clbckBtn.Payload) &&
                   Object.Equals(this.IntentType, clbckBtn.IntentType) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (IntentType != null ? IntentType.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "CallbackButton{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + " intent='" + IntentType + '\''
                    + '}';
        }
        #endregion
    }
}