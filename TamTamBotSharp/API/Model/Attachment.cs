using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using TamTamBotSharp.API.Extensions;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Generic schema representing message attachment
    /// </summary>
    [JsonConverter(typeof(AttachmentConverter))]
    public class Attachment
    {
        #region Fields
        private readonly AttachmentTypes attachmentType;
        #endregion

        #region Constructor
        public Attachment()
        {

        }
        #endregion

        #region Properties
        [JsonPropertyName("type")]
        public AttachmentTypes AttachmentType { get; set; }
        #endregion

        #region Object override
        public override string ToString()
        {
            return "Attachment{"
                    + '}';
        }
        #endregion
    }

    /// <summary>
    /// Generic schema representing message attachment JSON converter
    /// </summary>
    public class AttachmentConverter : JsonConverter<Attachment>
    {
        public override Attachment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            AttachmentTypes type = Enum.Parse<AttachmentTypes>(reader.GetTokenValue("type"),true);
            var result = type switch
            {
                AttachmentTypes.Image => JsonSerializer.Deserialize<PhotoAttachment>(ref reader, options),
                AttachmentTypes.Video => JsonSerializer.Deserialize<VideoAttachment>(ref reader, options),
                AttachmentTypes.Audio => JsonSerializer.Deserialize<AudioAttachment>(ref reader, options),
                AttachmentTypes.File => JsonSerializer.Deserialize<FileAttachment>(ref reader, options),
                AttachmentTypes.Sticker => JsonSerializer.Deserialize<StickerAttachment>(ref reader, options),
                AttachmentTypes.Contact => JsonSerializer.Deserialize<ContactAttachment>(ref reader, options),
                AttachmentTypes.InlineKeyboard => JsonSerializer.Deserialize<InlineKeyboardAttachment>(ref reader, options),
                AttachmentTypes.Share => JsonSerializer.Deserialize<ShareAttachment>(ref reader, options),
                AttachmentTypes.Location => JsonSerializer.Deserialize<LocationAttachment>(ref reader, options),
                _ => new Attachment()
            };
            return result;
        }


        public override void Write(Utf8JsonWriter writer, Attachment attach, JsonSerializerOptions options)
        {
            switch (attach.AttachmentType)
            {
                case AttachmentTypes.Image:
                    JsonSerializer.Serialize<PhotoAttachment>(writer, (PhotoAttachment)attach, options);
                    break;
                case AttachmentTypes.Video:
                    JsonSerializer.Serialize<VideoAttachment>(writer, (VideoAttachment)attach, options);
                    break;
                case AttachmentTypes.Audio:
                    JsonSerializer.Serialize<AudioAttachment>(writer, (AudioAttachment)attach, options);
                    break;
                case AttachmentTypes.File:
                    JsonSerializer.Serialize<FileAttachment>(writer, (FileAttachment)attach, options);
                    break;
                case AttachmentTypes.Sticker:
                    JsonSerializer.Serialize<StickerAttachment>(writer, (StickerAttachment)attach, options);
                    break;
                case AttachmentTypes.Contact:
                    JsonSerializer.Serialize<ContactAttachment>(writer, (ContactAttachment)attach, options);
                    break;
                case AttachmentTypes.Location:
                    JsonSerializer.Serialize<LocationAttachment>(writer, (LocationAttachment)attach, options);
                    break;
                case AttachmentTypes.Share:
                    JsonSerializer.Serialize<ShareAttachment>(writer, (ShareAttachment)attach, options);
                    break;
                default:
                    break;
            }
        }
    }

    public enum AttachmentTypes
    {
        Image,
        Video,
        Audio,
        File,
        Sticker,
        Contact,
        InlineKeyboard,
        Share,
        Location
    }
}
