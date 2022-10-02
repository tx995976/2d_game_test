extends CharacterBody2D

class_name p_default_sprite

var _direct := Vector2.ZERO :
	get:
		return _direct 
	set(mod_value):
		if(mod_value != _direct):
			_direct = mod_value  
var _mouse_direct := Vector2.ZERO :
	get:
		return _mouse_direct 
	set(mod_value):
		_mouse_direct = mod_value.normalized()
		_mouse_move_deg  = _mouse_direct.dot(_direct)  
var flag_allow_input := true :
	get:
		return flag_allow_input
	set(value):
		flag_allow_input = value
		self.set_process_unhandled_input(value)
		return
var extra_move := Vector2.ZERO :
	set(value):
		position += value
		return

var _last_direct := Vector2.RIGHT
var _mouse_move_deg := 1.0
var _mouse_pos := Vector2.ZERO

@onready var node_input := get_node("/root/_G_input") as G_input
@onready var node_map_res := get_node("/root/global_map_res") as global_map_res

func _ready():
	node_input.player_node = self
	return
	
func _unhandled_input(event):
	#input_data
	_direct = Input.get_vector("action_left","action_right","action_up","action_down")
	_mouse_direct = get_local_mouse_position()
	#
	pass



	
	

	



