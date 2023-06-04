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

	public static IEnumerable<string> GetLineEnum(this FileAccess file) {
		var line = file.GetLine();
		while (!string.IsNullOrEmpty(line)){
			yield return line;
			line = file.GetLine();
		}
	}

	public static IEnumerable<string[]> GetCsvEnum(this FileAccess file){
		var line = file.GetCsvLine();
		while (line.Length > 1 || !string.IsNullOrEmpty(line[0])){
			yield return line;
			line = file.GetCsvLine();
		}
	}

	


}