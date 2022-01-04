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
    /// Different actions to send to chat members
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SenderActionTypes
    {
        [EnumMember(Value = "typing_on")]
        TypingOn,
        [EnumMember(Value = "sending_photo")]
        SendingPhoto,
        [EnumMember(Value = "sending_video")]
        SendingVideo,
        [EnumMember(Value = "sending_audio")]
        SendingAudio,
        [EnumMember(Value = "sending_file")]
        SendingFile,
        [EnumMember(Value = "mark_seen")]
        MarkSeen
    }
}

