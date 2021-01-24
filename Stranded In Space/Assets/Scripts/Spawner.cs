using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;
    public int waveSize;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemies());
    }

    IEnumerator Enemies ()
    {
        while (waveSize > 0)
        {
            Vector3 pos = spawnPoint.position;
            Instantiate(enemy, pos, Quaternion.identity);
            yield return new WaitForSeconds (0.5f);
            waveSize--;
        }
    }
}
