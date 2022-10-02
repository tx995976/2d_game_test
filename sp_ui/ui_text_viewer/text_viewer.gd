extends VBoxContainer

@export var num_txt := 20


var pool_text_node := []

func _ready():
	for i in range(num_txt):
		var node_text :=  ui_text_richtext_node.new()
		pool_text_node.append(node_text)
	pass
	

