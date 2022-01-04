using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using TamTamBotSharp.API.Extensions;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Request to attach some data to message
    /// </summary>
    [JsonConverter(typeof(AttachmentRequestConverter))]
    public class AttachmentRequest
    {
        #region Fields
        
        #endregion

        #region Constructor
        public AttachmentRequest()
        {
            
        }
        #endregion

        #region Properties
        [JsonPropertyName("type")]
        public AttachmentRequestTypes AttachmentRequestType { get; init; }
        #endregion

        #region Object override
        public override string ToString()
        {
            return "AttachmentRequest{"
                   + '}';
        }
        #endregion
    }

    /// <summary>
    /// Generic schema representing message attachment JSON converter
    /// </summary>
    public class AttachmentRequestConverter : JsonConverter<AttachmentRequest>
    {
        public override AttachmentRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            AttachmentRequestTypes type = Enum.Parse<AttachmentRequestTypes>(reader.GetTokenValue("type"),true);
            var result = type switch
            {
                AttachmentRequestTypes.Image => JsonSerializer.Deserialize<PhotoAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Video => JsonSerializer.Deserialize<VideoAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Audio => JsonSerializer.Deserialize<AudioAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.File => JsonSerializer.Deserialize<FileAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Sticker => JsonSerializer.Deserialize<StickerAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Contact => JsonSerializer.Deserialize<ContactAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Location => JsonSerializer.Deserialize<LocationAttachmentRequest>(ref reader, options),
                AttachmentRequestTypes.Share => JsonSerializer.Deserialize<ShareAttachmentRequest>(ref reader, options),
                _ => new AttachmentRequest()
            };
            return result;
        }


        public override void Write(Utf8JsonWriter writer, AttachmentRequest upd, JsonSerializerOptions options)
        {
            switch (upd.AttachmentRequestType)
            {
                case AttachmentRequestTypes.Image:
                    JsonSerializer.Serialize<PhotoAttachmentRequest>(writer, (PhotoAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Video:
                    JsonSerializer.Serialize<VideoAttachmentRequest>(writer, (VideoAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Audio:
                    JsonSerializer.Serialize<AudioAttachmentRequest>(writer, (AudioAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.File:
                    JsonSerializer.Serialize<FileAttachmentRequest>(writer, (FileAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Sticker:
                    JsonSerializer.Serialize<StickerAttachmentRequest>(writer, (StickerAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Contact:
                    JsonSerializer.Serialize<ContactAttachmentRequest>(writer, (ContactAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Location:
                    JsonSerializer.Serialize<LocationAttachmentRequest>(writer, (LocationAttachmentRequest)upd, options);
                    break;
                case AttachmentRequestTypes.Share:
                    JsonSerializer.Serialize<ShareAttachmentRequest>(writer, (ShareAttachmentRequest)upd, options);
                    break;
                default:
                    break;
            }
        }

    }

    
    public enum AttachmentRequestTypes
    {
        Image,
        Video,
        Audio,
        File,
        Sticker,
        Contact,
        Location,
        Share
    }
}
