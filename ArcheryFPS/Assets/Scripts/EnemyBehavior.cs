using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Transform player;
    CharacterController controller;
    HealthBar healthBar;

    int health = 200;
    int valuePoints = 200;
    float gravity = -30f;

    void Start()
    {
        player = Player.Instance.transform;
        controller = GetComponent<CharacterController>();
        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(health);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        Vector3 speed = transform.forward * 5;
        controller.SimpleMove(speed);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Player.UpdateScore(valuePoints);
            Destroy(gameObject);
            return;
        }
        healthBar.SetHealth(health);
    }
}
