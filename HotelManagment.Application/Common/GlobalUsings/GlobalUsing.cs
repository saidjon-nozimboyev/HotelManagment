﻿global using FluentValidation;
global using HotelManagment.Application.Common.Exceptions;
global using HotelManagment.Application.Common.Extensions;
global using HotelManagment.Application.DTOs.HotelDTOs;
global using HotelManagment.Application.DTOs.RoomDTOs;
global using HotelManagment.Application.DTOs.UserDTOs;
global using HotelManagment.Application.Interfaces;
global using HotelManagment.Data.Interfaces;
global using HotelManagment.Domain.Entities;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Security.Claims;
global using System.Text;