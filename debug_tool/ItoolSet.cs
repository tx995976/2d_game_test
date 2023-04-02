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
}

public record terminal_result
(
	status_cmd code,
	string message = ""
);