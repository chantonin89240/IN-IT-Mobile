﻿using InitManage.Models.DTOs;
using InitManage.Models.Interfaces;
using InitManage.Models.Wrappers;
using System;
using System.Net;

namespace InitManage.Services.Interfaces;

public interface IResourceService
{
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<AUTO GENERATED BY CONFLICT EXTENSION<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< dev
    Task<IEnumerable<IResource>> GetResources();
    Task<HttpStatusCode> CreateResources(ResourceDTOCreate DTO);
====================================AUTO GENERATED BY CONFLICT EXTENSION====================================
    /// <summary>
    /// Get all existing resources
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IResource>> GetResourcesAsync();

    /// <summary>
    /// Get a specific resource with his Id
    /// </summary>
    /// <param name="id">The id of the resource</param>
    /// <returns></returns>
    Task<IResource> GetResourceAsync(long id);

    /// <summary>
    /// Return all bookings of a resource
    /// </summary>
    /// <param name="resourceId">The id of the resource</param>
    /// <returns></returns>
    Task<IEnumerable<IBooking>> GetResourceBookingsAsync(long resourceId);

    Task<IEnumerable<BookingWrapper>> GetResourceBookingsWrappersAsync(long resourceId);
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>AUTO GENERATED BY CONFLICT EXTENSION>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> feature/ui
}

