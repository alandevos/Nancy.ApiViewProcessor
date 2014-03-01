
namespace Nancy.ApiViewProcessor.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = p => 
            {
                return Negotiate.WithView("Index");
            };
        }
    }
}