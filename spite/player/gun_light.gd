extends PointLight2D

@onready var sp_node := owner as sp_player_root

func _unhandled_input(event: InputEvent):
	if(event is InputEventMouseMotion):
		rotation = sp_node.view_dir.angle()
	pass
