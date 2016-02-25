using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Aritter.Infra.Data.SeedWork.Extensions
{
	public static class ExtensionManager
	{
		public static StringPropertyConfiguration HasUniqueIndex(this StringPropertyConfiguration config)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute { IsUnique = true }));
		}

		public static StringPropertyConfiguration HasUniqueIndex(this StringPropertyConfiguration config, string name)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, 1) { IsUnique = true }));
		}

		public static StringPropertyConfiguration HasUniqueIndex(this StringPropertyConfiguration config, string name, int order)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, order) { IsUnique = true }));
		}

		public static StringPropertyConfiguration HasUniqueIndex(this StringPropertyConfiguration config, params IndexAttribute[] indexAttributes)
		{
			foreach (var indexAttribute in indexAttributes)
			{
				indexAttribute.IsUnique = true;
			}

			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(indexAttributes));
		}

		public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration config)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute { IsUnique = true }));
		}

		public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration config, string name)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, 1) { IsUnique = true }));
		}

		public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration config, string name, int order)
		{
			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, order) { IsUnique = true }));
		}

		public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration config, params IndexAttribute[] indexAttributes)
		{
			foreach (var indexAttribute in indexAttributes)
			{
				indexAttribute.IsUnique = true;
			}

			return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(indexAttributes));
		}
	}
}