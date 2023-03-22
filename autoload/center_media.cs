namespace Obj.autoload;


public class centerMedia : IserviceCenter
{
	static readonly string path_pre_txt = "res://resource/txt_pack/";
	static readonly string path_pre_voice = "res://resource/voice/";

	static readonly string name_world_audio = "%world_audio";

	public Node main_node { get; set; }

	public Dictionary<StringName, res_text_pack> res_txt { get; set; } = new();
	


	public AudioStreamPlayer? world_player;
	


	public centerMedia(Node main_node) {
		this.main_node = main_node;
		start_service();
	}

	public void start_service() {
		txt_load(path_pre_txt);
		world_player = main_node!.GetNode<AudioStreamPlayer>(name_world_audio);
	}

	public void stop_service() {

	}

	#region res_load

	void txt_load(string path) {
		var files = GDfile.GetResFilePaths(path, resNames.txtSuffix);

		GD.Print($"media Loading: ");
		foreach (var file in files)
		{
			GD.Print($"Load {file}");
			var txt_pack = res_text_pack.Load(file);
			res_txt.Add(txt_pack.packName!, txt_pack);
		}
	}

	void voice_load(string path) {

	}

	#endregion

	#region methods

	public void call_txt_view(StringName pack_name, int index = -1) {
		if (!res_txt.ContainsKey(pack_name)){
			GD.Print("txt: no pack");
			return;
		}

		_ = ObjMain.hudServe!.hud_txt!.exec_txt(res_txt[pack_name], index);
	}

	#endregion

}