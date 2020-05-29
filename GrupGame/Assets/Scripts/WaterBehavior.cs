using UnityEngine;

public class WaterBehavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var playerScript = GameObject.FindObjectOfType<player>();
            playerScript.ResetOrigin();
        }
    }
}
