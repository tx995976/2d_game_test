using Obj.tool;
using System.Reflection;

namespace Obj.autoload;

public class centerCmd : IserviceCenter
{
	//static readonly string namespace_tool = "Obj.tool.toolSet";
	static readonly string tool_path = "%ui_terminal";

	Dictionary<string, ItoolSet> toolProvider = new();

	tool_terminal? _terminal;

	public Node main_node { get; set; }

	public event Action<terminal_result>? result_callback;

	public centerCmd(Node main_node) {
		this.main_node = main_node;
		start_service();
	}


	public void start_service() {
		logLine.info("system", "load tools: ");

		var types = typeExtend.searchClassAttribute(typeof(toolSetAttribute));

		// var ass = Assembly.GetExecutingAssembly();
		foreach (var type in types)
		{
			var tool = Activator.CreateInstance(type) as ItoolSet;
			toolProvider.Add(tool!.ToolName, tool);
			logLine.info("system", $"find tool {tool.ToolName}");
		}

		_terminal = main_node.GetNode<tool_terminal>(tool_path);
	}

	public void stop_service() { }

	public void exec_command(string tool, string[]? args) {
		terminal_result res;
		if (!toolProvider.ContainsKey(tool))
			res = terminal_result.error("no tool");
		else
			res = toolProvider[tool].exec_command(args);
		result_callback?.Invoke(res);
	}



}