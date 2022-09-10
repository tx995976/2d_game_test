extends KinematicBody2D

class_name p_default_sprite

var _direct := Vector2(1,0) setget get_p_direct
var _direc_str := "right"
var _last_direct := Vector2.RIGHT


var _angle_direct : Array = [0.785398,2.356194,-2.356194,-0.785398]
var _mouse_direct := Vector2.ZERO setget _get_mouse_direct
var _mouse_direc_str := "right"

var _mouse_pos := Vector2.ZERO


onready var _camera := get_node("camera") as Camera2D
onready var ani := get_node("player_animation") as AnimationPlayer

func _ready():
	var inp := get_node("/root/_G_input") as G_input
	inp.player_node = self
	return
	
	
func get_direct_str(value: Vector2) -> String:
	if(value.x < 0):
		return "left"
	elif(value.x > 0):
		return  "right"
	elif(value.y < 0):
		return  "up"
	elif(value.y > 0):
		return  "down"
	return  "idle"

func get_mouse_direct_str(value: Vector2):
	var value_angle := value.angle()
	if(value_angle >= _angle_direct[0] and value_angle <= _angle_direct[1]):
		return "down"
	elif(value_angle > _angle_direct[1] or value_angle < _angle_direct[2]):
		return "left"
	elif(value_angle <= _angle_direct[3] and value_angle >= _angle_direct[2]):
		return "up"
	elif(value_angle > _angle_direct[3] or value_angle < _angle_direct[0]):
		return "right"
	return

func _get_mouse_direct(value: Vector2):
	_mouse_direct = value.normalized()
	_mouse_direc_str = get_mouse_direct_str(_mouse_direct)
	return

func get_p_direct(value: Vector2):
	if(value == _direct):
		return
	_direct = value
	_direc_str = get_direct_str(_direct)
	return

func _input(event: InputEvent):
	pass

func _process(_delta: float):
	return

func _physics_process(delta: float):
	return


	
	

	



