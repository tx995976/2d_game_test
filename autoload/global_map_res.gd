extends Node
class_name G_map_res
signal res_bullet_pool_join

#in_game_res
var res_sp_bullet_pool : sp_bullet_pool :
	set(value):
		res_sp_bullet_pool = value
		res_bullet_pool_join.emit()
		return
	get:
		if(!res_sp_bullet_pool):
			await  res_bullet_pool_join
		return res_sp_bullet_pool

var res_ui_weapon_selector : ui_weapon_selector 
var res_ui_text_viewer : ui_text_viewer

#in_game_res
