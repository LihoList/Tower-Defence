
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public GameObject bulletEffetPrefab;

    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject bulletEffect = (GameObject)Instantiate(bulletEffetPrefab, transform.position, transform.rotation);
        Destroy(bulletEffect, 2f);
        Destroy(gameObject);

        if (explosionRadius > 0) //if bullet has splash effect - damage several targets
        {
            Explode();
        }
        else
        {
            DamageEnemy(target);
        }

    }

    void Explode()
    {
        Collider[] impactColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in impactColliders)
        {
            if (collider.tag == "Enemy")
            {
                DamageEnemy(collider.transform);
            }
        }
    }

    void DamageEnemy(Transform enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}