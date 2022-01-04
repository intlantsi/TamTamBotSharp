using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class SimpleQueryResult
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public SimpleQueryResult()
        {

        }

        public SimpleQueryResult(bool success)
        {
            this.Success = success;
        }
        #endregion

        #region Properties
        [JsonPropertyName("success")]
        public bool Success { get; init; }
        [JsonPropertyName("message")]
        public string Message { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is SimpleQueryResult)) return false;

            SimpleQueryResult sqr = (SimpleQueryResult) obj;
            return Object.Equals(this.Success, sqr.Success) &&
                   Object.Equals(this.Message, sqr.Message);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Success != null ? Success.GetHashCode() : 0);
            result = 31 * result + (Message != null ? Message.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "SimpleQueryResult{"
                    + " success='" + Success + '\''
                    + " message='" + Message + '\''
                    + '}';
        }
        #endregion
    }
}
