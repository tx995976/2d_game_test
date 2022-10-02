extends p_st

@onready var p_node := owner as p_default_sprite
@onready var ani_tree := owner.get_node("ani_player_tree") as AnimationTree
@onready var sp_status := ani_tree.get("parameters/sp_action/playback") as AnimationNodeStateMachinePlayback
@onready var _aim_ray := owner.get_node("aim_ray") as RayCast2D
@onready var _gun_ray := owner.get_node("gun_ray") as Line2D
@onready var _gun_light := owner.get_node("gun_light") as PointLight2D

@onready var node_map_res := get_node("/root/global_map_res") as G_map_res

@onready var val_weapon_r_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/weapon_r/blend_position",value)
		return
@onready var val_idle_weapon_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/idle_weapon/blend_position",value)
		return
@onready var val_walk_weapon_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/walk_weapon/blend_position",value)
		return
@onready var val_walk_weapon_back_blend := Vector2.ZERO :
	set(value):
		ani_tree.set("parameters/sp_action/walk_weapon_back/blend_position",value)
		return

var line_vec := Vector2.ZERO

@export var walk_speed: int = 100
@export var gun_range: int = 500
@export var flag_gun_r: bool = false

#in_game_ready
var node_sp_bullet_pool : sp_bullet_pool

#in_game_ready

func _ready():
	super()
	_res_init()
	pass
	
func _res_init():
	node_sp_bullet_pool = await node_map_res.res_sp_bullet_pool
	msg_bullet_shoot.connect(node_sp_bullet_pool._shoot_bullet)
	pass

func enter_st():
	super()
	p_node._mouse_direct = p_node.get_local_mouse_position()

	val_weapon_r_blend = p_node._mouse_direct
	sp_status.travel("idle_weapon")

	_gun_ray.visible = true
	_gun_light.visible = true

	return

func p_exit():
	super()
	_gun_ray.visible = false
	_gun_light.visible = false
	return

func _physics_process(delta: float):
	#ray
	_aim_ray.target_position =p_node._mouse_direct * gun_range
	p_node._last_direct = p_node._mouse_direct
	#ray
	
	#move
	if(p_node._direct == Vector2.ZERO):
		val_idle_weapon_blend = p_node._mouse_direct
		sp_status.travel("idle_weapon")
	else:
		#p_node._last_direct = p_node._mouse_direct
		var vec_direc := p_node._mouse_direct
		if(p_node._mouse_move_deg < 0):
			val_walk_weapon_back_blend = p_node._mouse_direct
			sp_status.travel("walk_weapon_back")
		else:
			val_walk_weapon_blend = p_node._mouse_direct
			sp_status.travel("walk_weapon")
			
	p_node.move_and_collide(p_node._direct.normalized() * walk_speed * delta)
	#move#

	#action
	if(flag_gun_r):
		_aim_ray.force_raycast_update()
		_gun_light.rotation = p_node._mouse_direct.angle()
		line_vec = _aim_ray.target_position
		#print(line_vec)
		if(_aim_ray.is_colliding()):
			line_vec = _aim_ray.get_collision_point() - p_node.position
			#print("player : %s ray : %s pos : %s" % [p_node.position,_aim_ray.get_collision_point(),line_vec])
		_gun_ray.set_point_position(1,line_vec)

	#action#
	return

func _unhandled_input(_input: InputEvent):
	if(Input.is_action_just_released("battle_weapon_ready")):
		p_st_change.emit("walk",1)
	if(Input.is_action_just_pressed("weapon_func_light")):
		_gun_light.enabled = !_gun_light.enabled
	if(Input.is_action_just_pressed("action_weapon_fire")):
		msg_bullet_shoot.emit(p_node.position,p_node._mouse_direct,1.0)
	return
	
signal msg_bullet_shoot(pos,direct,dmg)


