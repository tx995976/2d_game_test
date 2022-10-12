extends Node

class_name p_st

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

signal p_st_change(mode,st)
