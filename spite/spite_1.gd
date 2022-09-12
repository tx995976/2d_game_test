extends KinematicBody2D

class_name p_default_sprite

var _direct := Vector2(1,0) setget get_p_direct
var _last_direct := Vector2.RIGHT

var _mouse_direct := Vector2.ZERO setget _get_mouse_direct
var _mouse_move_deg := 1.0

var _mouse_pos := Vector2.ZERO

onready var _camera := get_node("camera") as Camera2D
onready var ani := get_node("player_animation") as AnimationPlayer

func _ready():
	var inp := get_node("/root/_G_input") as G_input
	inp.player_node = self
	return
	
func _get_mouse_direct(value: Vector2):
	_mouse_direct = value.normalized()
	_mouse_move_deg  = _mouse_direct.dot(_direct)
	return

func get_p_direct(value: Vector2):
	if(value == _direct):
		return
	_direct = value
	return

func _input(event: InputEvent):
	pass


	
	

	



