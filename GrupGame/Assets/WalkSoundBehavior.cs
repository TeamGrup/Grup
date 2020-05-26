using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundBehavior : MonoBehaviour
{
    private AudioSource walkAudio;
    private player parentScript;

    // Start is called before the first frame update
    void Start()
    {
        walkAudio = this.GetComponent<AudioSource>();
        parentScript = gameObject.GetComponentInParent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > .5 && parentScript.onGround == true)
        {
            if(!walkAudio.isPlaying)
                walkAudio.PlayDelayed(.15f);
        }
        else
        {
            walkAudio.Pause();
        }
    }
}
