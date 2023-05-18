namespace Obj.resource;

public static class resNames
{

	#region res_suffix

	public readonly static string txtSuffix = ".csv.txtline";
	public readonly static string effectSuffix = ".csv.effect";
	public readonly static string scriptSuffix = ".nut";

#if DEBUG
	public readonly static string resSuffix = ".tres";
	public readonly static string csnSuffix = ".tscn";
#else
	public readonly static string resSuffix = ".res";
	public readonly static string csnSuffix = ".scn";
#endif

	#endregion

	#region res_prefix



	#endregion


}