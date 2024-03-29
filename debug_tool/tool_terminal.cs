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
		ObjMain.cmdServe.result_callback += add_line;

	}

	public override void _Ready() {


	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed("ui_terminal"))
		{
			_window!.Visible = !_window.Visible;
			Visible = !Visible;
			_input!.GrabFocus();
		}

	}


	void commit_cmd(string command) {
		if (string.IsNullOrWhiteSpace(command))
			return;
		_input!.Text = string.Empty;
		add_line("] " + command);

		var token = command.Split(' ');
		if (token.Length >= 1){
			var tool = token[0];
			var arg = token.Length > 1 ? token[1..] : null;

			ObjMain.cmdServe!.exec_command(tool, arg);
		}
	}


	void add_line(terminal_result res){
		var line = res._message();
		_result!.Text += line + '\n';
	}

	void add_line(string line) =>
		_result!.Text += line + '\n';




}
