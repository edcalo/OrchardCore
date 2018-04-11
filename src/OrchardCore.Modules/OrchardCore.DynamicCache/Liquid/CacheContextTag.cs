using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Fluid;
using Fluid.Ast;
using Fluid.Tags;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Cache;

namespace OrchardCore.DynamicCache.Liquid
{
    public class CacheContextTag : ArgumentsTag
    {
        public override async Task<Completion> WriteToAsync(TextWriter writer, TextEncoder encoder, TemplateContext context, FilterArgument[] arguments)
        {
            if (arguments.Length < 1)
            {
                // No context has been provided, so return
                return Completion.Normal;
            }

            if (!context.AmbientValues.TryGetValue("Services", out var servicesObj))
            {
                throw new ArgumentException("Services missing while invoking 'cache_context' tag");
            }

            var services = servicesObj as IServiceProvider;

            var cacheScopeManager = services.GetService<ICacheScopeManager>();

            if (cacheScopeManager == null)
            {
                return Completion.Normal;
            }

            var contextToAdd = await arguments[0].Expression.EvaluateAsync(context);

            cacheScopeManager.AddContexts(contextToAdd.ToStringValue());

            return Completion.Normal;
        }
    }
}