using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public LayerMask mask;
    public Transform enemyPosition;
    public int damage;
    Collider[] colliders;
    Transform goal;
    float cooldown = 1;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent navMesh = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Tower").transform;
        navMesh.destination = goal.position;
    }

    public void Update()
    {
        if(cooldown <= 0)
        {
            AttackTower();
            cooldown = 1;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void AttackTower()
    {
        colliders = Physics.OverlapSphere(enemyPosition.position, 2.0f, mask);
        foreach(var obj in colliders)
        {
            obj.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
