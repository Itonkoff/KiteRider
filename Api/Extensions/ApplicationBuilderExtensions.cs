using System;
using Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder InitialiseDatabases(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (scope != null)
            {
                using var context = scope.ServiceProvider.GetRequiredService<PayRollDatabaseContext>();
                try
                {
                    context.Database.Migrate();
                    // Do data seeding here
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            return app;
        }
    }
}