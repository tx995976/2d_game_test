extends p_st

onready var p_node := owner as p_default_sprite
onready var ani_player := owner.get_node("player_animation") as AnimationPlayer
onready var ani_tree := owner.get_node("ani_player_tree") as AnimationTree
onready var ani_status := ani_tree["parameters/playback"] as AnimationNodeStateMachinePlayback


onready var _aim_ray := owner.get_node("aim_ray") as RayCast2D
onready var _gun_ray := owner.get_node("gun_ray") as Line2D
onready var _gun_light := owner.get_node("gun_light") as Light2D
var line_vec := Vector2.ZERO


export(int) var walk_speed = 100
export(int) var gun_range = 500
export(bool) var flag_gun_r = false

func _ready():
	pass

func enter_st():
	p_node._mouse_direct = p_node.get_local_mouse_position()

	ani_tree["parameters/weapon_r/blend_position"] = p_node._mouse_direct
	ani_status.travel("idle_weapon")

	_gun_ray.visible = true
	_gun_light.visible = true

	return

func p_update_physics(delta: float):
	#move
	p_node._direct = Input.get_vector("ui_left","ui_right","ui_up","ui_down")
	p_node._mouse_direct = p_node.get_local_mouse_position()
	_aim_ray.cast_to =p_node._mouse_direct * gun_range


	if(p_node._direct == Vector2.ZERO):
		ani_tree["parameters/idle_weapon/blend_position"] = p_node._mouse_direct
		ani_status.travel("idle_weapon")
	else:
		p_node._last_direct = p_node._mouse_direct
		var vec_direc := p_node._mouse_direct
		if(p_node._mouse_move_deg < 0):
			vec_direc.y -= 1.1
		else:
			vec_direc.y += 1.1
		ani_tree["parameters/weapon_w/blend_position"] = vec_direc
		ani_status.travel("weapon_w")
		
	p_node.move_and_collide(p_node._direct.normalized() * walk_speed * delta)
	#move#

	#action
	if(flag_gun_r):
		_aim_ray.force_raycast_update()
		_gun_light.rotation = p_node._mouse_direct.angle()
		line_vec = _aim_ray.cast_to
		#print(line_vec)
		if(_aim_ray.is_colliding()):
			 line_vec = _aim_ray.get_collision_point() - p_node.position
		_gun_ray.set_point_position(1,line_vec)

	#action#
	return

func p_input_event(_input: InputEvent):
	if(Input.is_action_just_released("battle_weapon_ready")):
		emit_signal("p_st_change","walk",1)
	if(Input.is_action_just_pressed("weapon_func_light")):
		_gun_light.enabled = !_gun_light.enabled
	return

func p_exit():
	_gun_ray.visible = false
	_gun_light.visible = false
	return





