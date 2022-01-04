using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    public class User
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructorAttribute]
        public User()
        {

        }

        public User(long userId, string name, string username, bool isBot)
        {
            this.UserId = userId;
            this.Name = name;
            this.UserName = username;
            this.IsBot = isBot;
        }
        #endregion

        #region Properties
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        [JsonPropertyName("name")]
        public string Name { get; init; }
        [JsonPropertyName("username")]
        public string UserName { get; init; }
        [JsonPropertyName("is_bot")]
        public bool IsBot { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is User)) return false;

            User user = (User)obj;
            return Object.Equals(this.UserId, user.UserId) &&
                   Object.Equals(this.Name, user.Name) &&
                   Object.Equals(this.UserName, user.UserName) &&
                   Object.Equals(this.IsBot, user.IsBot);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (UserId != null ? UserId.GetHashCode() : 0);
            result = 31 * result + (Name != null ? Name.GetHashCode() : 0);
            result = 31 * result + (UserName != null ? UserName.GetHashCode() : 0);
            result = 31 * result + (IsBot != null ? IsBot.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "User{"
                    + " userId='" + UserId + '\''
                    + " name='" + Name + '\''
                    + " username='" + UserName + '\''
                    + " isBot='" + IsBot + '\''
                    + '}';
        }
        #endregion
    }
}
