using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    CharacterController controller;
    HealthBar healthBar;

    int health = 500;
    int valuePoints = 200;
    int strength = 30;
    float speed = 1000f;

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
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance >= 2.0f)
        {
            Vector3 movement = transform.forward * speed * Time.deltaTime;
            controller.SimpleMove(movement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.name == "Player")
        {
            Player.TakeDamage(strength);
        }
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
