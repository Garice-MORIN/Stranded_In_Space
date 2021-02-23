using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Health : NetworkBehaviour
{
    public const int maxHP = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int health = maxHP; 

    public RectTransform HPBar;

    public bool destroyOnDeath;

    public void TakeDamage(int damage)
    {   
        if(!isServer)
        {
            return;
        }

        health -= damage;

        if(health <= 0){
            if(destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                //transform.Translate(new Vector3(Random.value * 20f, 0, Random.value * 20f));
                health = maxHP;
                RpcRespawn();
            }
        }

    }
    
    [ClientRpc]

    public void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = new Vector3(0f, 1f, 0f);
        }
    }

    public void OnChangeHealth(int oldHealth, int newHealth)
    {
        HPBar.sizeDelta = new Vector2(newHealth, HPBar.sizeDelta.y);
    }
}
