using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace TamTamBot.API.Model
{
    //Имей ввиду отсюда выкинуто map и visit!!!
    /// <summary>
    /// It can be either message (text/attachments) or button callback
    /// </summary>
    [JsonConverter(typeof(ConstructorInputConverter))]
    public class ConstructorInput
    {
        #region Fields
        //private readonly InputTypes inputType;
        #endregion

        #region Constructor
        [JsonConstructor]
        public ConstructorInput()
        {
            
        }
        #endregion

        #region Properties
        [JsonPropertyName("input_type")]
        public InputTypes InputType { get; set; }
        #endregion

        #region Object override
        public override string ToString()
        {
            return "ConstructorInput{"
                    + '}';
        }
        #endregion
    }

    /// <summary>
    /// Generic schema representing message attachment JSON converter
    /// </summary>
    public class ConstructorInputConverter : JsonConverter<ConstructorInput>
    {
        public override ConstructorInput Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ConstructorInput cntInp = JsonSerializer.Deserialize<ConstructorInput>(ref reader, options);
            var result = cntInp.InputType switch
            {
                InputTypes.Callback => JsonSerializer.Deserialize<CallbackConstructorInput>(ref reader, options),
                InputTypes.Message => new ConstructorInput(),
                _ => new ConstructorInput()
            };
            return result;
        }


        public override void Write(Utf8JsonWriter writer, ConstructorInput cntInp, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize<ConstructorInput>(writer, cntInp, options);
        }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InputTypes
    {
        [EnumMember(Value = "callback")]
        Callback,
        [EnumMember(Value = "message")]
        Message
    }
}
