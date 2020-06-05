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
            var gs = FindObjectOfType<GlobalTrackerBehavior>();
            if (PollutantsCleared)
            {
                var pollutants = GameObject.FindGameObjectsWithTag("Pollutant");
                if (pollutants.Length == 0)
                {
                    gs.SaveScene();
                    StaticSceneInfo.Spawn = SpawnLoc;
                    SceneManager.LoadScene(LevelToLoad);
                }
                else
                {
                    // Pulse Pollutant Count
                }
            }
            else
            {
                gs.SaveScene();
                StaticSceneInfo.Spawn = SpawnLoc;
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
}
