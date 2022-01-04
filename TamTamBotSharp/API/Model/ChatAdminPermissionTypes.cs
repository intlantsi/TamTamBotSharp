using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Chat admin permissions
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatAdminPermissionTypes
    {
        [EnumMember(Value = "read_all_messages")]
        ReadAllMessages,
        [EnumMember(Value = "add_remove_members")]
        AddRemoveMembers,
        [EnumMember(Value = "add_admins")]
        AddAdmins,
        [EnumMember(Value = "change_chat_info")]
        ChangeChatInfo,
        [EnumMember(Value = "pin_message")]
        PinMessage,
        [EnumMember(Value = "write")]
        Write
    }
}

