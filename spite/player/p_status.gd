extends Node

class_name p_st

signal p_st_change(st,mode)

func _ready():
	set_physics_process(false)
	set_process_unhandled_input(false)
	pass

func enter_st():
	set_physics_process(true)
	set_process_unhandled_input(true)
	pass

func p_exit():
	set_physics_process(false)
	set_process_unhandled_input(false)
	pass
