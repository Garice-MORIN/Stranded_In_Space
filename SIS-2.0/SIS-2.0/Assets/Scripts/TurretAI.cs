﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TurretAI : NetworkBehaviour
{
    public float range;
    public int damage;
    public int targetPerAttack;
    private GameObject[] enemiesLeft;

    void Update(){
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        Shoot(Aim());
    }

    GameObject Aim(){
        int i = 0;
        while(i < enemiesLeft.Length){
            Ray ray = new Ray(transform.position, enemiesLeft[i].transform.position - transform.position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, range)){
                if(hit.transform.gameObject == enemiesLeft[i]){
                    return enemiesLeft[i];
                }
            }
            i += 1;
        }
        return null;
    }
    void Shoot(GameObject enemy){
        if(enemy != null){
            enemy.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
