using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision.gameObject.tag} has entered the trigger.");
        if (collision.gameObject.tag.Equals("Player"))
        {
            var pollutants = GameObject.FindGameObjectsWithTag("Pollutant");
            Debug.Log($"{pollutants.Length} pollutants left to clear.");
            if (pollutants.Length == 0)
            {
                SceneManager.LoadScene("last-ground-level");
            }
        }
    }
}
