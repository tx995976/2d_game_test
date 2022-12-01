extends Panel

#owner -> ui_weapon_selector
class_name ui_weapon_lable

signal panel_tween_finish

@export var time_tween : float

#var res_shader := preload("res://sp_ui/ui_action_player_select_weapon/label_shader.tres") as Shader

var node_Tween
var flag_select := false
var pos_open : Vector2
var pos_close : Vector2


func _ready():
	add_to_group("ui_weapon_panel")
	self.mouse_entered.connect(_mouse_enter)
	#self.connect("mouse_exited",self,"_mouse_exit")
	#material = ShaderMaterial.new()
	#material.shader = res_shader

	return

func _panel_open():
	visible = true
	node_Tween = get_tree().create_tween().set_trans(Tween.TRANS_BACK).set_ease(Tween.TRANS_BACK)
	node_Tween.tween_property(self,"position",pos_open,time_tween).from(pos_close)
	return

func _panel_close():
	if(flag_select):
		self.material.set_shader_parameter("change_flag",true)
		node_Tween = get_tree().create_tween().set_trans(Tween.TRANS_BACK).set_ease(Tween.EASE_OUT)
		node_Tween.tween_property(self,"position",pos_close,time_tween).from(pos_open)
		await node_Tween.finished
		self.material.set_shader_parameter("change_flag",false)
		panel_tween_finish.emit()
	visible = false
	return

func _mouse_enter():
	self.material.set_shader_parameter("selec_flag",true)
	print("%s enter" % name)
	owner.selected_panel = self
	flag_select = true

	return
	
func _mouse_exit():
	self.material.set_shader_parameter("selec_flag",false)
	print("%s exit" % name)
	flag_select = false
	return

