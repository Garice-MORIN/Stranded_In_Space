using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Spawner spawner;
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
    //Gravité
        if(grounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Run") && grounded)
        {
            moveSpeed = ChangeSpeed(speed);  // Verifie si personnage est sur le sol et change la vitesse le cas échéant
            speed = !speed;
        }

        controller.Move(move*moveSpeed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Fire2")) //Spawn des ennemis /!\ Uniquement pour débug 
        {
            GameObject enemy = spawner.GetComponent<Spawner>().enemy;
            Vector3 pos = spawner.GetComponent<Spawner>().spawnPoint.position;
            Instantiate(enemy,pos,Quaternion.identity);
        }
    }

    float ChangeSpeed (bool speed)   
    {
        if (speed)
        {
            return 5f;
        }
        else if (!speed)
        {
            return 12f;
        }
        return moveSpeed;
    }
}
