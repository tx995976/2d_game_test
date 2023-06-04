namespace Obj.resource;

public class res_text_pack
{

	public string packName { get; set; } = string.Empty;

	public List<res_txtLine> pack_txt { get; set; } = new();

	//TODO change to ItxtDline
	public List<res_txtEffect> pack_effects { get; set; } = new();


	public res_txtLine this[int index] {
		get => pack_txt[index];
	}

	public static res_text_pack Load(string path) {
		// if (!path.EndsWith(resNames.txtSuffix))
		// 	ThrowHelper.ThrowNotSupportedException<res_text_pack>();

		path = path.Remove(path.Length - resNames.txtSuffix.Length);
		var name = path.Split('/').Last();


		using var txtfile = FileAccess.Open(path + resNames.txtSuffix, FileAccess.ModeFlags.Read);
		// using var effectfile = FileAccess.Open(path + resNames.effectSuffix, FileAccess.ModeFlags.Read);


		var res = new res_text_pack
		{
			packName = name,
			pack_txt = csvReader.ReadWithHeadrecords<res_txtLine>(txtfile.GetAsText()),
		};

		foreach (var line in res.pack_txt)
		{
			if (!string.IsNullOrWhiteSpace(line.effect))
			{
				line.dline = solve_effect(line.effect);
				logLine.debug("resource",$"map effect for txtpack {name}");
			}
		}

		// if(effectfile is not null){
		// 	res.pack_effects = csvReader.ReadWithHeadrecords<res_txtEffect>(effectfile.GetAsText());
		// 	logLine.info("resource","effect load");
		// }

		logLine.info("resource", $"txtpack load {name} for global");

		return res;
	}

	public static ItxtDline? solve_effect(string args) {
		return ObjMain.mediaServe.txt_solve_effect(args);
	}

}


