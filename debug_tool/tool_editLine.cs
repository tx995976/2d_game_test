namespace Obj.tool;

public partial class tool_editLine : LineEdit
{

	Stack<string> _temp = new();


	public override void _Ready() {
		TextSubmitted += history;
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed("ui_up"))
		{
			review();
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