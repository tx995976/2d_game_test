using CsvHelper.Configuration.Attributes;

namespace Obj.resource;

public interface ItxtDline
{
	string type { get; }

	void reset();
	IEnumerator<string> tick_flush(double delta);
	ItxtDline Paser(string[] args);
}

public class txtDlineAttribute : Attribute { }


