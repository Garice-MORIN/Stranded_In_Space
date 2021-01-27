using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody enemy;
    public int lifePoints = 25;
    public GameObject game_object;

    void Update()
    {
        //enemy.AddForce(200*Time.deltaTime,0,100*Time.deltaTime);
    }

}
