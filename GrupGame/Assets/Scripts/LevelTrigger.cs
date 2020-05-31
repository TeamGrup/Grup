using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public string LevelToLoad;
    public StaticSceneInfo.SpawnPoint SpawnLoc;
    public bool PollutantsCleared = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (PollutantsCleared)
            {
                var pollutants = GameObject.FindGameObjectsWithTag("Pollutant");
                if (pollutants.Length == 0)
                {
                    StaticSceneInfo.Spawn = SpawnLoc;
                    SceneManager.LoadScene(LevelToLoad);
                }
            }
            else
            {
                StaticSceneInfo.Spawn = SpawnLoc;
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
}
