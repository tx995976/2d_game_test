extends Area2D

@export var fl_len := [1.0]
@export var time_lift := 10.0
@export var next_floor := 1

var num_floor := 0
var p_pos : Vector2
var delta_trans : Vector2

func _ready():
	body_entered.connect(self._spite_enter)
	body_exited.connect(self._spite_exit)
	set_physics_process(false)
	pass
	
func _spite_enter(sp_node: Node2D):
	sp_node.add_to_group("in_lift")
	print("%s enter" % sp_node)
	pass

func _spite_exit(sp_node: Node2D):
	sp_node.remove_from_group("in_lift")
	pass
	
func _lift_start():
	var tween := get_tree().create_tween().set_process_mode(Tween.TWEEN_PROCESS_PHYSICS).set_ease(Tween.EASE_IN_OUT).set_trans(Tween.TRANS_QUAD)
	var vec_relat := Vector2(0,fl_len[next_floor]) - Vector2(0,fl_len[num_floor])
	tween.tween_property(self,"position",vec_relat,time_lift).as_relative()
	
	p_pos = position
	set_physics_process(true)
	await tween.finished
	set_physics_process(false)
	num_floor = next_floor
	pass

func _physics_process(delta):
	delta_trans = position - p_pos
	p_pos = position
	get_tree().set_group("in_lift","extra_move",self.delta_trans)
	pass



