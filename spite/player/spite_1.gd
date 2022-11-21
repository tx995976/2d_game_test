extends sp_player_root

#@onready var node_map_res := get_node("/root/global_map_res") as global_map_res


func _unhandled_input(event):
	#input_data
	mov_dir = Input.get_vector("action_left","action_right","action_up","action_down")
	view_dir = get_local_mouse_position()
	#非状态动作
	if(Input.is_action_just_pressed("action_pressed")):
		var node_button := get_tree().get_first_node_in_group("sp_button")
		if(node_button != null):
			node_button.call("_action_be_pressed")
	pass
