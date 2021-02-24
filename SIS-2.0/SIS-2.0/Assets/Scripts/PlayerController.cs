using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public Camera myCam;
    public AudioListener myAudioListener;
    public GameObject myCanvas;
    public LayerMask mask;
    public Transform MeleeRangeCheck;
    public float gunRange = 100000f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public ParticleSystem gunParticle;
    public CharacterController controller;
    public Transform groundCheck;
    public Transform playerBody;


    float currentSpeed = 5f;
    bool isGrounded;
    Vector3 velocity;
    float gravity = -19.62f;
    float jumpHeight = 2f;


    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, mask);  //Check if the player is on the ground (prevent infinite jumping)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //Change the state of the cursor
        if (Input.GetButtonDown("Cursor"))
        {
            ChangeCursorLockState(); 
        }

        
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            /*____________________________MOUSE CAMERA________________________________*/

            myCam.GetComponent<CameraBis>().UpdateCamera();  //Update camera and capsule rotation

            /*_____________________________MOVEMENTS____________________________________*/

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * currentSpeed * Time.deltaTime);

            //Run command
            if (Input.GetButtonDown("Run") && isGrounded)
            {
                ChangeSpeed();
            }

            //Reset gravity 
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            //Jump command
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            

            /*_______________________________PEW PEW_____________________________*/

            //Fire command
            if (Input.GetButtonDown("Fire1"))
            {
                CmdFire();
            }
        }
    }

    //Change lock state of cursor
   void ChangeCursorLockState()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;   //Masque la souris quand le curseur est vérouillé
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    //Change movement speed
    void ChangeSpeed()
    {
        if(currentSpeed == 5f)
        {
            currentSpeed = 8f;
        }
        else
        {
            currentSpeed = 5f;
        }
    }

    // Client --> Server
    [Command]
    void CmdFire(){
        //Create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        

        //Spawn the bullet on clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 1.0s
        Destroy(bullet, 1.0f);
        
        //Play the particle
        if(!gunParticle.isPlaying)
        {
            RpcStartParticles();
        }

       /* RaycastHit _hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out _hit, gunRange, mask))
        {
            //Target target = _hit.transform.GetComponent<Target>();
            Component target = _hit.transform.GetComponent<Health>();
            if(target != null)
            {
                target.GetComponent<Health>().TakeDamage(10);
            }               
        }*/
    }

    //Server --> Client
    [ClientRpc]
    //Both next functions : Start playing gun particles
    public void RpcStartParticles(){
        StartParticles();
    }

    public void StartParticles(){
        gunParticle.Play();
    }

    //Enable camera and audioListener on connection of the player
    public override void OnStartLocalPlayer(){

        GetComponent<MeshRenderer>().material.color = Color.blue;
        if(!myCam.enabled || !myAudioListener.enabled || !myCanvas){
            myCanvas.gameObject.SetActive(true);
            myCam.enabled = true;
            myAudioListener.enabled = true;
        }

    }

}
