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
    [SerializeField] PlayerManager playerManager;

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
        gameStatus.gameStatusKind = GameStatus.Kind.GameClear;
        gameStatus.ShowGameClear();
        Invoke("RestartScene", 1.5f);
    }

    void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
    private void FixedUpdate()
    {
       if (gameStatus.gameStatusKind == GameStatus.Kind.Playing)
        {
            CountDown();
        }
    }
    private void CountDown()
    {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            playerManager.PlayerDeath(GameOverKind.TimeOver);
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