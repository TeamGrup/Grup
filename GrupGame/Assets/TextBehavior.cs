using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehavior : MonoBehaviour
{
    [Header("Float Scale")]
    public float amplitude = 0.5f;
    public float frequency = 1f;
    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private bool inRange = false;
    private bool eNotPressed = true;

    private float Timer = 0;  
    private float FadeInCount = 0;
    private float FadeOutCount = 0;
    private float CurrentOpacity = 0;


    [Header("Fade In")]
    public float TimeUntilAppear = 3f;
    public float FadeInOpacity = .7f;
    public float FadeInTime = 2f;
    private TextMeshPro meshRen;
    private SpriteRenderer spriteRen;

    // Use this for initialization
    void Start() {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        meshRen = gameObject.GetComponent<TextMeshPro>();
        meshRen.color = new Color(0,0,1,0);



        spriteRen = gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRen.color = new Color(0,0,1,0);
    }

    // Update is called once per frame
    void Update() {
        Float();

        // ? is there a better way to do these if checks?
        if(Input.GetKeyDown("e"))
        {
            eNotPressed = false;
        }

        if(inRange)
        {
            Timer += Time.smoothDeltaTime;
        }

        if(Timer >= TimeUntilAppear && CurrentOpacity < FadeInOpacity && eNotPressed)
        {
            inRange = false;
            FadeIn();
        }

        if(!eNotPressed && CurrentOpacity > 0)
        {

            FadeOut();
        }
    }

    //FLOAT CODE SOURCE:
    //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
    void Float() {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void FadeIn()
    {
        FadeInCount += Time.smoothDeltaTime;
        CurrentOpacity = FadeInCount/FadeInTime;

        meshRen.color = new Color(1,1,1,CurrentOpacity);
        spriteRen.color = new Color(1,1,1,CurrentOpacity);
    }

    void FadeOut()
    {
        FadeOutCount += Time.smoothDeltaTime;
        meshRen.color = new Color(1,1,1,CurrentOpacity - FadeOutCount);
        spriteRen.color = new Color(1,1,1,CurrentOpacity - FadeOutCount);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
            inRange = true;
    }
}
