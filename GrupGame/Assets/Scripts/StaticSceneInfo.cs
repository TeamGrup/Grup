

static public class StaticSceneInfo
{
    public enum SpawnPoint
    {
        Entry,
        Exit
    };

    public static SpawnPoint Spawn = SpawnPoint.Entry;

    public static string GetSpawnPoint()
    {
        return (Spawn == SpawnPoint.Entry) ? "EntrySpawn" : "ExitSpawn";
    }
}
