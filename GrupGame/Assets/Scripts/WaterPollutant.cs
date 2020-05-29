
using UnityEngine;

public class WaterPollutant : PollutantBehavior
{
    [Header("Movement")]
    public float RotationSpeed = 1.0f;

    //FLOAT CODE SOURCE:
    //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
    protected override void Float()
    {
        transform.Rotate(0, 0, RotationSpeed);
    }
}
