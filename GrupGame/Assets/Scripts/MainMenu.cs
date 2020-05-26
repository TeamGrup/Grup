using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
  AudioManager audioManager;



  public static bool isPaused = false;

  public GameObject mainMenuUI;
  public GameObject pauseMenuUI;
  public GameObject controlsMenuUI;
  public GameObject levelSelectMenuUI;


  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      if (isPaused) {
        ResumeGame();
      } else {
        PauseGame();
      }
    }
  }

  public void Play() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void PauseGame() {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;
  }

  public void ResumeGame() {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
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

}
