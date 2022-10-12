extends ui_text_container


func _init_text(txt:Dictionary,node:ui_text_richtext_node):
	node.flag_txt_type = txt['income_type'] as int
	node.txt_time_left = txt['appear_time']
	node.txt_static = re_init_str % [txt['name_color'],txt['name'],txt['str_color'],txt['str']]
	new_txt.emit(node)
	pass
