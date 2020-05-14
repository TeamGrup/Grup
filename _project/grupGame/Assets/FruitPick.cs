using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPick : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void OnTriggerStay2D(Collider2D Collider)
    {
        var CollidedWith = Collider.gameObject.tag;

        if(CollidedWith == "FruitTree")
        {
            if(Input.GetKeyDown("e"))
            {
                PickFruit();
            }
        }
    }

    void PickFruit()
    {
        Debug.Log("Picking fruit");
        Vector3 fruitPosition = new Vector3(1.3f,0,0);

        Instantiate(prefabToSpawn, gameObject.transform.position + fruitPosition, Quaternion.identity);

    }
}
