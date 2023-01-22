using System.Collections.Generic;

public partial class sp_bullet_pool : Node
{

    Queue<sp_node_bullet> pool_bullet = new Queue<sp_node_bullet>();


    [Export]
    int instance_bullet;

    [Export(PropertyHint.File)]
    string? path_bullet_tscn;
    

    public override void _Ready(){
        //instance_bullet
        PackedScene tscn_bullet = GD.Load<PackedScene>(path_bullet_tscn);
        for(int i = 0;i < instance_bullet;i++){
            var node = tscn_bullet.Instantiate<sp_node_bullet>();
            pool_bullet.Enqueue(node);
        

        }


    }

    


}
