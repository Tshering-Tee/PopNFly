// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement; // Add this for scene management

// public class UiHandler : MonoBehaviour
// {
//     public Button pauseButton;

//     public GameObject pauseCanvas;
//     public GameObject gameMenu;
//     public GameObject mainMenuCanvas;
//     public GameObject settingCanvas;
//     public Button resume;
//     public Button home;
//     public Button restart;
//     public Button setting;
//     public Button settingClose;

//     public Button play;
//     public Button mSetting;

//     void Start()
//     {
//         pauseButton.onClick.AddListener(PauseOnClick);
//         resume.onClick.AddListener(ResumeOnClick);
//         home.onClick.AddListener(HomeOnClick);
//         setting.onClick.AddListener(SettingClicked);
//         settingClose.onClick.AddListener(SettingCloseClicked);
//         restart.onClick.AddListener(RestartClicked);
//         play.onClick.AddListener(playButton);
//         mSetting.onClick.AddListener(MenySettingButton);
//     }

//     // pause buttons
//     void PauseOnClick()
//     {
//         pauseCanvas.SetActive(true);
//         gameMenu.SetActive(false);
//     }

// void RestartClicked()
// {
//     Debug.Log("Restart button clicked!");
//     Time.timeScale = 1f;
//     mainMenuCanvas.SetActive(false); // Hide main menu
//     gameMenu.SetActive(true);        // Show game UI
//     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
// }


//     void ResumeOnClick()
//     {
//         gameMenu.SetActive(true);
//         pauseCanvas.SetActive(false);
//     }

//     void HomeOnClick()
//     {
//         mainMenuCanvas.SetActive(true);
//         pauseCanvas.SetActive(false);
//     }

//     // setting buttons
//     void SettingClicked()
//     {
//         settingCanvas.SetActive(true);
//         pauseCanvas.SetActive(false);
//     }

//     void SettingCloseClicked()
//     {
//         pauseCanvas.SetActive(true);
//         settingCanvas.SetActive(false);
//     }

//     // mainmenu buttons

//     void playButton()
//     {
//         gameMenu.SetActive(true);
//         mainMenuCanvas.SetActive(false);
//     }

//     void MenySettingButton()
//     {
//         settingCanvas.SetActive(true);
//         mainMenuCanvas.SetActive(false);
//     }
// }
