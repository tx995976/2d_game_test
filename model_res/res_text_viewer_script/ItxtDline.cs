using CsvHelper.Configuration.Attributes;

namespace Obj.resource;

public interface ItxtDline
{
	string type { get; }

	IEnumerator<string> tick_flush(string bbcode);

	txtDlineEnum init_enum(res_txtLine line);

	ItxtDline Paser(string[] args);
}

public class txtDlineAttribute : Attribute { }





