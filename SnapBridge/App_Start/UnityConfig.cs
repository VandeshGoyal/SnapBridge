using SnapBridge.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SnapBridge
{
    [ExcludeFromCodeCoverage]
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDbReadRepository, DbReadRepository>();
            container.RegisterType<IDbWriteRepository, DbWriteRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}