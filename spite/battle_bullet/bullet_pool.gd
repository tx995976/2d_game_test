extends Node2D
class_name sp_bullet_pool

# owner -> map_res_node

@export var num_bullet = 50
@onready var node_map_res := get_node("/root/global_map_res")

var res_gun_bullet := preload("res://spite/battle_bullet/gun_bullet.tscn")
var pool_bullet := []

func _ready():
	#res_reg
	node_map_res.res_sp_bullet_pool = self
	
	for i in range(num_bullet):
		var node_bullet := res_gun_bullet.instantiate() as sp_bullet
		pool_bullet.append(node_bullet)
		node_bullet.msg_bullet_stop.connect(self._bullet_stop)
	
	return

func _shoot_bullet(pos: Vector2,direct: Vector2,dmg: float):
	if(not pool_bullet.is_empty()):
		var bullet_node := pool_bullet.pop_front() as sp_bullet
		bullet_node._init_bullet(pos,direct,dmg)
		add_child(bullet_node)
		bullet_node.owner = self
	else:
		print("bullet_pool empty!")
	return

func _bullet_stop(node_bullet):
	remove_child(node_bullet)
	pool_bullet.push_back(node_bullet)
	return
