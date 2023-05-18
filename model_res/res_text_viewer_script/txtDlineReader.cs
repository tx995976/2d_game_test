namespace Obj.resource;

public static class txtDlineReader
{
	static Dictionary<string, ItxtDline>? solver_list;

	static void init() {
		var type = typeExtend.searchClassAttribute(typeof(txtDlineAttribute));
		solver_list = new Dictionary<string, ItxtDline>();
		logLine.info("resource", $"load txtDlinesolver");
		foreach (var t in type)
		{
			var solver = Activator.CreateInstance(t) as ItxtDline;
			solver_list.Add(solver!.type, solver);
		}
	}

	static public List<ItxtDline> Load(FileAccess file) {
		if (solver_list is null)
			init();

		var list = new List<ItxtDline>();

		var line = file.GetCsvLine();
		while (line is not null)
		{
			var (type, rule) = (line[0], line[1..]);
			var solver = solver_list!.GetValueOrDefault(type);
			if (solver is null)
				logLine.warning("resource", $"txtDline: no solver {type}");
			else
			{
				list.Add(solver.Paser(rule));
			}
			line = file.GetCsvLine();
		}

		return list;
	}


}