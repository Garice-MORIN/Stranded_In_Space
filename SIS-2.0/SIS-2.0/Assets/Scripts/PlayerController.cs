using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public Camera myCam;
    //public CameraBis camerabis;
    public AudioListener myAudioListener;
    public LayerMask mask;
    public Transform MeleeRangeCheck;
    public float gunRange = 100000f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public ParticleSystem gunParticle;
    //public float mouseSensitivity = 1250f;
    public CharacterController controller;
    public Transform groundCheck;
    //public Transform playerBody;

    //float xRotation; // = 0f;
    float currentSpeed = 5f;
    bool isGrounded;
    Vector3 velocity;
    float gravity = -19.62f;
    float jumpHeight = 2f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(!isLocalPlayer)
        {
            gameObject.GetComponentInChildren<CameraBis>().enabled = false;
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position,0.2f,mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        /*____________________________MOUSE CAMERA________________________________*/

        if(Input.GetButtonDown("Cursor"))
        {
            ChangeCursorLockState(); //Change the state of the cursor
        }

        /*___________________________MOVEMENTS____________________________________*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*currentSpeed*Time.deltaTime);

        if(Input.GetButtonDown("Run") && isGrounded)
        {
            ChangeSpeed();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*_______________________________PEW PEW_____________________________*/
        if(Input.GetButtonDown("Fire1"))
        {
            CmdFire();
        }  
    }

   void ChangeCursorLockState()
    {
        if(Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ChangeSpeed()
    {
        if(currentSpeed == 5f)
        {
            currentSpeed = 12f;
        }
        else
        {
            currentSpeed = 5f;
        }
    }

    [Command]
    void CmdFire(){
        //Create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        //Play the particle
        if(!gunParticle.isPlaying)
        {
            RpcStartParticles();
        }

        //Spawn the bullet on clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 1.0s
        Destroy(bullet, 1.0f);

        /*RaycastHit _hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out _hit, gunRange, mask))
        {
            Target target = _hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.GetComponent<Target>().TakeDamage(gunDamage);
            }               
        }*/
    }

    [ClientRpc]
    public void RpcStartParticles(){
        StartParticles();
    }

    public void StartParticles(){
        gunParticle.Play();
    }

    public override void OnStartLocalPlayer(){
        GetComponent<MeshRenderer>().material.color = Color.blue;
        if(!myCam.enabled || !myAudioListener.enabled){
            myCam.enabled = true;
            myAudioListener.enabled = true;
        }
    }

}
