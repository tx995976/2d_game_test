namespace Obj.util;

public static class GDfile
{
	public static List<string> GetResFilePaths(string path, string suffix) {
		var dir_file = DirAccess.Open(path);
		return dir_file.GetFiles()
			.Where(x => x.EndsWith(suffix))
			.Select(x => path + x)
			.ToList();
	}

	


}