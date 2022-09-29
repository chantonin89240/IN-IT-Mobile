﻿using System;
using InitManage.Models.Interfaces;

namespace InitManage.Models.Wrappers;

public class BookingWrapper : IBookingEntity
{
    public BookingWrapper()
    {
    }

    public BookingWrapper(IBookingEntity booking)
    {
        Id = booking.Id;
        UserId = booking.UserId;
        ResourceId = booking.ResourceId;
        Start = booking.Start;
        End = booking.End;
        Capacity = booking.Capacity;
    }

    public long Id { get; set; }
    public long UserId { get; set; }
    public long ResourceId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Capacity { get; set; }

    public IResourceEntity Resource { get; set; }
    public IUserEntity User { get; set; }
}
