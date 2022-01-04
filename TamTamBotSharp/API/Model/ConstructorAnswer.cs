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
    /// Bot's answer on construction request
    /// </summary>
    public class ConstructorAnswer
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ConstructorAnswer()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Array of prepared messages. This messages
        /// will be sent as user taps on Send button
        /// </summary>
        [JsonPropertyName("messages")]
        public List<NewMessageBody> Messages { get; init; }
        /// <summary>
        /// If true, user can send any input manually. 
        /// Otherwise, only keyboard will be shown
        /// </summary>
        [JsonPropertyName("allow_user_input")]
        public bool AllowUserInput { get; init; }
        /// <summary>
        /// Hint to user. Will be shown on top of keyboard
        /// </summary>
        [JsonPropertyName("hint")]
        public string Hint { get; init; }
        /// <summary>
        /// In this property you can store any additional data up to 8KB.
        /// We send this data back to bot within the next construction request.
        /// It is handy to store here any state of construction session
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; init; }
        /// <summary>
        /// Keyboard to show to user in constructor mode
        /// </summary>
        [JsonPropertyName("keyboard")]
        public Keyboard Keyboard { get; init; }
        /// <summary>
        /// Text to show over the text field
        /// </summary>
        [JsonPropertyName("placeholder")]
        public string Placeholder { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ConstructorAnswer)) return false;

            ConstructorAnswer clbckAns = (ConstructorAnswer) obj;
            return Object.Equals(this.Messages, clbckAns.Messages) &&
                   Object.Equals(this.AllowUserInput, clbckAns.AllowUserInput) &&
                   Object.Equals(this.Hint, clbckAns.Hint) &&
                   Object.Equals(this.Data, clbckAns.Data) &&
                   Object.Equals(this.Keyboard, clbckAns.Keyboard) &&
                   Object.Equals(this.Placeholder, clbckAns.Placeholder);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Messages != null ? Messages.GetHashCode() : 0);
            result = 31 * result + (AllowUserInput != null ? AllowUserInput.GetHashCode() : 0);
            result = 31 * result + (Hint != null ? Hint.GetHashCode() : 0);
            result = 31 * result + (Data != null ? Data.GetHashCode() : 0);
            result = 31 * result + (Keyboard != null ? Keyboard.GetHashCode() : 0);
            result = 31 * result + (Placeholder != null ? Placeholder.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ConstructorAnswer{"
                    + " messages='" + Messages + '\''
                    + " allowUserInput='" + AllowUserInput + '\''
                    + " hint='" + Hint + '\''
                    + " data='" + Data + '\''
                    + " keyboard='" + Keyboard + '\''
                    + " placeholder='" + Placeholder + '\''
                    + '}';
        }
        #endregion
    }
}