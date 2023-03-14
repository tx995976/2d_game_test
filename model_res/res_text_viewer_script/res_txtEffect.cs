using CsvHelper.Configuration.Attributes;

namespace Obj.resource;

public record class res_txtEffect
{

    [Index(0)]
    public string type { get; set; } = string.Empty;

    [Index(1)]
    public string rule { get; set; } = string.Empty;

}
