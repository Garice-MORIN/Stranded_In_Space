using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.5f;

    Vector3 velocity;
    bool grounded;

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
