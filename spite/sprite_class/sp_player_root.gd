extends CharacterBody2D

class_name sp_player_root

#move,view
var mov_dir := Vector2.ZERO :
	set(value):
		mov_dir = value
		return

var view_dir := Vector2.ZERO :
	set(value):
		view_dir = value.normalized()
		view_mov_deg  = view_dir.dot(mov_dir)  

var extra_move := Vector2.ZERO :
	set(value):
		position += value
		return

@export var flag_allow_input := false :
	set(value):
		flag_allow_input = value
		self.set_process_unhandled_input(value)
		return

var view_mov_deg := 0.0
#move,view

#action_callback

#action_callback

func _unhandled_input(event):
	pass
