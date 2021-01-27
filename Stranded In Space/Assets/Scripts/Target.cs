using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int lifePoints = 25;

    public void TakeDamage(int damage)
    {
        lifePoints -= damage;

        if(lifePoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
