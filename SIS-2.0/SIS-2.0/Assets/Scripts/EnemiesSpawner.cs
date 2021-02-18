using UnityEngine;
using Mirror;

public class EnemiesSpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;

   // public Transform spawner;

    public int enemiesNumber;

    public override void OnStartServer()
    {
        for(int i = 0; i < enemiesNumber; i++)
        {
            var position = new Vector3((float)3 * Random.Range(1, 5), 0, (float)3 * Random.Range(1, 5));

            var orientation = Quaternion.Euler(0f, (float)Random.Range(0, 360), 0f);

            var enemy = (GameObject)Instantiate(enemyPrefab, position, orientation);
            NetworkServer.Spawn(enemy);
        }
    }
}
