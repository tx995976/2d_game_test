using System.Reflection;

namespace Obj.util;

public static class typeExtend
{
	public static List<Type> searchClassAttribute(Type attribute, Assembly? assembly = null) {
		if (assembly == null)
			assembly = Assembly.GetExecutingAssembly();
			
		return assembly.GetTypes()
					   .Where(x => x.IsClass)
					   .Where(x => x.IsDefined(attribute))
					   .ToList();
	}


}