using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class ActionRequestBody
    {
        #region Fields

        #endregion

        #region Constructors
        [JsonConstructor]
        public ActionRequestBody()
        {

        }

        public ActionRequestBody(SenderActionTypes action)
        {
            this.Action = action;
        }
        #endregion


        #region Properties
        [JsonPropertyName("action")]
        public SenderActionTypes Action { get; init; }
        #endregion


        #region Object overrides
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ActionRequestBody)) return false;

            ActionRequestBody other = (ActionRequestBody)obj;
            return String.Equals(this.Action, other.Action);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Action != null ? Action.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ActionRequestBody{"
                   + " action='" + Action + '\''
                   + '}';
        }
        #endregion
    }
}
