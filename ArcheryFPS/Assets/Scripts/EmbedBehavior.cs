using UnityEngine;

public class EmbedBehavior : MonoBehaviour
{
    Rigidbody rigidB;
    bool embed = false;
    int speedOfArrow = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!embed)
        {
            speedOfArrow = Mathf.RoundToInt(rigidB.velocity.magnitude);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Enemy")
        {
            embed = true;
            gameObject.transform.parent = target.transform;
            int damage = speedOfArrow * speedOfArrow / 10 + 1;
            Debug.Log(damage);
            target.SendMessage("TakeDamage", damage);
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
