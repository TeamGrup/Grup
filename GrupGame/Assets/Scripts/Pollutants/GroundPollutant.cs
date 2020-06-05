using UnityEngine;

public class GroundPollutant : PollutantBehavior {
  [Header("Movement")]
  public float amplitude = 0.5f;
  public float frequency = 1f;

  

  //FLOAT CODE SOURCE:
  //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
  protected override void Float() {
    // Float up/down with a Sin()
    tempPos = posOffset;
    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

    transform.position = tempPos;
  }

  
}
