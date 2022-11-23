extends Node

class_name G_input

# Node_ref
var player_node : sp_player_root
var node_ui_weapon_select : ui_weapon_selector
#var node_ui_weapon_select : ui_weapon_selector

@onready var play_status: int = 0   

func _ready():
	self.process_mode = Node.PROCESS_MODE_ALWAYS
	#print("ok")
	pass 
	
func _unhandled_input(event: InputEvent):
	if(Input.is_action_just_pressed("ui_select_weapon")):
		node_ui_weapon_select.show_panel()
	
	return
	

	

	
