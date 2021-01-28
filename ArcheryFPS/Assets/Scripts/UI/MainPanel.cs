using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    private static MainPanel instance;

    static Text scoreText;
    static Text nbArrowText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            nbArrowText = GameObject.Find("NbArrowText").GetComponent<Text>();

            DontDestroyOnLoad(gameObject);
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
}
