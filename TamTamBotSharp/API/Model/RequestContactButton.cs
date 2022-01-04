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
    /// After pressing this type of button client sends new message with attachment of current user contact
    /// </summary>
    public class RequestContactButton : Button
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public RequestContactButton():base()
        {

        }

        public RequestContactButton(string text) : base(text)
        {
            
        }
        #endregion

        #region Properties

        #endregion

        #region Object override
        public override string ToString()
        {
            return "RequestContactButton{" + base.ToString()
                    + '}';
        }
        #endregion
    }
}
