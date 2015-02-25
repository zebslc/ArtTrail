namespace ArtTrail.WebApi
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        #region Public Methods and Operators

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }

        #endregion
    }
}