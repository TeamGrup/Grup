using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPollutant : PollutantBehavior
{
    [Header("Movement")]
    public float X_Amplitude = 0.5f;
    public float Y_Amplitude = 0.5f;
    public float X_Frequency = 1f;
    public float Y_Frequency = 1f;

    //FLOAT CODE SOURCE:
    //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
    protected override void Float()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Y_Frequency) * Y_Amplitude;
        tempPos.x += Mathf.Cos(Time.fixedTime * Mathf.PI * X_Frequency) * X_Amplitude;

        transform.position = tempPos;
    }
}
