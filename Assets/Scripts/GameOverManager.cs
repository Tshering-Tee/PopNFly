using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{

    public Rigidbody2D player;
    public GameObject GameOverUI;

    public GameObject gameComponent;
    public int expectedIndex;
    private GameObject triggerBasket;

    [SerializeField] private PlayerScore playerScore;

    public static bool isGameOver = false;

    private bool isPerfectScore;

    public GameObject perfectScoreUi;
    public GameObject normalScoreUi;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        isGameOver = false;
        isPerfectScore = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Boundary"))
        {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
            AudioManager.instance.PlayPlayerDeadSound();
            isGameOver = true;
        }
        else if (col.gameObject.CompareTag("Hoop"))
        {
            isPerfectScore = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.velocity.y < 0)
        {
            if (triggerBasket != collision.gameObject)
            {
                GameOverUI.SetActive(false);
                triggerBasket = collision.gameObject;
                collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;

                if (isPerfectScore == false)
                {
                    playerScore.UpdatePlayerScore(1);
                    normalScoreUi.SetActive(true);
                    StartCoroutine(HidePerfectScoreUi());

                }
                else
                {
                    playerScore.UpdatePlayerScore(2);
                    AudioManager.instance.PlayScoreSound();
                    Handheld.Vibrate();
                    perfectScoreUi.SetActive(true);
                    StartCoroutine(HidePerfectScoreUi());

                }
                isPerfectScore = true;
            }
        }
        else
        {
            if (triggerBasket != collision.gameObject)
            {
                GameOverUI.SetActive(false);

            }
        }
    }

    // countdown method for perfect score text
    private IEnumerator HidePerfectScoreUi()
    {
        yield return new WaitForSeconds(0.5f);
        perfectScoreUi.SetActive(false);
        normalScoreUi.SetActive(false);
    }

}
