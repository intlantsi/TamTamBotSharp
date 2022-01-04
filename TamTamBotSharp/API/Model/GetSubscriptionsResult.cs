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
    /// List of all WebHook subscriptions
    /// </summary>
    public class GetSubscriptionsResult
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public GetSubscriptionsResult()
        {

        }

        public GetSubscriptionsResult(List<Subscription> subscriptions)
        {
            this.Subscriptions = subscriptions;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Current subscriptions
        /// </summary>
        [JsonPropertyName("subscriptions")]
        public List<Subscription> Subscriptions { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is GetSubscriptionsResult)) return false;

            GetSubscriptionsResult gsr = (GetSubscriptionsResult)obj;
            return Object.Equals(this.Subscriptions, gsr.Subscriptions);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Subscriptions != null ? Subscriptions.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "GetSubscriptionsResult{"
                    + " subscriptions='" + Subscriptions + '\''
                    + '}';
        }
        #endregion
    }
}