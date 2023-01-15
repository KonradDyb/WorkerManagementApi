﻿using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerManagement.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}