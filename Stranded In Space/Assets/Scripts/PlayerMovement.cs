using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public float gravity = -19.62f;
    public float jumpHeight = 2f;

    Vector3 velocity;
    bool grounded;
    bool speed;
    public float moveSpeed = 5f;

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

        if(Input.GetButtonDown("Run"))
        {
            moveSpeed = Speed(speed);  // Check whether haracter is running or walking and change speed accordingly if he is on the ground
            speed = !speed;
        }

        controller.Move(move*moveSpeed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    float Speed (bool speed)   
    {
        if (speed && grounded)
        {
            return 5f;
        }
        else if (!speed && grounded)
        {
            return 12f;
        }
        return moveSpeed;
    }
}
