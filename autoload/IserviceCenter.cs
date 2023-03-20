using Obj.map;
namespace Obj.autoload;

public interface IserviceCenter
{
	Node main_node { get; set; }

	public void start_service();
	public void stop_service();

}

