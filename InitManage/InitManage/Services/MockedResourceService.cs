using System;
using InitManage.Commons.Enums;
using InitManage.Models.Entities;
using InitManage.Models.Interfaces;
using InitManage.Models.Wrappers;
using InitManage.Services.Interfaces;

namespace InitManage.Services;

public class MockedResourceService : IResourceService
{

    #region GetResourceAsync
    public async Task<IResource> GetResourceAsync(long id)
    {
        var resource = new ResourceEntity
        {
            Id = 1,
            Capacity = 18,
            Description = "Cette salle de réunion est une salle très spacieuse et lumineuse. Elle se situe au 3ème étage d’un batiment neuf.",
            Image = "https://blog.1001salles.com/wp-content/uploads/2015/04/preparer-sa-salle.jpg",
            Name = "Salle de réunion " + id,
            Type = ResourceType.MeetingRoom,
            Address = "18 Boulevard de Verdun Dijon"
        };

        return resource;
    }
    #endregion

    #region GetResourcesAsync
    public async Task<IEnumerable<IResource>> GetResourcesAsync()
    {
        var resources = new List<ResourceEntity>();

        for (int i = 1; i <= 50; i++)
        {
            var resource = new ResourceEntity
            {
                Id = i,
                Name = $"Salle de réunion {i}",
                Description = $"Description de la salle de réunion n°{i}",
                Image = "https://blog.1001salles.com/wp-content/uploads/2015/04/preparer-sa-salle.jpg",
                Type = ResourceType.MeetingRoom,
                Capacity = new Random().Next(2, 10)
            };
            resources.Add(resource);
        }
        return resources;
    }
    #endregion

    #region GetResourceBookingsAsync
    public async Task<IEnumerable<IBooking>> GetResourceBookingsAsync(long resourceId)
    {
        var bookings = new List<BookingEntity>();
        var resource = await GetResourceAsync(resourceId);

        var lastBooking = new DateTime(2022, 09, 13, 8, 0, 0);

        for (int i = 1; i <= 20; i++)
        {
            var booking = new BookingEntity()
            {
                Id = i,
                Capacity = resource?.Capacity ?? 1,
                ResourceId = resource?.Id ?? 0,
                UserId = 1,
                Start = lastBooking.AddMinutes(15),
                End = lastBooking.AddMinutes(new Random().Next(2, 4) * 15)
            };
            lastBooking = booking.End;
            bookings.Add(booking);
        }

        return bookings;
    }
    #endregion


    public async Task<IEnumerable<BookingWrapper>> GetResourceBookingsWrappersAsync(long resourceId)
    {
        var bookings = await GetResourceBookingsAsync(resourceId);

        var bookingsWrappers = bookings.Select(b => new BookingWrapper(b)).ToList();

        foreach (var bookingWrapper in bookingsWrappers)
        {
            bookingWrapper.User = new UserEntity { Firstname = "Thomas", Id = 1, Lastname = "BERNARD" };
        }

        return bookingsWrappers;
    }
}

