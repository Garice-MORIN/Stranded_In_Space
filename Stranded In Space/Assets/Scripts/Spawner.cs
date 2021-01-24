using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    public int waveSize;
    
    void Start()
    {
        StartCoroutine(Enemies());
    }

    public IEnumerator Enemies ()
    {
        while (waveSize > 0)
        {
            Vector3 pos = spawnPoint.position;
            Instantiate(enemy, pos, Quaternion.identity);
            yield return new WaitForSeconds (0.5f);
            waveSize--;
            //Crée x ennemis où x est la taille de la vague
        }
    }

}
