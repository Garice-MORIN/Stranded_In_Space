using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask mask;
    public Transform detector;
    public int damage = 5;
    Vector3 pos;
    public float radius = 0.4f;
    Collider[] hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            pos = detector.position;
            hit = Physics.OverlapSphere(pos, radius, mask); //Récupère tous les ennemis présents dans le rayon d'attaque
            foreach(var enemies in hit)
            {
                enemies.GetComponent<EnemyMovement>().TakeDamage(damage); //Applique des dégâts aux ennemis dans le tableau
            }
        }

    }
}
