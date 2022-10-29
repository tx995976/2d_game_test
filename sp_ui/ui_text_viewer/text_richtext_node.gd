extends RichTextLabel

class_name ui_text_richtext_node

#flag

enum {ONE_OUT,ALL_OUT}
@export_enum(ONE_OUT,ALL_OUT) var flag_txt_type = 1
@export_multiline var txt_static : String

@export var flag_flush_delta : bool  = false

@export var txt_time_left := 0.0
@export var time_direct := 1
@export var time_txt_out : float

var date_time : float = 10 :
	set(value):
		date_time = value
		text = txt_static % date_time
		return

#(txt,flag)

func _ready():
	var tween = get_tree().create_tween().set_parallel().set_process_mode(Tween.TWEEN_PROCESS_PHYSICS)
	tween.set_ease(Tween.EASE_IN_OUT).set_trans(Tween.TRANS_BACK)
	
	match flag_txt_type:
		ONE_OUT:
			visible_ratio = 0
			tween.tween_property(self,"visible_ratio",1.0,time_txt_out)
		ALL_OUT:
			modulate = Color(1,1,1,0)
			tween.tween_property(self,"modulate",Color(1,1,1,1),time_txt_out)
	
	if(flag_flush_delta):
		tween.tween_property(self,"date_time",txt_time_left*time_direct,txt_time_left).set_trans(Tween.TRANS_LINEAR).as_relative()
	else:
		text = txt_static
	
	if(txt_time_left != 0.0):
		var timer := get_tree().create_timer(txt_time_left)
		timer.timeout.connect(self._exit_node)
	
	request_ready()
	pass

func _exit_node():
	if not (owner):
		return
	var tween = get_tree().create_tween().set_parallel().set_process_mode(Tween.TWEEN_PROCESS_PHYSICS)
	tween.set_ease(Tween.EASE_IN_OUT).set_trans(Tween.TRANS_BACK)
	tween.tween_property(self,"modulate",Color(1,1,1,0),1.0)
	await tween.finished
	txt_destroy.emit(self)	
	owner.remove_child(self)

	#basic
	flag_flush_delta = false
	
	#basic

	pass

signal txt_destroy(node_self)

