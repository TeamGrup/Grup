using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
  public AudioManager audioManager;
  public AudioClip[] menuEffects;

  public static bool isPaused = false;

  public GameObject mainMenuUI;
  public GameObject pauseMenuUI;
  public GameObject controlsMenuUI;
  public GameObject levelSelectMenuUI;

  

  private void Start() {
    if (SceneManager.GetActiveScene().buildIndex == 0) {
      //audioManager.SetBackgroundMusic(0);
      //audioManager.PlayBackgroundMusic();
    }
    this.transform.parent.gameObject.SetActive(true);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      audioManager.ButtonClick();
      if (isPaused) {
        ResumeGame();
      } else {
        PauseGame();
      }
    }
  }

  public void Play() {
    SceneManager.LoadScene(1);
  }

  public void PauseGame() {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;
    audioManager.SetVolume(0.5f);
  }

  public void ResumeGame() {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
    audioManager.SetVolume(1.0f);
  }

  public void LoadMenu() {
    Debug.Log("Loading Menu");
  }

  public void LoadControlsMenu() {
    mainMenuUI.SetActive(false);
    pauseMenuUI.SetActive(false);
    controlsMenuUI.SetActive(true);
    levelSelectMenuUI.SetActive(false);

  }



  public void BackMenu() {
    Time.timeScale = 1f;
    if (SceneManager.GetActiveScene().buildIndex == 0) {
      levelSelectMenuUI.SetActive(false);
      controlsMenuUI.SetActive(false);
      mainMenuUI.SetActive(true);
    } else {
      if (levelSelectMenuUI.activeSelf) {
        levelSelectMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);

      } else {
        controlsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
      }
    }

  }

  public void SelectLevelMenu() {
    mainMenuUI.SetActive(false);
    pauseMenuUI.SetActive(false);
    controlsMenuUI.SetActive(false);
    levelSelectMenuUI.SetActive(true);
  }

  public void LoadMain() {
    ResumeGame();
    SceneManager.LoadScene(0);
    audioManager.SetBackgroundMusic(0);
    audioManager.PlayBackgroundMusic();
  }

  public void LoadIntro() {
    ResumeGame();

    SceneManager.LoadScene(1);
  }
  public void LoadLevelOne() {
    ResumeGame();

    SceneManager.LoadScene(2);
  }
  public void LoadLevelTwo() {
    ResumeGame();

    SceneManager.LoadScene(3);
  }
  public void LoadLevelThree() {
    ResumeGame();
    SceneManager.LoadScene(4);
  }

  public void LoadCredits() {
    ResumeGame();
    SceneManager.LoadScene("Credits");
  }

}
