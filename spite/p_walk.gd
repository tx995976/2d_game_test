extends p_st

onready var p_node := owner as p_default_sprite
onready var ani_player := owner.get_node("player_animation") as AnimationPlayer
onready var ani_tree := owner.get_node("ani_player_tree") as AnimationTree
onready var ani_status := ani_tree["parameters/playback"] as AnimationNodeStateMachinePlayback


export(int) var walk_speed = 150

func _ready():
	return

func enter_st():
	ani_tree["parameters/walk/blend_position"] = p_node._last_direct
	ani_status.travel("idle_walk")
	return

func p_update_physics(delta: float):
	p_node._direct = Input.get_vector("ui_left","ui_right","ui_up","ui_down")

	ani_tree["parameters/walk/blend_position"] = p_node._direct
	p_node.move_and_collide(p_node._direct.normalized() * walk_speed * delta)

	
	if(p_node._direct == Vector2.ZERO):
		ani_status.travel("idle_walk")
	else:
		ani_tree["parameters/idle_walk/blend_position"] = p_node._direct
		p_node._last_direct = p_node._direct
		ani_status.travel("walk")
	return

func p_input_event(_input: InputEvent):
	if(Input.is_action_just_pressed("battle_weapon_ready")):
		emit_signal("p_st_change","weapon_ready",1)
	return


func p_exit():
	return






