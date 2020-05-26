using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundBehavior : MonoBehaviour
{
    private AudioSource walkAudio;

    // Start is called before the first frame update
    void Start()
    {
        walkAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > .5)
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
