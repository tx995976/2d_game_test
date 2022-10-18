extends RayCast2D

@onready var line_aim := get_node("gun_ray") as Line2D
@onready var sp_node := owner as sp_player_root


@export var speed_view : float = 0.005
@export var ray_len := Vector2(500,0)
@export var ray_active := false:
	set(value):
		set_physics_process(value)
		set_process_unhandled_input(value)
		visible = value

func _ready():
	set_process_unhandled_input(false)
	set_physics_process(false)
	visible = false

	target_position = ray_len
	pass

func _unhandled_input(event: InputEvent):
	look_at(get_global_mouse_position())
	return

func _physics_process(delta: float):
	var coll_len := ray_len
	if(is_colliding()):
		coll_len.x = (get_collision_point() - global_position).length()
	line_aim.set_point_position(1,coll_len)
	return




