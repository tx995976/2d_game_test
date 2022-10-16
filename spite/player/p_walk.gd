extends p_st

@export var walk_speed: int = 150

@onready var p_node := owner as sp_player_root
@onready var ani_tree := owner.get_node("ani_player_tree") as AnimationTree
@onready var sp_status := ani_tree.get("parameters/sp_action/playback") as AnimationNodeStateMachinePlayback
@onready var val_idle_walk_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/idle_walk/blend_position",value)
		return
@onready var val_walk_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/walk/blend_position",value)
		return
var collision_info : KinematicCollision2D

func _ready():
	super()
	return

func enter_st():
	super()
	val_idle_walk_blend = p_node.view_dir
	sp_status.travel("idle_walk")
	return

func _physics_process(delta: float):

	val_walk_blend = p_node.mov_dir
	collision_info = p_node.move_and_collide(p_node.mov_dir.normalized() * walk_speed * delta)

	if(p_node.mov_dir == Vector2.ZERO):
		sp_status.travel("idle_walk")
	else:
		val_idle_walk_blend = p_node.mov_dir
		p_node.view_dir = p_node.mov_dir
		sp_status.travel("walk")
	return

func _unhandled_input(event):
	if(Input.is_action_just_pressed("battle_weapon_ready")):
		p_st_change.emit(sp_st_machine.ST_swap,"p_ready_weapon")
	return

func p_exit():
	super()
	return

