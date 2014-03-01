using Nancy.Responses.Negotiation;
using Nancy.ViewEngines;
using System;
using System.Collections.Generic;

namespace Nancy
{
    public class ViewApiProcessor : IResponseProcessor
    {
        private readonly IViewFactory viewFactory;

        public ViewApiProcessor(IViewFactory _viewFactory)
        {
            this.viewFactory = _viewFactory;
        }

        private static readonly IEnumerable<Tuple<string, MediaRange>> extensionMappings =
        new[] { new Tuple<string, MediaRange>("txt", MediaRange.FromString("text/plain")) };

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { return extensionMappings; }
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {

            bool matchingContentType =
                requestedMediaRange.Matches("text/plain");

            return matchingContentType
                ? new ProcessorMatch { ModelResult = MatchResult.DontCare, RequestedContentTypeResult = MatchResult.ExactMatch }
                : new ProcessorMatch();
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            context.ViewBag.RequestType = "text";

            var response = (Response)this.viewFactory.RenderView(context.NegotiationContext.ViewName, model, GetViewLocationContext(context));

            return response.WithContentType("text/plain");
        }

        private static ViewLocationContext GetViewLocationContext(NancyContext context)
        {
            return new ViewLocationContext
            {
                Context = context,
                ModuleName = context.NegotiationContext.ModuleName,
                ModulePath = context.NegotiationContext.ModulePath
            };
        }
    }
}