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
    /// Bot will get this update when user sent to bot any message or pressed button during construction process
    /// </summary>
    public class MessageConstructionRequest:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageConstructionRequest():base()
        {

        }

        public MessageConstructionRequest(UserWithPhoto user, string sessionId, ConstructorInput input, long timestamp) : base(timestamp)
        {
            this.User = user;
            this.SessionId = sessionId;
            this.Input = input;
        }
        #endregion

        #region Properties
        /// <summary>
        /// User who initiated this request
        /// </summary>
        [JsonPropertyName("user")]
        public UserWithPhoto User { get; init; }
        /// <summary>
        /// Current user locale in IETF BCP 47 format
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; init; }
        /// <summary>
        /// Constructor session identifier
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; init; }
        /// <summary>
        ///  Data received from previous ConstructorAnswer
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
        /// <summary>
        /// User's input. It can be message (text/attachments) or simple buttons callback
        /// </summary>
        [JsonPropertyName("input")]
        public ConstructorInput Input { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            MessageConstructionRequest mcr = (MessageConstructionRequest) obj;
            return Object.Equals(this.User, mcr.User) &&
                   Object.Equals(this.UserLocale, mcr.UserLocale) &&
                   Object.Equals(this.SessionId, mcr.SessionId) &&
                   Object.Equals(this.Data, mcr.Data) &&
                   Object.Equals(this.Input, mcr.Input) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            result = 31 * result + (UserLocale != null ? UserLocale.GetHashCode() : 0);
            result = 31 * result + (SessionId != null ? SessionId.GetHashCode() : 0);
            result = 31 * result + (Data != null ? Data.GetHashCode() : 0);
            result = 31 * result + (Input != null ? Input.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageConstructionRequest{" + base.ToString()
                    + " user='" + User + '\''
                    + " userLocale='" + UserLocale + '\''
                    + " sessionId='" + SessionId + '\''
                    + " data='" + Data + '\''
                    + " input='" + Input + '\''
                    + '}';
        }
        #endregion
    }
}
