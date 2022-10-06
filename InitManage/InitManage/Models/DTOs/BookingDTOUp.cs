using InitManage.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitManage.Models.DTOs
{
    public class BookingDTOUp : IBookingEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long ResourceId { get; set; }

        [JsonProperty("id")]
        public DateTime Start { get; set; }

        [JsonProperty("id")]
        public DateTime End { get; set; }

        [JsonProperty("id")]
        public int Capacity { get; set; }
    }
}
