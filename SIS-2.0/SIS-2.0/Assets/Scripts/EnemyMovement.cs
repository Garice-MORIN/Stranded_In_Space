using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMesh = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        navMesh.destination = goal.position;
    }
}
