[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyPortfolio.WebSite.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyPortfolio.WebSite.App_Start.NinjectWebCommon), "Stop")]

namespace MyPortfolio.WebSite.App_Start
{
	using System;
	using System.Web;
	using System.Web.Mvc;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using MyPortfolio.Data;
	using MyPortfolio.Logic.Data.Interfaces;
	using MyPortfolio.WebSite.Filters;
	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Web.Mvc.FilterBindingSyntax;
	using Providers.Security.Implementation;
	using Providers.Security.Providers;
	using Providers.Web.Providers;
	using WebHttpContext = Providers.Web.Implementation.HttpContext;
	using WebHttpRequest = Providers.Web.Implementation.HttpRequest;
	using WebHttpCache = Providers.Web.Implementation.HttpCache;
	using WebHttpCookie = Providers.Web.Implementation.HttpCookie;
	using MyPortfolio.Logic.Data.Implementation;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {
			kernel.Bind<IDataContext> ().To<DataContext> ().InRequestScope();
			kernel.Bind<IUserProvider> ().To<UserProvider> ();
			//kernel.BindFilter<ActionFilter> ( FilterScope.Action , 0 );

			kernel.Bind<IHashProvider> ().To<SHA256HashProvider> ();
			kernel.Bind<IRandomizeProvider> ().To<DefaultRandomizeProvider> ();

			kernel.Bind<IHttpContext> ().To<WebHttpContext> ().InRequestScope ();
			kernel.Bind<IHttpRequest> ().To<WebHttpRequest> ().InRequestScope ();
			kernel.Bind<IHttpCache> ().To<WebHttpCache> ().InRequestScope ();
			kernel.Bind<IHttpCookie> ().To<WebHttpCookie> ().InRequestScope ();
			kernel.Bind<ISiteAuthorization> ().To<SiteAuthorization> ();
        }        
    }
}
