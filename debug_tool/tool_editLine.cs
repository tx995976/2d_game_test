namespace Obj.tool;

public partial class tool_editLine : LineEdit
{
	Stack<string> _temp = new();

	public Action? exitAction;

	public override void _Ready() {
		TextSubmitted += history;
	}

	public override void _GuiInput(InputEvent @event) {
		if (@event.IsActionPressed("ui_up"))
		{
			review();
		}
		else if (@event.IsActionPressed("ui_terminal"))
		{
			exitAction?.Invoke();
		}
	}

	void history(string text) {
		_temp.Push(text);
	}

	void review() {
		if (_temp.Count != 0)
		{
			Text = _temp.Pop();
		}
	}

}