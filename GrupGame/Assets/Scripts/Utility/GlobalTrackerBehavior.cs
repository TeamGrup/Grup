using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GlobalTrackerBehavior : MonoBehaviour
{
    public static GlobalTrackerBehavior Tracker = null;

    private static List<Level> levels = new List<Level>();

    private static string sceneName;

    private void Awake()
    {
        if (Tracker == null)
        {
            DontDestroyOnLoad(gameObject);
            Tracker = this;
        }
        else if (Tracker != this)
        {
            Destroy(gameObject);
        }

        sceneName = SceneManager.GetActiveScene().name;
        LoadScene(sceneName);
    }

    private void LoadScene(string name)
    {
        if (levels.FirstOrDefault(lvl => lvl.LevelName.Equals(name)) != null)
        {
            Debug.Log($"Level has already been loaded once.");
            var curLevel = levels.FirstOrDefault(lvl => lvl.LevelName.Equals(sceneName));
            Assert.IsNotNull(curLevel);

            foreach (var lvlObj in curLevel.LevelObjects)
            {
                if (!lvlObj.Enabled)
                {
                    var gameObj = GameObject.Find(lvlObj.Name);
                    Destroy(gameObj);
                }
            }
        }
        else
        {
            Debug.Log($"Level has never been loaded.");
            var newLevel = new Level
            {
                LevelName = name,
                LevelObjects = new List<LevelObject>()
            };

            // Add pollutants
            var pollutants = GameObject.FindGameObjectsWithTag("Pollutant");
            foreach(var pollutant in pollutants)
            {
                Debug.Log($"Adding Pollutant: {pollutant.name}");
                newLevel.LevelObjects.Add(new LevelObject() { Name = pollutant.name, Enabled = true });
            }

            levels.Add(newLevel);
        }
    }

    public void SaveScene()
    {
        var curLevel = levels.FirstOrDefault(lvl => lvl.LevelName.Equals(sceneName));
        Assert.IsNotNull(curLevel);

        foreach(var lvlObj in curLevel.LevelObjects)
        {
            Debug.Log($"Checking Pollutant: {lvlObj.Name}");
            var gameObj = GameObject.Find(lvlObj.Name);
            if (!gameObj)
            {
                Debug.Log($"Removing Pollutant: {lvlObj.Name}");
                lvlObj.Enabled = false;
            }
        }
    }
}
