using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameoverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameover = false;

    public bool GameOver => gameover;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        if (gameover) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    public bool ReturnGameOver()
    {
        return gameover;
    }

    void PlayerGameOver()
    {
        gameover = true;
        playerController.enabled = false;
        gameoverText.SetActive(true);

        Time.timeScale = .1f;

        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}