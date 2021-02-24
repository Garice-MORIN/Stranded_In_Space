using UnityEngine;
using Mirror;

public class EnemiesSpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;

   // public Transform spawner;

    public int enemiesNumber = 4;

    GameObject[] allSpawnPoints;

    public override void OnStartServer()
    {
        allSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        for(int i = 0; i < 4; i++)
        {
            var position = allSpawnPoints[i].transform.position;

            var orientation = Quaternion.Euler(0f, (float)Random.Range(0, 360), 0f);

            var enemy = (GameObject)Instantiate(enemyPrefab, position, orientation);
            NetworkServer.Spawn(enemy);
        }
    }
}
