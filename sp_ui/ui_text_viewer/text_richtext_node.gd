extends RichTextLabel

class_name ui_text_richtext_node

#flag
@export var flag_flush_delta : bool  = false
@export_enum(ONE_OUT,ALL_OUT) var flag_txt_type = 1
@export_multiline var txt_static : String

enum {ONE_OUT,ALL_OUT}
var timer : float = 10 :
	set(value):
		timer = value
		text = txt_static % timer
		return
#(txt,flag)

func _ready():
	var tween = get_tree().create_tween().set_parallel().set_process_mode(Tween.TWEEN_PROCESS_PHYSICS)
	tween.set_ease(Tween.EASE_IN_OUT).set_trans(Tween.TRANS_BACK)
	match flag_txt_type:
		ONE_OUT:
			tween.tween_property(self,"visible_ratio",1.0,2.0).from(0.0)
		ALL_OUT:
			tween.tween_property(self,"modulate",Color(1,1,1,1),2.0).from(Color(1,1,1,0))
	if(flag_flush_delta):
		tween.tween_property(self,"timer",0.0,10.0).set_trans(Tween.TRANS_LINEAR)
	text = txt_static
	request_ready()
	pass
