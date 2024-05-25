﻿using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();

            return service;
        }
    }
}
