using UnityEngine;

public class ProjectileAddForce : MonoBehaviour
{
    Rigidbody rigidB;
    public float shootForce = 3000f;

    // Start is called before the first frame update
    void OnEnable()
    {
        rigidB = GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.zero;
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        SpinObjectInAir();
    }

    void ApplyForce()
    {
        rigidB.AddRelativeForce(Vector3.forward * shootForce);
    }

    void SpinObjectInAir()
    {
        float _yVelocity = rigidB.velocity.y;
        float _xVelocity = rigidB.velocity.x;
        float _zVelocity = rigidB.velocity.z;
        float _combinedVelocity = Mathf.Sqrt(_xVelocity * _xVelocity + _zVelocity * _zVelocity) + 0.0001f;
        float _fallAngle = -1 * Mathf.Atan(_yVelocity / _combinedVelocity) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(_fallAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

}
