namespace ArtTrail.WebApi
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;

    using ArtTrail.Data;
    using ArtTrail.Data.Migrations;

    using Newtonsoft.Json;

    public class WebApiApplication : HttpApplication
    {
        #region Methods

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // remove the XML formatter
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // Add support for circular references to the JSON serialiser
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Serialize;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.Objects;

            Database.SetInitializer(new ArtTrailDataContextInitialiser());
            var artTrailDataContext = new ArtTrailDataContext();
            artTrailDataContext.InitialiseDatabase();
        }

        #endregion
    }
}