using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClearText;
    [SerializeField] Text scoreText;
    [SerializeField] Clock timerClock;

    const int MAX_SCORE = 9999;
    int score = 0;
    [SerializeField] float time;
    float initTime;

    private void Start()
    {
        scoreText.text = score.ToString();
        initTime = time;
    }

    public void AddScore(int val)
    {
        score += val;
        if(score > MAX_SCORE)
        {
            score = MAX_SCORE;
        }
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Invoke("RestartScene", 1.5f);
    }
    public void GameClear()
    {
        gameClearText.SetActive(true);
        Invoke("RestartScene", 1.5f);
    }

    void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
    private void Update()
    {
        time = time - Time.deltaTime;
        timerClock.SetTime(time, initTime);
    }
}
