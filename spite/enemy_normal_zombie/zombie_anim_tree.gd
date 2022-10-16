extends sp_anim_tree

@onready var sp_node := owner as sp_player_root

@onready var playback = get("parameters/zombie_st_tree/playback") as AnimationNodeStateMachinePlayback

@onready var para_idle : Vector2:
	set(value):
		set("parameters/zombie_st_tree/idle/blend_position",value)
		para_idle = value

@onready var para_walk : Vector2:
	set(value):
		set("parameters/zombie_st_tree/walk/blend_position",value)
		para_walk = value

@onready var para_att : Vector2:
	set(value):
		set("parameters/zombie_st_tree/att/blend_position",value)
		para_att = value

func _ready():
	pass

func _physics_process(delta: float):
	para_walk = sp_node.mov_dir
	para_idle = sp_node.mov_dir
	para_att = sp_node.view_dir
	pass
