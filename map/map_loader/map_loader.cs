using Obj.autoload;

namespace Obj.map;

public class mapLoader : IserviceCenter
{
	public Node main_node { get; set; }

	public mapLoader(Node main_node)
	{
		this.main_node = main_node;
	}

	public void start_service()
    {
    
    }

    public void stop_service()
    {
        throw new NotImplementedException();
    }

    

}