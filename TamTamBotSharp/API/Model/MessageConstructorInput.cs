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
    /// Bot will get this input in case when user sends message to bot manually
    /// </summary>
    public class MessageConstructorInput: ConstructorInput
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageConstructorInput():base()
        {

        }

        public MessageConstructorInput(List<NewMessageBody> messages) : base()
        {
            this.Messages = messages;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Messages sent by user during construction process. Typically it is single element array but sometimes 
        /// it can contains multiple messages. Can be empty on initial request when user just opened constructor
        /// </summary>
        [JsonPropertyName("messages")]
        public List<NewMessageBody> Messages { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageConstructorInput)) return false;

            MessageConstructorInput mci = (MessageConstructorInput) obj;
            return Object.Equals(this.Messages, mci.Messages);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Messages != null ? Messages.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageConstructorInput{" + base.ToString()
                    + " messages='" + Messages + '\''
                    + '}';
        }
        #endregion
    }
}
