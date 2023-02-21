
namespace Obj.sp_player.entity.character_army;

public partial class player_root :CharacterBody2D, Idefault_character
{
    public Vector2 view_dir { get; set; }
    public Vector2 velocity_dir { get; set; }
    public double speed { get; set; }

    public IstateMachine? motionState { get; set; }
    public IstateMachine? equipState { get; set; }

    public Sprite2D? texture { get; set; }
    public IanimateTreeSync? animation { get; set; }
    public IaudioPlayer? audioNode { get; set; }

    public int health { get; set; }
    public int armor { get; set; }
    public int banlance { get; set; }

    public event Action? health_break;
    public event Action? armor_break;
    public event Action? banlance_break;

    public override void _Ready() {

    }

    public void be_health_break() {
        throw new NotImplementedException();
    }

    public void walk() {
        throw new NotImplementedException();
    }

    public void action_hited(hit_data context) {
        throw new NotImplementedException();
    }
}