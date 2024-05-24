using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Sinks.Spectre
{
	public static class SpectreConsoleSinkExtensions
	{
		const string DefaultConsoleOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

		/// <summary>
		/// Write log events to the console using Spectre.Console.
		/// </summary>
		/// <param name="loggerConfiguration">Logger sink configuration.</param>
		/// <param name="outputTemplate">A message template describing the format used to write to the sink.
		/// The default is "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}".</param>
		/// <param name="restrictedToMinimumLevel">The minimum level for
		/// events passed through the sink. Ignored when <paramref name="levelSwitch"/> is specified.</param>
		/// <param name="levelSwitch">A switch allowing the pass-through minimum level
		/// to be changed at runtime.</param>
		/// <param name="renderTextAsMarkup">Instruct the Sink to render plain test as markup, allowing
		/// markup syntax when using the logger</param>
		/// <returns>Configuration object allowing method chaining.</returns>
		public static LoggerConfiguration Spectre(
			this LoggerSinkConfiguration loggerConfiguration,
			string outputTemplate = DefaultConsoleOutputTemplate,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
			LoggingLevelSwitch levelSwitch = null,
			bool renderTextAsMarkup = true)
		{
			return loggerConfiguration.Sink(
				new SpectreConsoleSink(outputTemplate, renderTextAsMarkup),
				restrictedToMinimumLevel,
				levelSwitch);
		}
	}
}