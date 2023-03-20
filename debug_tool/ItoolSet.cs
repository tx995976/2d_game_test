namespace Obj.tool;

public interface ItoolSet
{
	string ToolName { get; }

	string exec_command(string[] args);
}