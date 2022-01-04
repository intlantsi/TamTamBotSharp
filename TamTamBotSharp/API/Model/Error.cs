using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class Error
    {
        #region Fields

        #endregion

        #region Constructors
        [JsonConstructor]
        public Error()
        {

        }

        public Error(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        #endregion

        #region Properties
        [JsonPropertyName("error")]
        public string ErrorType { get; init; }
        [JsonPropertyName("code")]
        public string Code { get; init; }
        [JsonPropertyName("message")]
        public string Message { get; init; }
        #endregion


        #region Objects override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            Error err = (Error) obj;
            return String.Equals(this.ErrorType, err.ErrorType) &&
                   String.Equals(this.Code, err.Code) &&
                   String.Equals(this.Message, err.Message);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ErrorType != null ? ErrorType.GetHashCode() : 0);
            result = 31 * result + (Code != null ? Code.GetHashCode() : 0);
            result = 31 * result + (Message != null ? Message.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Error{"
                + " error='" + ErrorType + '\''
                + " code='" + Code + '\''
                + " message='" + Message + '\''
                + '}';
        }
        #endregion
    }
}
