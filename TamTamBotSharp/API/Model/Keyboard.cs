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
    /// Keyboard is two-dimension array of buttons
    /// </summary>
    public class Keyboard
    {
        #region Fields
        
        #endregion

        #region Constructor
        public Keyboard(List<List<Button>> buttons)
        {
            this.Buttons = buttons;
        }
        #endregion

        #region Properties
        [JsonPropertyName("buttons")]
        public List<List<Button>> Buttons { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Keyboard)) return false;

            Keyboard kbrd = (Keyboard)obj;
            return Object.Equals(this.Buttons, kbrd.Buttons);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Buttons != null ? Buttons.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Keyboard{"
                    + " buttons='" + Buttons + '\''
                    + '}';
        }
        #endregion
    }
}