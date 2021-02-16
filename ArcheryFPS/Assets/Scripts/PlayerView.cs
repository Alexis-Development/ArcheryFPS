using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Transform cam;

    private float mouseSensitivity = 400.0f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime);

        xRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        cam.localEulerAngles = new Vector3(xRotation, 0f, 0f);
    }
}
