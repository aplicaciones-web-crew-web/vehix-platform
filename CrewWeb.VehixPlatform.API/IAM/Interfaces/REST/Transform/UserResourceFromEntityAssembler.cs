﻿using CrewWeb.VehixPlatform.API.IAM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Resources;

namespace CrewWeb.VehixPlatform.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(
            user.Id,
            user.Name,
            user.LastName,
            user.Email,
            user.Password,
            user.PhoneNumber,
            user.Dni,
            user.Gender,
            user.PlanId);
    }
}