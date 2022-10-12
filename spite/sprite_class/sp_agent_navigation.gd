extends NavigationAgent2D

class_name sp_navigation_agent

@export var allow_mouse_input := false :
	set(value):
		set_process_unhandled_input(value)
		return

@onready var node_sp := owner as sp_player_root

var flag_mov := 0.0

func _ready():
	set_physics_process(false)
	target_reached.connect(self._target_reached)
	pass

func _target_reached():
	set_physics_process(false)
	flag_mov = 0.0
	pass

func _unhandled_input(event: InputEvent):
	pass

func _physics_process(delta: float):
	pass




