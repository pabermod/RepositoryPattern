﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using RP.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RP.WebApi
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this ApplicationContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this ApplicationContext context)
        {
            if (!context.Customer.Any())
            {
                var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "customer.json"));
                context.Customer.AddRange(customers);
                context.SaveChanges();
            }
        }
    }
}