using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -30f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isRunning = false;

    // Update is called once per frame
    void Update()
    {
        // Get position of the player and move it (key movement ZQSD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Run"))
        {
            isRunning = !isRunning;
        }

        if (isRunning)
        {
            move *= 1.5f;
        }

        controller.Move(move * speed * Time.deltaTime);

        // Check jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
