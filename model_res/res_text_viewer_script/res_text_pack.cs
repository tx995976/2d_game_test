using CsvHelper.Configuration.Attributes;

namespace Obj.resource;

public class res_text_pack
{
	public readonly static string txtFormat = ".csv.txt";
	public readonly static string effectFormat = ".csv.effect";

	public StringName? packName { get; set; }

	public List<res_txtLine> pack_txt { get; set; } = new();

	public List<res_txtEffect> pack_effects { get; set; } = new();

	public res_txtLine this[int index] {
		get => pack_txt[index - 1];
	}

	//ADDON load 复用
	public static res_text_pack Load(string path) {
		if (!path.EndsWith(txtFormat))
			throw new NotSupportedException();

		path = path.Remove(path.Length - txtFormat.Length);
		var name = path.Split('/').Last();


		using var txtfile = Godot.FileAccess.Open(path + txtFormat, FileAccess.ModeFlags.Read);
		using var effectfile = Godot.FileAccess.Open(path + effectFormat, FileAccess.ModeFlags.Read);


		var res = new res_text_pack
		{
			packName = name,
			pack_txt = csvReader.Readrecords<res_txtLine>(txtfile.GetAsText()),
		};
		if(effectfile is not null)
			res.pack_effects = csvReader.Readrecords<res_txtEffect>(effectfile.GetAsText());
			
		return res;
	}

}


