using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int maxHP = 100;

    //[SyncVar]
    public int currentHP = maxHP; 

    public RectTransform HPBar;

    public void TakeDamage(int damage)
    {
        /*if(!isServer){
            return;
        }*/
        
        currentHP -= damage;

        if(currentHP <= 0){
            currentHP = 0;
        }

        HPBar.sizeDelta = new Vector2(currentHP, HPBar.sizeDelta.y);
    }
}
