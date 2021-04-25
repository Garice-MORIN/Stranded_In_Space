﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TurretAI : NetworkBehaviour
{
    public enum TypeOfTower{
        Basic,
        Electric,
        Flamethrower,
        Slow
    }
    public TypeOfTower typeOfTower;
    public float range;
    public float attackDelay;
    public float cooldown;
    public int damage;
    public int targetsPerAttack;
    
    void Start(){
        cooldown = attackDelay;
    }
    void Update(){
        switch(typeOfTower){
            case TypeOfTower.Basic:
                AttackBasic();
                break;
            case TypeOfTower.Electric:
                AttackElectric();
                break;
            case TypeOfTower.Flamethrower:
                AttackFlamethrower();
                break;
            case TypeOfTower.Slow:
                AttackSlow();
                break;
        }
    }

    int[] GetRandomNumbers(int maxValue, int length){
        if(maxValue <= 0 || length <= 0){
            throw new ArgumentException("TurretAI.GetRandomNumbers Exception");
        }
        int[] res = new int[length];
        System.Random random = new System.Random();
        for(int i = 0; i < length; i++){
            res[i] = random.Next(maxValue);
        }
        return res;
    }
    GameObject[] RemoveAt(GameObject[] source, int index){
        if(source == null || index < 0 || index >= source.Length){
            throw new ArgumentException("TurretAI.RemoveAt Exception");
        }
        GameObject[] dest = new GameObject[source.Length - 1];
        for(int i = 0; i < index; i++){
            dest[i] = source[i];
        }
        for(int i = index + 1; i < source.Length; i++){
            dest[i - 1] = source[i];
        }
        return dest;
    }
    GameObject[] Add(GameObject[] source, GameObject added){
        GameObject[] dest = new GameObject[source.Length + 1];
        for(int i = 0; i < source.Length; i++){
            dest[i] = source[i];
        }
        dest[source.Length] = added;
        return dest;
    }
    void Shoot(GameObject enemy){
        if(enemy != null){
            enemy.GetComponent<Health>().TakeDamage(damage);
        }
    }
    GameObject BasicAim(GameObject[] enemiesLeft){
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
    void AttackBasic(){
        if(cooldown <= 0){
            GameObject target = BasicAim(GameObject.FindGameObjectsWithTag("Enemy"));
            for(int i = 0; i < targetsPerAttack; i++){
                Shoot(target);
            }
            cooldown = attackDelay;
        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
    GameObject[] ElectricAim(GameObject[] enemiesLeft){
        int i = 0;
        int maxEnemiesAtRange = 0;
        GameObject[] enemiesPossible = new GameObject[enemiesLeft.Length];
        while(i < enemiesLeft.Length){
            Ray ray = new Ray(transform.position, enemiesLeft[i].transform.position - transform.position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, range)){
                if(hit.transform.gameObject == enemiesLeft[i]){
                    enemiesPossible[maxEnemiesAtRange] = enemiesLeft[i];
                    maxEnemiesAtRange += 1;
                }
            }
            i += 1;
        }
        if(maxEnemiesAtRange != 0){
            GameObject[] enemiesAimed = new GameObject[targetsPerAttack];
            foreach(int enemyValue in GetRandomNumbers(maxEnemiesAtRange, targetsPerAttack)){
                enemiesAimed = Add(enemiesAimed, enemiesLeft[enemyValue]);
            }
            return enemiesAimed;
        }
        return new GameObject[] {null};
    }
    void AttackElectric(){
        if(cooldown <= 0){
            foreach(GameObject enemy in ElectricAim(GameObject.FindGameObjectsWithTag("Enemy"))){
                Shoot(enemy);
            }
            cooldown = attackDelay;
        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
    void AttackFlamethrower(){}
    void AttackSlow(){}

}
