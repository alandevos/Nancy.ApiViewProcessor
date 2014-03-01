using Nancy.Bootstrapper;

namespace Nancy.ApiViewProcessor
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override NancyInternalConfiguration InternalConfiguration
        {
            //***** Content Negotiation
            get
            {
                return NancyInternalConfiguration.WithOverrides((c) =>
                {
                    //c.ResponseProcessors.Clear();
                    //c.ResponseProcessors.Insert(c.ResponseProcessors.Count, typeof(ViewProcessor));
                    //c.ResponseProcessors.Insert(c.ResponseProcessors.Count, typeof(ViewApiProcessor));
                    //c.ResponseProcessors.Insert(c.ResponseProcessors.Count, typeof(JsonProcessor));
                });
            }
        }

    }
}