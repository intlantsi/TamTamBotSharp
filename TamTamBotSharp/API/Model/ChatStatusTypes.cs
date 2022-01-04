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
    /// Chat status for current bot
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatStatusTypes
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "removed")]
        Removed,
        [EnumMember(Value = "left")]
        Left,
        [EnumMember(Value = "closed")]
        Closed,
        [EnumMember(Value = "suspended")]
        Suspended
    }
}

