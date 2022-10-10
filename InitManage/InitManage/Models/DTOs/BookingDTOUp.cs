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

        //[JsonProperty("userId")]
        //public long UserId { get; set; }

        [JsonProperty("rsourceId")]
        public long ResourceId { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        public BookingDTOUp()
        {
        }

        public BookingDTOUp(IBookingEntity booking)
        {
            ResourceId = booking.ResourceId;
            Start = booking.Start;
            End = booking.End;
            Capacity = booking.Capacity;
        }
    }
}
