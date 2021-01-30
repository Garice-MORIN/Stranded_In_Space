using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bigger_enemy;  //TODO: Find a better solution for this
    public Transform spawnPoint;
    GameObject[] spawnPoints;
    Vector3[] listOfSpawns;

    public int waveNumber = 1;
    public int waveSize;
    

    
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        listOfSpawns = GetPositionsOfSpawnPoints(spawnPoints);
        StartCoroutine(Enemies(listOfSpawns,waveSize));
    }

    public void SpawnOnClick()
    {
        StartCoroutine(Enemies(listOfSpawns,waveSize));
    }

    public IEnumerator Enemies (Vector3[] listOfSpawns, int t)
    {
        while (t > 0)
        {
            Vector3 pos = listOfSpawns[Random.Range(0,listOfSpawns.Length)];
            Instantiate(ChooseEnemy(Random.Range(0,1)), pos, Quaternion.identity);
            yield return new WaitForSeconds (0.003f);
            t--;
            //Crée x ennemis où x est la taille de la vague
        }
    }

    Vector3[] GetPositionsOfSpawnPoints(GameObject[] listOfObjects)
    {
        Vector3[] returnedList = new Vector3[listOfObjects.Length];
        for(int i = 0; i < listOfObjects.Length; i++)
        {
            returnedList[i] = listOfObjects[i].transform.position;
        }
        return returnedList;
    }

    GameObject ChooseEnemy(int rank)
    {
        switch(rank)
        {
            case 0:
                return enemy;
            case 1:
                return bigger_enemy;
            default:
                return null;  //Code should never go here
        }
    }

}
