﻿using System.Net;

namespace HotelManagment.Application.Common.Exceptions;

public class StatusCodeException : Exception
{
    public HttpStatusCode Code { get; set; }

    public StatusCodeException(HttpStatusCode code, string message) : base(message)
    {
        Code = code;
    }
}
