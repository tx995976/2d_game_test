shader_type canvas_item;

uniform sampler2D noise;
uniform float speed : hint_range(0.05,0.5) = 0.1;
uniform float strength : hint_range(0.05,0.5) = 0.1;

void fragment(){
	float noise_value = texture(noise,UV+ (sin(TIME*speed)) ).r;
	COLOR = texture(TEXTURE,UV - (strength / 2.0) + vec2(noise_value) * strength);
}
