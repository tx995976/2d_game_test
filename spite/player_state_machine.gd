extends Node

#下推状态机
var state_map : Dictionary = {}
var state_stack : Array = []

var _active : bool = false setget set_active
var state_now: p_st = null
export(NodePath) var start_state

onready var st_idle: p_st = $p_idle
onready var st_walk: p_st = $p_walk
onready var st_weapon_ready: p_st = $p_ready_weapen 


func _ready():
	state_map = {
		"idle":st_idle,
		"walk":st_walk,
		"weapon_ready":st_weapon_ready,
	}

	for child in get_children():
		child.connect("p_st_change",self,"_state_change")
		
	if not start_state:
		start_state = get_child(0).get_path()
	
	_active = true
	state_now = get_node(start_state) as p_st
	state_stack.push_front(st_idle)

	state_now.enter_st()

	return

func set_active(value: bool):
	_active = value
	set_physics_process(_active)
	set_process_unhandled_input(_active)
	print("is_active !")
	return

# mode = 1 : push , = 2 : pre
func _state_change(new_st: String,change_mode : int):
	if not _active:
		return
	print("change_to %s" % new_st)
	state_now.p_exit()
	if change_mode == 1:
		state_now = state_map[new_st]
		state_stack[0] = state_now
	elif change_mode == 2:
		state_now = state_map[new_st]
		state_stack.push_front(state_now)
		
	state_now.enter_st()		
	return


func _unhandled_input(event: InputEvent):
	state_now.p_input_event(event)
	return

func _process(_delta: float):
	state_now.p_update()

func _physics_process(delta: float):
	state_now.p_update_physics(delta)
	return






	
