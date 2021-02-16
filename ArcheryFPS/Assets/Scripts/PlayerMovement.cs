using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private float playerSpeed = 12.0f;
    private float gravityValue = 30.0f;
    private float jumpHeight = 3.0f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        // Get position of the player and move it (key movement ZQSD)
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Run"))
        {
            move *= 1.5f;
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        // Check jump
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * 2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y -= gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
