namespace Obj.tool;

public partial class tool_terminal : Control
{
	LineEdit? _input;
	Window? _window;

	public RichTextLabel? _result;

	public override void _EnterTree() {
		_result = GetNode<RichTextLabel>("%terminal_res");
		_input = GetNode<LineEdit>("%terminal_input");
		_window = GetNode<Window>("window");

		_window!.CloseRequested += () => _window.Visible = false;
		_input!.TextSubmitted += commit_cmd;
	}

	public override void _Ready() {


	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed("ui_terminal"))
		{
			_window!.Visible = !_window.Visible;
			Visible = !Visible;
		}

	}


	void commit_cmd(string command) {
		if (string.IsNullOrWhiteSpace(command))
			return;
		_input!.Text = string.Empty;
		add_line("] " + command);

		var token = command.Split(' ');
		if (token.Length <= 1)
			return;

		var tool = token[0];
		var arg = token[1..];

		var res = ObjMain.cmdServe!.exec_command(tool, arg);
		add_line(res);
	}


	public void add_line(string line) =>
		_result!.Text += line + '\n';




}
