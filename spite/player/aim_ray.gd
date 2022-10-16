extends RayCast2D

@onready var line_aim := get_node("gun_ray") as Line2D
@onready var sp_node := owner as sp_player_root


@export var speed_view : float = 0.005
@export var ray_len := 500
@export var ray_active := false:
	set(value):
		set_physics_process(value)
		set_process_unhandled_input(value)
		visible = value

func _ready():
	set_process_unhandled_input(false)
	set_physics_process(false)
	visible = false
	pass

func _unhandled_input(event: InputEvent):
	sp_node.view_dir = get_local_mouse_position()
	target_position = sp_node.view_dir * ray_len
	force_raycast_update()
	if(is_colliding()):
		line_aim.set_point_position(1,get_collision_point()-sp_node.position)
	else:
		line_aim.set_point_position(1,target_position)
	return

func _physics_process(delta: float):
	if(is_colliding()):
		line_aim.set_point_position(1,get_collision_point()-sp_node.position)
	pass



