using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody enemy;
    

    void Start()
    {

    }

    void Update()
    {
        enemy.AddForce(100*Time.deltaTime,0,100*Time.deltaTime);
    }
}
