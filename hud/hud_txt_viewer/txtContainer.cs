namespace Obj.hud;

public partial class txtContainer : VBoxContainer
{
	[Export]
	public int limit { get; set; }

	public void add_txt(txtNode node) {
		if (GetChildCount() > limit)
			_ = GetChild<txtNode>(0).dispose();
		this.JoinNode(node);
	}

	public void clear_child() {
		foreach (txtNode node in GetChildren())
			_ = node.dispose();
	}

}
