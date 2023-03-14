using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace Obj.util;

public static class csvReader
{
	public static List<T> Readrecords<T>(string text) where T : class {
        using var stream = new StringReader(text);
		using var reader = new CsvReader(stream,
				new CsvConfiguration(CultureInfo.InvariantCulture)
				{
					HasHeaderRecord = false,
				});
        return reader.GetRecords<T>().ToList();
	}


}
