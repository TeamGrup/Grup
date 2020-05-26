using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimesBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().PlayDelayed(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
