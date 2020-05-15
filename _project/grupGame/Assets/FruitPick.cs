using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPick : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject HeldObject;

    public GameObject ObjectInWorld;

    public bool CanCollect = false;


    void LateUpdate()
    {
        if(Input.GetKeyDown("e"))
        {
            if(CanCollect && (HeldObject == null))
            {
                PickFruit();
                CanCollect = false;
            }else if(HeldObject != null)
            {
                DropFruit();
            }else if((ObjectInWorld != null) && Vector3.Distance(ObjectInWorld.transform.position, transform.position) <= 2)
            {
                PickBackUp();
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        var CollidedWith = Collider.gameObject.tag;

        if(CollidedWith == "FruitTree" && !ObjectInWorld)
        {
            CanCollect = true;          
        }
    }

    void OnTriggerExit2D(Collider2D Collider)
    {
        var CollidedWith = Collider.gameObject.tag;

        if(CollidedWith == "FruitTree")
        {
            CanCollect = false;          
        }
    }

    void PickFruit()
    {
        Vector3 fruitPosition = new Vector3(1.3f,0,0);

        HeldObject = Instantiate(prefabToSpawn, gameObject.transform.position + fruitPosition, Quaternion.identity);
        ObjectInWorld = HeldObject;
        HeldObject.GetComponent<FruitBehavior>().IsHeld = true;
    }

    void DropFruit()
    {
            HeldObject.GetComponent<Rigidbody2D>().isKinematic = false;
            HeldObject.GetComponent<BoxCollider2D>().enabled = true;
            HeldObject.GetComponent<FruitBehavior>().IsHeld = false;
            HeldObject = null;
    }

    void PickBackUp()
    {
        HeldObject = ObjectInWorld;
        HeldObject.GetComponent<FruitBehavior>().IsHeld = true;
        HeldObject.GetComponent<Rigidbody2D>().isKinematic = true;
        HeldObject.GetComponent<BoxCollider2D>().enabled = false;
        // HeldObject.GetComponent<FruitBehavior>().IsHeld = true;
        // ? implement picking fruit back up once dropped
    }
}
