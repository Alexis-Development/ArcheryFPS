using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmbedBehavior : MonoBehaviour
{
    Rigidbody rigidB;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter : " + collision.collider.name);
        GameObject target = collision.collider.gameObject;
        if (target.tag == "Enemy")
        {
            gameObject.transform.parent = target.transform;
            EnemyBehavior enemyB = target.GetComponent<EnemyBehavior>();
            int damage = Mathf.RoundToInt(rigidB.velocity.magnitude * 2);
            enemyB.TakeDamage(damage);
        }
        Embed();
    }

    void Embed()
    {
        transform.GetComponent<ProjectileAddForce>().enabled = false;
        rigidB.velocity = Vector3.zero;
        rigidB.useGravity = false;
        rigidB.isKinematic = true;
        Destroy(gameObject, 3.0f);
    }
}
