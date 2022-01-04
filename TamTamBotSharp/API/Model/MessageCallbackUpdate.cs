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
    /// You will get this update as soon as user presses button
    /// </summary>
    public class MessageCallbackUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageCallbackUpdate():base()
        {

        }

        public MessageCallbackUpdate(Callback callback, Message message, long timestamp) : base(timestamp)
        {
            this.Callback = callback;
            this.Message = message;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Callback
        /// </summary>
        [JsonPropertyName("callback")]
        public Callback Callback { get; set; }
        /// <summary>
        /// Original message containing inline keyboard. Can be null in case 
        /// it had been deleted by the moment a bot got this update
        /// </summary>
        [JsonPropertyName("Message")]
        public Message Message { get; set; }
        /// <summary>
        /// Current user locale in IETF BCP 47 format
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageCallbackUpdate)) return false;

            MessageCallbackUpdate mcu = (MessageCallbackUpdate) obj;
            return Object.Equals(this.Callback, mcu.Callback) &&
                   Object.Equals(this.Message, mcu.Message) &&
                   Object.Equals(this.UserLocale, mcu.UserLocale) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (Callback != null ? Callback.GetHashCode() : 0);
            result = 31 * result + (Message != null ? Message.GetHashCode() : 0);
            result = 31 * result + (UserLocale != null ? UserLocale.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageCallbackUpdate{" + base.ToString()
                    + " callback='" + Callback + '\''
                    + " message='" + Message + '\''
                    + " userLocale='" + UserLocale + '\''
                    + '}';
        }
        #endregion
    }
}