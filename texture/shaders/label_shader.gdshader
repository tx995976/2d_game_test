shader_type canvas_item;
render_mode unshaded;

uniform bool selec_flag = false;
uniform bool change_flag = false;

void fragment(){
	if(selec_flag){
		COLOR.a = 2.0;
	}
	if(change_flag){
		COLOR.a = 1.0+ sin(TIME * 25.0) * 0.5;
	}
	
}