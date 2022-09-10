extends VBoxContainer


var staus = 0
var now_choose = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	var g_input := get_node("/root/G_input")
	
	var array_button = self.get_children() 
	array_button[now_choose].grab_focus()
	pass # Replace with function body.

func choose_up():
	
	pass
	
func choose_down():
	pass


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
