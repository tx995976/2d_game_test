namespace Obj.resource;

public class res_textEffect_pack
{
	public string packName { get; set; } = string.Empty;

	public List<ItxtDline> pack_dline { get; set; } = new();

	public static res_textEffect_pack Load(string path) {
		path = path.Remove(path.Length - resNames.txtEffectSuffix.Length);
		var name = path.Split('/').Last();

		using var effectfile = FileAccess.Open(path + resNames.txtEffectSuffix, FileAccess.ModeFlags.Read);

		var res = new res_textEffect_pack
		{
			packName = name,
			pack_dline = txtDlineReader.Load(effectfile)
		};

		logLine.info("resource", $"effect load {name} for global");

		return res;
	}

}