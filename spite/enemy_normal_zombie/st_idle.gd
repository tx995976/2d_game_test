extends p_st

@onready var sp_node := owner as sp_player_root

func _physics_process(delta: float):
	if(sp_node.mov_dir != Vector2.ZERO):
		p_st_change.emit(sp_st_machine.ST_swap,"walk")
	pass
