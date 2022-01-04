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
    //»ÏÂÈ ‚‚Ë‰Û ÓÚÒ˛‰‡ ‚˚ÍËÌÛÚÓ map Ë visit!!!
    /// <summary>
    /// Button
    /// </summary>
    [JsonConverter(typeof(ButtonConverter))]
    public class Button
    {
        #region Fields
        //private readonly string text;
        //private readonly ButtonTypes buttonType;
        #endregion

        #region Constructor
        [JsonConstructor]
        public Button()
        {

        }

        public Button(string text) 
        { 
            this.Text = text;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Visible text of button
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// Type of button
        /// </summary>
        [JsonPropertyName("button_type")]
        public ButtonTypes ButtonType { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Button)) return false;

            Button btn = (Button) obj;
            return Object.Equals(this.Text, btn.Text);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Text != null ? Text.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Button{"
                    + " text='" + Text + '\''
                    + '}';
        }
        #endregion
    }

    /// <summary>
    /// Generic schema representing message attachment JSON converter
    /// </summary>
    public class ButtonConverter : JsonConverter<Button>
    {
        public override Button Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ButtonTypes type = Enum.Parse<ButtonTypes>(reader.GetTokenValue("button_type"), true);
            var result = type switch
            {
                ButtonTypes.Callback => JsonSerializer.Deserialize<CallbackButton>(ref reader, options),
                ButtonTypes.Link => JsonSerializer.Deserialize<LinkButton>(ref reader, options),
                ButtonTypes.RequestGEOLocation => JsonSerializer.Deserialize<RequestGeoLocationButton>(ref reader, options),
                ButtonTypes.Request—ontact => JsonSerializer.Deserialize<RequestContactButton>(ref reader, options),
                ButtonTypes.Chat => JsonSerializer.Deserialize<ChatButton>(ref reader, options),
                _ => new Button("")
            };
            return result;
        }


        public override void Write(Utf8JsonWriter writer, Button btn, JsonSerializerOptions options)
        {
            switch (btn.ButtonType)
            {
                case ButtonTypes.Callback:
                    JsonSerializer.Serialize<CallbackButton>(writer, (CallbackButton)btn, options);
                    break;
                case ButtonTypes.Link:
                    JsonSerializer.Serialize<LinkButton>(writer, (LinkButton)btn, options);
                    break;
                case ButtonTypes.RequestGEOLocation:
                    JsonSerializer.Serialize<RequestGeoLocationButton>(writer, (RequestGeoLocationButton)btn, options);
                    break;
                case ButtonTypes.Request—ontact:
                    JsonSerializer.Serialize<RequestContactButton>(writer, (RequestContactButton)btn, options);
                    break;
                case ButtonTypes.Chat:
                    JsonSerializer.Serialize<ChatButton>(writer, (ChatButton)btn, options);
                    break;
                default:
                    break;
            }
        }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ButtonTypes
    {
        [EnumMember(Value = "callback")]
        Callback,
        [EnumMember(Value = "link")]
        Link,
        [EnumMember(Value = "request_geo_location")]
        RequestGEOLocation,
        [EnumMember(Value = "request_contact")]
        Request—ontact,
        [EnumMember(Value = "chat")]
        Chat
    }
}