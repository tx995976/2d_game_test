
namespace Obj.test;

[Tool]
public class test_signal : EditorScript
{

	async public override void _Run() {
		SignalAct timer = new();
		Parallel.Invoke(async () => {
			GD.Print("awaiting 1");
			await Task.Delay(5000);
			timer.Invoke();
		});

		timer += () => {
			GD.Print("signal Invoke in lambda");
		};

		await timer;
		GD.Print("signal Invoke in function");
	}
			
}
