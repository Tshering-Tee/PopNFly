using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject gamePlay;
    public GameObject gameOver;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI countdownLabel;

    public static bool isRestarting = false;

    private enum PreviousMenu { None, Home, Pause }
    private PreviousMenu previousMenu = PreviousMenu.None;

    public static bool canReceiveInput = true;
    public static bool gameStarted = false;

    private bool waitingForTap = true;

    void Start()
    {
        canReceiveInput = true;
        gameStarted = false;

        if (isRestarting)
        {
            isRestarting = false;
            homeMenu.SetActive(false);
            settingMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gamePlay.SetActive(true);

            Time.timeScale = 0f;
            waitingForTap = true;
        }
        else
        {
            homeMenu.SetActive(true);
            settingMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gamePlay.SetActive(false);

            Time.timeScale = 0f;
            waitingForTap = true;
        }
    }

    void Update()
    {
        if (waitingForTap && canReceiveInput)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
#else
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began &&
                !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            {
                waitingForTap = false;
                Time.timeScale = 1f;
                StartGame(); 
            }
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        homeMenu.SetActive(false);
        gamePlay.SetActive(true);
        canReceiveInput = false;
        gameStarted = false;
        AudioManager.instance.PlayButtonSound();
    }

    public void HomeSetting()
    {
        previousMenu = PreviousMenu.Home;
        settingMenu.SetActive(true);
        AudioManager.instance.PlayButtonSound();
    }

    public void PauseSetting()
    {
        previousMenu = PreviousMenu.Pause;
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
        AudioManager.instance.PlayButtonSound();
    }

    public void CloseSettingMenu()
    {
        settingMenu.SetActive(false);

        switch (previousMenu)
        {
            case PreviousMenu.Home:
                homeMenu.SetActive(true);
                break;
            case PreviousMenu.Pause:
                pauseMenu.SetActive(true);
                break;
            default:
                homeMenu.SetActive(true);
                break;
        }

        previousMenu = PreviousMenu.None;
        AudioManager.instance.PlayButtonSound();
    }

    public void PauseButton()
    {
        canReceiveInput = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioManager.instance.PlayButtonSound();
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        gamePlay.SetActive(true);
        StartCoroutine(CountdownResume());
        AudioManager.instance.PlayButtonSound();
    }

    private IEnumerator CountdownResume()
    {
        canReceiveInput = false;
        countdownLabel.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);

        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);

        countdownText.gameObject.SetActive(false);
        countdownLabel.gameObject.SetActive(false);

        Time.timeScale = 1;
        canReceiveInput = true;
    }

    public void HomeButton()
    {
        isRestarting = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayButtonSound();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        isRestarting = true;
        gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayButtonSound();
    }

    public void GoHome()
    {
        Time.timeScale = 1;
        isRestarting = false;
        gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlayButtonSound();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
