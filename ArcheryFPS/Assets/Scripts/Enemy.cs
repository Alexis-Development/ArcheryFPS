using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    CharacterController controller;
    HealthBar healthBar;

    int health = 300;
    int valuePoints = 300;
    int strength = 30;

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy collision");
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
