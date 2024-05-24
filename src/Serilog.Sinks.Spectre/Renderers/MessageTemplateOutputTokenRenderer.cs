using System.Collections.Generic;
using Serilog.Events;
using Serilog.Parsing;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Renderers
{
    public class MessageTemplateOutputTokenRenderer : ITemplateTokenRenderer
	{
		readonly PropertyToken token;
		readonly bool renderTextAsMarkup;

		public MessageTemplateOutputTokenRenderer(PropertyToken token, bool renderTextAsMarkup)
		{
			this.token = token;
			this.renderTextAsMarkup = renderTextAsMarkup;
		}

		public IEnumerable<IRenderable> Render(LogEvent logEvent)
		{
			foreach (MessageTemplateToken token in logEvent.MessageTemplate.Tokens)
			{
				if (token is TextToken t)
				{
					if (this.renderTextAsMarkup)
					{
						// Render message as markup
						yield return new Markup(t.Text);
					}
					else
					{
						yield return new Text(t.Text);
					}
				}

				if (token is PropertyToken p)
				{
					foreach (IRenderable pr in RendersCommon.RenderProperty(logEvent, p))
					{
						yield return pr;
					}
				}
			}
		}
	}
}