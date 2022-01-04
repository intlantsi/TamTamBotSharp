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
    /// List of all updates in chats your bot participated in
    /// </summary>
    public class UpdateList
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public UpdateList()
        {

        }

        public UpdateList(List<Update> updates, long marker) 
        { 
            this.Updates = updates;
            this.Marker = marker;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Page of updates
        /// </summary>
        [JsonPropertyName("updates")]
        public List<Update> Updates { get; init; }
        /// <summary>
        /// Pointer to the next data page
        /// </summary>
        [JsonPropertyName("marker")]
        public long Marker { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UpdateList)) return false;

            UpdateList updList = (UpdateList) obj;
            return Object.Equals(this.Updates, updList.Updates) &&
                   Object.Equals(this.Marker, updList.Marker);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Updates != null ? Updates.GetHashCode() : 0);
            result = 31 * result + (Marker != null ? Marker.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UpdateList{"
                    + " updates='" + Updates + '\''
                    + " marker='" + Marker + '\''
                    + '}';
        }
        #endregion
    }
}