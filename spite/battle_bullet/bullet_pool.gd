extends Node2D
class_name sp_bullet_pool

# owner -> map_res_node

@export var num_bullet = 50

@onready var node_map_res := get_node("/root/global_map_res")

var res_gun_bullet := preload("res://spite/battle_bullet/gun_bullet.tscn")
var queue_free_bullet := []


func _ready():
	#res_reg
	node_map_res.res_sp_bullet_pool = self
	
	for i in range(num_bullet):
		var node_bullet := res_gun_bullet.instantiate() as sp_bullet
		add_child(node_bullet,1)
		node_bullet.owner = self
		queue_free_bullet.append(node_bullet)
		node_bullet.msg_bullet_stop.connect(self._bullet_stop)
	
	return

func _shoot_bullet(pos: Vector2,direct: Vector2,dmg: float):
	if(not queue_free_bullet.is_empty()):
		queue_free_bullet.front()._init_bullet(pos,direct,dmg)
		queue_free_bullet.pop_front()
	else:
		print("bullet_pool empty!")
	return

func _bullet_stop(node_bullet):
	queue_free_bullet.push_back(node_bullet)
	return
