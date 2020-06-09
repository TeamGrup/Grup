using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// https://www.purple-planet.com/
/// </summary>
public class AudioManager : MonoBehaviour {

  public AudioSource effectSource;
  public AudioSource musicSource;

  public AudioClip buttonClick;
  public AudioClip buttonHighlight;

  public AudioClip[] BackgroundMusic;

  public List<AudioClip> activeAudio;

  public static AudioManager instance = null;

  // Start is called before the first frame update
  void Awake() {

    
    // If there is not already an instance of SoundManager, set it to this
    if (instance == null) {
      instance = this;
    //If an instance already exists, destroy whatever this object is to enforce the singleton
    } else if (instance != this) {
      Destroy(gameObject);
    }
    //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene
    //DontDestroyOnLoad(gameObject);

  }

  private void Start() {
    Initialized();
    SetBackgroundMusic(SceneManager.GetActiveScene().buildIndex);
    PlayBackgroundMusic();
  }

 

  private void Initialized() {
    activeAudio = new List<AudioClip>();
    buttonClick = Resources.Load<AudioClip>("Sound\button_select");
    buttonHighlight = Resources.Load<AudioClip>("Sound\button_highlight");
  }

  public void StopEffect() {
    effectSource.Stop();
  }
  public void PlayClip(AudioClip  clip) {
    StopEffect();
    effectSource.clip = clip;
    effectSource.Play();
  }

  public void ButtonClick() {
    effectSource.Stop();
    effectSource.clip = buttonClick;
    effectSource.time = 0f;
    effectSource.Play();
  }

  public void ButtonHighlight() {
    effectSource.Stop();
    effectSource.clip = buttonHighlight;
    effectSource.time = 0f;
    effectSource.Play();
  }

  public void SetVolume(float volumeLevel) {
    musicSource.volume = volumeLevel;
  }

  public void SetBackgroundMusic(int index) {
    musicSource.clip = BackgroundMusic[index];
  }

  public void PlayBackgroundMusic() {
    StopBackgroundMusic();
    musicSource.time = 0f;
    musicSource.Play();
    activeAudio.Add(musicSource.clip);
  }

  public void StopBackgroundMusic() {
    musicSource.Stop();
    activeAudio.Remove(musicSource.clip);
  }
}
