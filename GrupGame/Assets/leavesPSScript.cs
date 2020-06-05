using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys particle system after XXX time
/// </summary>
public class leavesPSScript : MonoBehaviour {
  public float aliveTime = 3f;
  // Start is called before the first frame update
  void Start() {
    StartCoroutine(KillParticleSystem());
  }


  IEnumerator KillParticleSystem() {

    yield return new WaitForSeconds(aliveTime);
    Destroy(this);
  }
}
