using Serilog;

namespace Citify.Api.Extensions;

public static class AddSerilogExtensions
{
    public static WebApplicationBuilder AddSerilogLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) =>
        {
            lc.WriteTo.Console();

            lc.WriteTo.File("logs/log.txt");
        });

        return builder;
    }
}