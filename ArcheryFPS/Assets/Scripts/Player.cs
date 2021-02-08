using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;
    public HealthBar healthBar;

    static int score = 0;
    static int health = 100;

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

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.tag == "ArrowSpot")
        {
            Debug.Log("collision with player");
            ArrowSpot arrowS = target.GetComponent<ArrowSpot>();
            int nbArrow = arrowS.ArrowPicked();
            GetComponentInChildren<Shoot>().AddArrows(nbArrow);
        }
    }

    public static void TakeDamage(int damage)
    {
        health -= damage;
        MainPanel.UpdatePlayerHealthBar(health);
        if (health <= 0)
        {
            MainPanel.ShowGameOverText();
            Time.timeScale = 0;
        }
    }

}
