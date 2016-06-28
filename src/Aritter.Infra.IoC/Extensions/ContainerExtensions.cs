using SimpleInjector;
using System.Linq;
using System.Reflection;

namespace Aritter.Infra.IoC.Extensions
{
    public static class ContainerExtensions
	{
		#region Methods

		public static void RegisterAllServices<TService>(this Container container)
		{
			RegisterAllServices<TService>(container, Lifestyle.Transient);
		}

		public static void RegisterAllServices<TService>(this Container container, Lifestyle lifestyle)
		{
			RegisterAllServices<TService>(container, null, lifestyle);
		}

		public static void RegisterAllServices<TService>(this Container container, Assembly assembly)
		{
			RegisterAllServices<TService>(container, assembly, Lifestyle.Transient);
		}

		public static void RegisterAllServices<TService, TTypeAssembly>(this Container container)
		{
			RegisterAllServices<TService>(container, typeof(TTypeAssembly).Assembly, Lifestyle.Transient);
		}

		public static void RegisterAllServices<TService, TTypeAssembly>(this Container container, Lifestyle lifestyle)
		{
			RegisterAllServices<TService>(container, typeof(TTypeAssembly).Assembly, lifestyle);
		}

		public static void RegisterAllServices<TService>(this Container container, Assembly fromAssembly, Lifestyle lifestyle)
		{
			fromAssembly = fromAssembly ?? typeof(TService).Assembly;

			var registrations = fromAssembly.GetExportedTypes()
				.Where(p => !p.IsAbstract && typeof(TService).IsAssignableFrom(p) && p.GetInterfaces().Any())
				.Select(p => new { Service = p.GetInterfaces().Last(), Implementation = p })
				.ToList();

			registrations.ForEach(registration =>
			{
				container.Register(registration.Service, registration.Implementation, lifestyle);
			});
		}

		#endregion Methods
	}
}
