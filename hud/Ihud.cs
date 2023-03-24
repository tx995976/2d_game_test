using Obj.sp_player;

namespace Obj.hud;

public interface Ihud : ui.Iui
{
    Iactor? character_node { get; set; }
}