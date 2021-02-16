using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player instance;

    private static int score;
    private static int health;

    private static bool gameIsPaused;
    private static bool gameIsOver;

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        score = 0;
        health = 100;
        gameIsPaused = false;
        gameIsOver = false;
        MainPanel.UpdateScoreText(score);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.tag == "ArrowSpot")
        {
            Debug.Log("collision with player");
            ArrowSpot arrowS = target.GetComponent<ArrowSpot>();
            int nbArrow = arrowS.ArrowPicked();
            GetComponentInChildren<Bow>().AddArrow(nbArrow);
        }
    }

    public static void UpdateScore(int points)
    {
        score += points;
        MainPanel.UpdateScoreText(score);
    }

    public static void TakeDamage(int damage)
    {
        health -= damage;
        MainPanel.UpdatePlayerHealthBar(health);
        if (health <= 0)
        {
            EndGame();
        }
    }

    private static void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private static void PauseGame()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            Time.timeScale = 1;
            MainPanel.HidePauseText();
        }
        else
        {
            gameIsPaused = true;
            Time.timeScale = 0;
            MainPanel.ShowPauseText();
        }
    }

    private static void EndGame()
    {
        gameIsOver = true;
        Time.timeScale = 0;
        MainPanel.ShowGameOverText();
    }


}
