extends sp_navigation_agent

func _unhandled_input(event: InputEvent):
	if(Input.is_action_just_pressed("action_weapon_fire")):
		set_target_location(node_sp.get_global_mouse_position())
		flag_mov = 1.0
		set_physics_process(true)
	pass

func _physics_process(delta: float):
	node_sp.mov_dir = node_sp.to_local(get_next_location()).normalized() * flag_mov
	pass




