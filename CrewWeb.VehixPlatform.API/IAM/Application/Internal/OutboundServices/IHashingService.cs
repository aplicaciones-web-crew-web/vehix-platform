﻿namespace CrewWeb.VehixPlatform.API.IAM.Application.Internal.OutboundServices;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}