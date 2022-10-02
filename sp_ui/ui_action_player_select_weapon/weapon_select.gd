extends Control

class_name ui_weapon_selector

@onready var node_mid := get_node("mid_pos") as Marker2D
@onready var G_input := get_node("/root/_G_input")

@export var panel_twe: float = 100.0

var res_weapon_panel := preload("res://sp_ui/ui_action_player_select_weapon/weapon_label.tscn")
var mid_pos : Vector2

var array_panel := []
var selected_panel : ui_weapon_lable = null :
	get:
		return selected_panel 
	set(value):
		if(selected_panel and value.name != selected_panel.name):
			selected_panel._mouse_exit()
		selected_panel = value
		return


func init_panel():
	var dx := [0,0,1,-1] 
	var dy := [1,-1,0,0]
	for i in range(4):
		var node_panel := res_weapon_panel.instantiate() as ui_weapon_lable
		add_child(node_panel,true)
		node_panel.owner = self
		node_panel.pos_close = mid_pos + node_panel.position
		array_panel.append(node_panel)
		node_panel.pos_open = mid_pos + Vector2(dx[i],dy[i])*panel_twe +node_panel.position
		#print(node_panel.owner)
	return

func show_panel():
	if(visible):
		return
	print("show")
	visible = true
	set_process_input(true)
	get_tree().call_group("ui_weapon_panel","_panel_open")
	Engine.time_scale = 0.2
	#get_tree().paused = true
	return

func end_select():
	set_process_input(false)
	#get_tree().paused = false
	get_tree().call_group_flags(SceneTree.GROUP_CALL_DEFAULT,"ui_weapon_panel","_panel_close")
	Engine.time_scale = 1.0
	if(selected_panel):
		await selected_panel.panel_tween_finish
	print("close")
	visible = false
	return

func panel_change(value : ui_weapon_lable):
	if(selected_panel and value.name != selected_panel.name):
		selected_panel._mouse_exit()
	selected_panel = value
	return

func _ready():
	visible = false
	G_input.node_ui_weapon_select = self
	set_process_input(false)
	mid_pos = size / 2
	init_panel()
	
	return

func _input(_event: InputEvent):
	if(Input.is_action_just_released("ui_select_weapon")):
		end_select()
	return
