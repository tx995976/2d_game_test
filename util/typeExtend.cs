using System.Reflection;

namespace Obj.util;

public static class typeExtend
{
	public static List<Type> searchClassAttribute(Type attribute, Assembly? assembly = null) {
		if (assembly is null)
			assembly = Assembly.GetExecutingAssembly();

		return assembly.GetTypes()
					   .Where(x => x.IsClass && x.IsDefined(attribute))
					   .ToList();
	}


}