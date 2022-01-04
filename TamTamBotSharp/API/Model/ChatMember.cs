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
    /// ChatMember
    /// </summary>
    public class ChatMember : UserWithPhoto
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatMember()
        {

        }

        public ChatMember(long lastAccessTime, bool isOwner, bool isAdmin, long joinTime,
            HashSet<ChatAdminPermissionTypes> permissions, long userId, string name,
            string username, bool isBot) : base(userId, name, username, isBot)
        {
            this.LastAccessTime = lastAccessTime;
            this.IsOwner = isOwner;
            this.IsAdmin = isAdmin;
            this.JoinTime = joinTime;
            this.Permissions = permissions;
        }
        #endregion

        #region Properties
        [JsonPropertyName("last_access_time")]
        public long LastAccessTime { get; init; }
        [JsonPropertyName("is_owner")]
        public bool IsOwner { get; init; }
        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; init; }
        [JsonPropertyName("join_time")]
        public long JoinTime { get; init; }
        /// <summary>
        /// Permissions in chat if member is admin, null otherwise
        /// </summary>
        [JsonPropertyName("permissions")]
        public HashSet<ChatAdminPermissionTypes> Permissions { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatMember)) return false;

            ChatMember cm = (ChatMember)obj;
            return Object.Equals(this.LastAccessTime, cm.LastAccessTime) &&
                   Object.Equals(this.IsOwner, cm.IsOwner) &&
                   Object.Equals(this.IsAdmin, cm.IsAdmin) &&
                   Object.Equals(this.JoinTime, cm.JoinTime) &&
                   Object.Equals(this.Permissions, cm.Permissions) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (LastAccessTime != null ? LastAccessTime.GetHashCode() : 0);
            result = 31 * result + (IsOwner != null ? IsOwner.GetHashCode() : 0);
            result = 31 * result + (IsAdmin != null ? IsAdmin.GetHashCode() : 0);
            result = 31 * result + (JoinTime != null ? JoinTime.GetHashCode() : 0);
            result = 31 * result + (Permissions != null ? Permissions.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ChatMember{" + base.ToString()
                    + " lastAccessTime='" + LastAccessTime + '\''
                    + " isOwner='" + IsOwner + '\''
                    + " isAdmin='" + IsAdmin + '\''
                    + " joinTime='" + JoinTime + '\''
                    + " permissions='" + Permissions + '\''
                    + '}';
        }
        #endregion
    }
}