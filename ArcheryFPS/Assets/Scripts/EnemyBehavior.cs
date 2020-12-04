using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Transform player;
    CharacterController controller;
    HealthBar healthBar;

    int health = 200;

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
        Vector3 distanceEnemyToPlayer = player.position - transform.position;
        transform.LookAt(player);
        controller.SimpleMove(distanceEnemyToPlayer * Time.deltaTime * 50f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        healthBar.SetHealth(health);
    }
}
