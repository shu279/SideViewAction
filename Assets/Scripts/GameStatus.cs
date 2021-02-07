using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// スコアと制限時間を表示する。
/// ゲームクリア・オーバーを表示する。
/// </summary>
public class GameStatus : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClearText;
    [SerializeField] GameObject gameOverSubText;
    public Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void ShowGameOver(GameOverKind gameOverKind)
    {
        switch (gameOverKind)
        {
            case GameOverKind.EnemyAttack:
                gameOverSubText.GetComponent<Text>().text = "< Killed by DemonRabbit >";
                gameOverSubText.SetActive(true);
                break;
            case GameOverKind.TimeOver:
                gameOverText.GetComponent<Text>().text = "TimeUp!";
                break;
            case GameOverKind.Trap:
                gameOverSubText.GetComponent<Text>().text = "< Got caught in a Trap >";
                gameOverSubText.SetActive(true);
                break;
            case GameOverKind.Fall:
                gameOverSubText.GetComponent<Text>().text = "< Fall into an Abyss >";
                gameOverSubText.SetActive(true);
                break;
        }
        gameOverText.SetActive(true);
    }
    public void ShowGameClear()
    {
        gameClearText.SetActive(true);
    }
}
