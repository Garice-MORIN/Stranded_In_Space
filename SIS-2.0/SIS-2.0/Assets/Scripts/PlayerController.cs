using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public Camera myCam;
    public AudioListener myAudioListener;
    public LayerMask mask;
    public Transform MeleeRangeCheck;
    public float gunRange = 100000f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public ParticleSystem gunParticle;

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;      
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if(Input.GetButtonDown("Fire1"))
        {
            CmdFire();
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
