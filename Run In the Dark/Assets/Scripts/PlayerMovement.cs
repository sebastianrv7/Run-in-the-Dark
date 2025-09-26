using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public Transform cameraTransform;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0f, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Dirección relativa a la cámara
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            // Eliminamos la inclinación vertical de la cámara
            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * inputDir.z + camRight * inputDir.x;

            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}
