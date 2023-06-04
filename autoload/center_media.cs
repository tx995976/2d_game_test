namespace Obj.autoload;


public class centerMedia : IserviceCenter
{
	static readonly string path_pre_txt = "res://resource/txt_pack/";
	static readonly string path_pre_voice = "res://resource/voice/";

	static readonly string name_world_audio = "%world_audio";

	public Node main_node { get; set; }

	//txt global
	public Dictionary<string, res_text_pack> res_txt = new();
	public Dictionary<string, res_textEffect_pack> res_txtEffect = new();

	//txt in map
	// Dictionary<string, res_text_pack> res_txt_map = new();
	// Dictionary<string, res_textEffect_pack> res_txtEffect_map  = new();

	//audio
	public AudioStreamPlayer? world_audio;


	public centerMedia(Node main_node) {
		this.main_node = main_node;
		
	}

	public void start_service() {
		txt_load(path_pre_txt);
		world_audio = main_node!.GetNode<AudioStreamPlayer>(name_world_audio);
	}

	public void stop_service() {

	}

	#region txt_res

	void txt_load(string path) {
		//txt_effect
		var files = GDfile.GetResFilePaths(path, resNames.txtEffectSuffix);
		foreach (var file in files)
		{
			logLine.info("resource", $"Load txtEffect_pack {file}");
			var txt_pack = res_textEffect_pack.Load(file);
			res_txtEffect.Add(txt_pack.packName!, txt_pack);
		}

		//txt
		files = GDfile.GetResFilePaths(path, resNames.txtSuffix);
		logLine.info("system", $"txt Loading: ");
		foreach (var file in files)
		{
			logLine.info("resource", $"Load txt_pack {file}");
			var txt_pack = res_text_pack.Load(file);
			res_txt.Add(txt_pack.packName!, txt_pack);

		}
	}


	public ItxtDline? txt_solve_effect(string name) {
		var arg = name.Split('@');
		if (arg.Length != 2)
			return null;
		var (packname, index) = (arg[0], int.Parse(arg[1]));
		if (res_txtEffect.ContainsKey(packname))
			return res_txtEffect[packname].pack_dline[index];
		return null;
	}


	#endregion

	void voice_load(string path) { }


	#region exec_methods

	public void call_txt_view(string pack_name, int index = -1) {
		if (!res_txt.ContainsKey(pack_name))
		{
			logLine.warning("resource", "txt: no pack");
			return;
		}

		//issue Action to call
		_ = ObjMain.hudServe!.ui_txt!.exec_txt(res_txt[pack_name], index);
	}

	#endregion

}