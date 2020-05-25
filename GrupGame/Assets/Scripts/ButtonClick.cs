using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
  public AudioSource soundFX;
  public AudioClip buttonSelect;
  public AudioClip buttonHighlight;

  public void HoverSound() {
    soundFX.PlayOneShot(buttonHighlight);
  }
  public void ClickSound() {
    soundFX.PlayOneShot(buttonSelect);
  }
}
