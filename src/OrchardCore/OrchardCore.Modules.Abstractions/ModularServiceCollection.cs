﻿﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace OrchardCore.Modules
{
    public class ModularServiceCollection
    {
        private IServiceCollection _services;

        public ModularServiceCollection(IServiceCollection services)
        {
            _services = services;
        }

        public ModularServiceCollection Configure(Action<IServiceCollection> services)
        {
            services(_services);
            return this;
        }
    }
}