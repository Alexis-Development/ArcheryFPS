using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;
    static int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        MainPanel.UpdateScoreText(score);
    }

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    public static void UpdateScore(int points)
    {
        score += points;
        MainPanel.UpdateScoreText(score);
    }
    
}
