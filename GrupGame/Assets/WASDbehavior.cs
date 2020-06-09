using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDbehavior : MonoBehaviour
{
    [Header("Float Scale")]
    public float amplitude = 0.5f;
    public float frequency = 1f;
    // Position Storage Variables
    Vector3 tempPos = new Vector3();

    public float TimeUntilFadeOut = 5f;
    public float FadeOutCount = 2f;
    
    private float Timer = 0;
    private float FadeTimer = 0;
    private bool BeginCountdown = false;
    private bool NotDestroyed = true;
    private SpriteRenderer sprite;
    private GameObject arrow;
    


    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        arrow = GameObject.Find("Arrow");
        if(StaticSceneInfo.GetSpawnPoint() != "EntrySpawn")
        {
            Debug.Log("Enablings");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Once the player moves, the WASD prompt will stay a bit longer before fading out
        if((Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")) && BeginCountdown == false && NotDestroyed == true)
        {
            BeginCountdown = true;
        }
        else if(BeginCountdown && NotDestroyed == true)
        {
            CountDownToDestruct();
        }


        transform.right = new Vector3(1,0,0);
        Float();
    }

        //FLOAT CODE SOURCE:
    //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
    void Float() {
        // Float up/down with a Sin()
        tempPos = transform.position;
        tempPos.y = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void CountDownToDestruct()
    {
        Timer += Time.smoothDeltaTime;
        if(Timer >= TimeUntilFadeOut)
        {
            FadeThenDestruct();
        }
    }

    void FadeThenDestruct()
    {   
        FadeTimer += Time.smoothDeltaTime;
        float OverallTime = FadeTimer/FadeOutCount;

        Debug.Log(OverallTime);

        Color opacityFade = new Color(1,1,1,1-OverallTime);

        sprite.color = opacityFade;
        arrow.GetComponent<SpriteRenderer>().color = opacityFade;
        
        if(OverallTime >= FadeOutCount)
        {
            gameObject.SetActive(false);
        }

    }

}
