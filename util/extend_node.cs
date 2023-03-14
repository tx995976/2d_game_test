namespace Obj.util;

public static class GDext
{
    public static Task<T> LoadAsync<T>(string path) where T : class {
        return Task.Run(() => GD.Load<T>(path));
    }

    public static T? SearchOwner<T>(this Node child) where T : class {
        Node owner = child.Owner;
        while(owner is not null && owner is not T)
            owner = owner.Owner;
        return owner as T;
    }

    /// 加入树同时设置Owner
    public static void JoinNode(this Node node,Node child){
        if(child.IsInsideTree())
            return;
            
        child.Owner = node;
        node.AddChild(child);
    }

    /// 从父节点退出树
    public static void RemoveSelf(this Node node){
        node.GetParent().RemoveChild(node);
        node.Owner = null;
    }

    /// 自动停止 
    public static Tween CreateStopTween(this Node node){
        var tween = node.CreateTween();
        tween.Finished += (() => tween.Stop());
        tween.Stop();
        return tween;
    }

    
}

