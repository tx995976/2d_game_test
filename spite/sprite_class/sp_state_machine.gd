extends Node

class_name sp_st_machine

#下推状态机
var st_map := {}
var st_stack := []

@export var _active : bool = false:
	set(value):
		_active = value
		return
@export var start_state : String
		
var state_now: p_st = null
enum {ST_push,ST_swap,ST_ret}


func _ready():
	for child in get_children():
		child.connect("p_st_change",self._state_change)
		st_map[child.name] = child
	
	_active = true
	state_now = st_map[start_state] as p_st
	state_now.enter_st()
	return
	

func _state_change(change_mode : int,st_str: String):
	if not _active:
		return
	print("change_to %s" % st_str)
	st_change.emit(st_str)
	state_now.p_exit()
	match change_mode:
		ST_push:
			st_stack.push_back(state_now)
			state_now = st_map[st_str]
		ST_swap:
			state_now = st_map[st_str]
		ST_ret:
			state_now = st_stack.pop_back()
	state_now.enter_st()
	return


signal st_change(str)