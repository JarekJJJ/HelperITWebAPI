using HelperIT.Application.Common.Interfaces;
using HelperIT.Infrastructure.FileStore;
using HelperIT.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient <IDirectoryWrapper, DirectoryWrapper>();
            services.AddTransient <IFileWrapper, FileWrapper>();
            return services;
        }
    }
}
