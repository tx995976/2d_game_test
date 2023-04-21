using CsvHelper.Configuration.Attributes;

namespace Obj.resource;

public record class res_txtLine
{
	[Index(0)]
	public string show_pos { get; set; } = string.Empty;

	// [Index(1)]
	//issue : 由voice 触发 txt
	// public string name_voice { get; set; } = string.Empty;

	[Index(1)]
	public string text_bbcode { get; set; } = string.Empty;

	//if no voices 
	[Index(2)]
	public double time_sleep { get; set; } = 1.0;

	//
	[Index(3)]
	public double time_apply { get; set; } = 1.0;


	[Index(4)]
	public int effect_out { get; set; } = 0;

	[Index(5)]
	public int effect { get; set; }

}