using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask mask;
    public Transform detector;
    public Camera fpsCam;
    public ParticleSystem particles;
    public int damage = 5;
    public int gunDamage = 10;
    public float gunRange = 100000f;
    Vector3 pos;
    public float radius = 0.4f;
    Collider[] hit;

    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            pos = detector.position;
            hit = Physics.OverlapSphere(pos, radius, mask); //Récupère tous les ennemis présents dans le rayon d'attaque
            foreach(var enemies in hit)
            {
                enemies.GetComponent<Target>().TakeDamage(damage); //Applique des dégâts aux ennemis dans le tableau
            }
        }
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit _hit;
            if(!particles.isPlaying)
            {
                particles.Play();
            }
            if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out _hit, gunRange,mask))
            {
                Target target = _hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.GetComponent<Target>().TakeDamage(gunDamage);
                }
                
            }
        }

    }
}
