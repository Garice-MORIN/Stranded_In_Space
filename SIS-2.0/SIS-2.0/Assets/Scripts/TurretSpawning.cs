using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TurretSpawning : NetworkBehaviour
{
    public bool spawn = false;
    public bool created = false;
    public bool destroy = false; 
    private GameObject toSpawn;
    private GameObject towerPrefab;
    private Vector3 position;
    private Quaternion orientation;
    void Start(){
        towerPrefab = Resources.Load("Tower") as GameObject;
        position = transform.position + new Vector3(0, 2.5f, 0);
        orientation = Quaternion.Euler(0f, 0f, 0f);
    }
    void Update(){    
        if(spawn && !created){
            toSpawn = (GameObject)Instantiate(towerPrefab, position, orientation);
            NetworkServer.Spawn(toSpawn);
            created = true;
            destroy = false;
        }
        if(destroy && created){
            Destroy(toSpawn);
            created = false;
            spawn = false;
        }
    }
}
