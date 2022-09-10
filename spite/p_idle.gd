extends p_st

onready var p_node : p_default_sprite = owner
onready var ani_player := get_node("%s/player_animation" % owner.get_path()) as AnimationPlayer
onready var ani_tree := get_node("%s/ani_player_tree" % owner.get_path()) as AnimationTree
onready var status_machine := get_node("%s/player_state_machine" % owner.get_path())

var str_direct : Array = ["left","right","up","down"]

func _ready():
	print(owner.name)
	return


func enter_st():
	ani_player.stop()
	

	return

func p_update():
	return


func p_input_event(event: InputEvent):
	return

func p_exit():
	return






