extends ui_text_container


func _init_text(txt:Dictionary,node:ui_text_richtext_node):
	node.flag_txt_type = txt['income_type'] as int
	node.txt_time_left = txt['appear_time']
	node.txt_static = re_init_str % [txt['str_color'],txt['str']]

	if(txt.has('time')):
		node.date_time = txt['time']
		node.time_direct = txt['time_direct']
		node.flag_flush_delta = true
	new_txt.emit(node)
	pass
