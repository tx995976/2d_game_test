extends Node
class_name G_map_res
signal res_bullet_pool_join

#in_game_res
var res_sp_bullet_pool : sp_bullet_pool :
	set(value):
		res_sp_bullet_pool = value
		res_bullet_pool_join.emit()
		return
#in_game_res


func get_sp_bullet_pool():
	if(not res_sp_bullet_pool):
		await res_bullet_pool_join
	return res_sp_bullet_pool
