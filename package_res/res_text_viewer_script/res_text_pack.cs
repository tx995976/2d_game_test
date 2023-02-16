using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;


namespace Obj.resource;

public record class res_txtLine
{
	[Index(0)]
	public string? show_pos { get; set; }

	[Index(1)]
	public string? name_voice { get; set; }

	[Index(2)]
	public string? text_bbcode { get; set; }

	//if no voices 
	[Index(3)]
	public double time_sleep { get; set; } = 1.0;

	//
	[Index(4)]
	public double time_apply { get; set; } = 1.0;

	[Index(5)]
	public double time_exit { get; set; } = 0.5;

}

public class res_text_pack
{
	public static string Format = ".csv.txt";

	public StringName? packName { get; set; }

	public List<res_txtLine> pack_txt { get; set; } = new();

	public res_txtLine this[int index] {
		get => pack_txt[index - 1];
	}

	public static List<res_txtLine> Readrecords(string text) {
		using var stream = new StringReader(text);
		using var reader = new CsvReader(stream,
				new CsvConfiguration(CultureInfo.InvariantCulture)
				{
					HasHeaderRecord = false,
				});
		return reader.GetRecords<res_txtLine>().ToList();

	}

	public static res_text_pack Load(string path) {
		if (!path.EndsWith(Format))
			throw new NotSupportedException();

		var file = Godot.FileAccess.Open(path, Godot.FileAccess.ModeFlags.Read);
		var name = path.Split('/').Last();
		name = name.Remove(name.Find(Format));
		return new res_text_pack
		{
			packName = name,
			pack_txt = res_text_pack.Readrecords(file.GetAsText()),
		};
	}

}


