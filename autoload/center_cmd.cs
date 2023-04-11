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

	public centerCmd(Node main_node) {
		this.main_node = main_node;
		start_service();
	}


	public void start_service() {
		logLine.info("system","load tools: ");
		var types = Assembly.GetExecutingAssembly()
							.GetTypes()
							.Where(x => x.IsDefined(typeof(toolSetAttribute)))
							.ToList();

		var ass = Assembly.GetExecutingAssembly();
		foreach (var type in types)
		{
			var tool = (ItoolSet)ass.CreateInstance(type.FullName!)!;
			toolProvider.Add(tool.ToolName,tool);
			logLine.info("system",$"find tool {tool.ToolName}");
		}

		_terminal = main_node.GetNode<tool_terminal>(tool_path);
	}

	public void stop_service() {}

	public terminal_result exec_command(string tool,string[]? args){
		if(!toolProvider.ContainsKey(tool))
			return terminal_result.error("no tool");
			
		return toolProvider[tool].exec_command(args);
	}



}