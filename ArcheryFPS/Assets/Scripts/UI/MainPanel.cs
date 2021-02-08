using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    private static MainPanel instance;

    static Text scoreText;
    static Text nbArrowText;
    static Text gameOverText;
    static HealthBar playerHealthBar;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            nbArrowText = GameObject.Find("NbArrowText").GetComponent<Text>();
            gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
            playerHealthBar = GetComponentInChildren<HealthBar>();
        }
        else
        {
            Destroy(this);
        }
    }

    public static MainPanel Instance
    {
        get
        {
            return instance;
        }
    }

    public static void UpdateScoreText(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public static void UpdateNbArrowText(int nbArrow)
    {
        nbArrowText.text = nbArrow.ToString();
    }

    public static void UpdatePlayerHealthBar(int health)
    {
        playerHealthBar.SetHealth(health);
    }

    public static void ShowGameOverText()
    {
        gameOverText.enabled = true;
    }

}
