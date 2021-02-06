using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStatus gameStatus;
    const int MAX_SCORE = 9999;
    int score = 0;
    [SerializeField] float time;
    float initTime;

    private void Start()
    {
        
        initTime = time;
    }

    public void AddScore(int val)
    {
        score += val;
        if(score > MAX_SCORE)
        {
            score = MAX_SCORE;
        }
        gameStatus.SetScore(score);
    }

    public void GameOver(GameOverKind gameOverKind)
    {
        gameStatus.ShowGameOver(gameOverKind);
        Invoke("RestartScene", 1.5f);
    }
    public void GameClear()
    {
        gameStatus.ShowGameClear();
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
        if(time < 0)
        {
            GameOver(GameOverKind.TimeOver);
        }
        else
        {
            gameStatus.clock.SetTime(time, initTime);
        }
    }
}
public enum GameOverKind
{
    TimeOver,Fall,EnemyAttack,Trap
}