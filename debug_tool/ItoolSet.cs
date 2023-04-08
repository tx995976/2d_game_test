namespace Obj.tool;

public interface ItoolSet
{
	string ToolName { get; }

	terminal_result exec_command(string[]? args);
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class toolSetAttribute : Attribute
{

}

public enum status_cmd : byte
{
	ok = 0,
	error = 1,
	usage = 2,
}

public record terminal_result{

	public status_cmd code;
	public string message = "";

	public terminal_result(status_cmd _code,string _message){
		code = _code;
		message = _message;
	}

	public string _message(){
		return code switch{
			status_cmd.ok => $"[color=green]{message}[/color]",
			status_cmd.error => $"[color=red]{message}[/color]",
			status_cmd.usage => $"[color=yellow]{message}[/color]",
			_ => ""
		};
	}

	public static terminal_result ok(string _message) => new(status_cmd.ok, _message);
	public static terminal_result error(string _message) => new(status_cmd.error,_message);
	public static terminal_result usage(string _message) => new(status_cmd.usage,_message);
}


