using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

  AudioSource effectSource;
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
    effectSource = GetComponent<AudioSource>();
    activeAudio = new List<AudioClip>();
    buttonClick = Resources.Load<AudioClip>("Sound\button_select");
    buttonHighlight = Resources.Load<AudioClip>("Sound\button_highlight");
  }

  public void PlayClip(AudioClip  clip) {
    effectSource.clip = clip;
    effectSource.Play();
  }

  public void ButtonClick() {
    effectSource.clip = buttonClick;
    effectSource.Play();
  }

  public void ButtonHighlight() {
    effectSource.clip = buttonHighlight;
    effectSource.Play();
  }

  public void SetVolume(float volumeLevel) {
    musicSource.volume = Mathf.Clamp01(volumeLevel);
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
