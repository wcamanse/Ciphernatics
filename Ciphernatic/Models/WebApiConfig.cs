using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace Ciphernatic.Models
{
    /// <summary>
    /// The purpose of this class to configure middleware components required for OWIN and Katana 
    /// to function as a web interface.
    /// 
    /// This function defines API routes and file server locations that are accessible through the web 
    /// interface
    /// </summary>
    public class WebApiConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // WebApi Configuration
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{action}");

            // add the WebAPI to the pipeline
            appBuilder.UseWebApi(config);

            var executable = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pageLocation = Path.Combine(executable, "/Pages");

            // define local server path
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = new PhysicalFileSystem(".")
            };

            // add to API location pipeline
            appBuilder.UseFileServer(options);

        }
    }
}
