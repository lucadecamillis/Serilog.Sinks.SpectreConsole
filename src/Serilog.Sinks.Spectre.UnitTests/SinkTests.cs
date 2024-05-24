namespace Serilog.Sinks.Spectre.UnitTests;

public class SinkTests
{
    [Fact]
    public void Sink_CanRenderSQL()
    {
        string sql = @"Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
SELECT [p].[Id], [p].[ChangedBy], [p].[ChangedOn], [p].[CreatedBy], [p].[CreatedOn], [p].[GroupId], [p].[Name], [t].[CategoriesId], [t].[ParametersId], [t].[Id], [t].[Name]
FROM [Parameters] AS [p]
LEFT JOIN (
    SELECT [c].[CategoriesId], [c].[ParametersId], [c0].[Id], [c0].[Name]
    FROM [CategoryParameter] AS [c]
    INNER JOIN [Categories] AS [c0] ON [c].[CategoriesId] = [c0].[Id]";

        var logger = WireUp(renderTextAsMarkup: false);

        logger.Information(sql);
    }

    private static ILogger WireUp(bool renderTextAsMarkup)
    {
        return new LoggerConfiguration()
            .WriteTo
            .Spectre(renderTextAsMarkup: renderTextAsMarkup)
            .MinimumLevel.Verbose()
            .CreateLogger();
    }
}