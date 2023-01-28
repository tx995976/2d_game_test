namespace Obj.util;


public static class GDext
{
    public static Task<T> LoadAsync<T>(string path) where T : class {
        return Task.Run(() => GD.Load<T>(path));
    }


}

