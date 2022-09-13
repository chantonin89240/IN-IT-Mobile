using System;
using InitManage.Models.Interfaces;

namespace InitManage.Models.Wrappers;

public class BookingWrapper : IBooking
{
    public BookingWrapper()
    {
    }

    public long Id { get; set; }
    public long UserId { get; set; }
    public long ResourceId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Capacity { get; set; }

    public IResource Resource { get; set; }
    public IUser User { get; set; }
}

