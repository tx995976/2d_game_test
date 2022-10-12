extends CharacterBody2D
class_name sp_bullet

# owner -> bullet_pool

@export var bullet_speed = 0.0
@export var bullet_range = 0.0

var _direct : Vector2
var info_collide : KinematicCollision2D = null
var bullet_dmg : float
var shoot_range :float

func _ready():
	msg_bullet_stop.connect(self._bullet_hit)
	z_index = 5
	return

func _init_bullet(pos: Vector2,direct: Vector2,dmg: float):
	position = pos
	_direct = direct
	rotation = Vector2.RIGHT.angle_to(direct)
	bullet_dmg = dmg
	shoot_range = bullet_range
	return

func _bullet_hit(value):
	if(info_collide and info_collide.get_collider().has_method("_action_be_hit")):
		info_collide.get_collider().call_deferred("_action_be_hit",bullet_dmg)
	info_collide = null
	return

func _physics_process(delta: float):
	info_collide = move_and_collide(delta * bullet_speed * _direct)
	shoot_range -=  delta * bullet_speed
	if(info_collide or shoot_range < 0):
		msg_bullet_stop.emit(self)
	return

#signal
signal msg_bullet_stop(obj)
#signal


