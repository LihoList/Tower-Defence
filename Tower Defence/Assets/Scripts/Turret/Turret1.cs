
using UnityEngine;

public class Turret1 : MonoBehaviour
{
    Transform target;
    Enemy targetEnemy;

    public float range = 15f;

    public string enemyTag_Ground = "Enemy";
    public string enemyTag_Flying = "Flying";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    [Header("For bullets (by default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    float fireCountdown = 0f;

    [Header("For laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public float slowFactor = 0.5f;
    public int damageOverTime = 30;


    public Transform bulletSpawnPoint;

    TurretSound turretSoundScript;
    


    private void Start()
    {
        turretSoundScript = GetComponent<TurretSound>();

        InvokeRepeating("UpdateTarget", 0, 0.5f); //update target every 0.5 sec
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag_Ground); // array of ground targets
        int groundEnemyCount_origin = enemies.Length;

        if(enemyTag_Flying != "None") // if turret attaks flying enemies
        {
            GameObject[] flyingEnemies = GameObject.FindGameObjectsWithTag(enemyTag_Flying);// array of flying targets
            int flyingCount = flyingEnemies.Length;
            int k = 0; //for adding elements to enemies array 
            System.Array.Resize(ref enemies, enemies.Length + flyingCount); //extending enemies array
            for (int i = groundEnemyCount_origin; i < enemies.Length; i++) // adding flying enemeies to enemies array
            {
                enemies[i] = flyingEnemies[k];
                k++;
            }
        }

        float shortestDistamce = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistamce)
            {
                shortestDistamce = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistamce <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    private void Update()
    {
        if(target == null)
        {
            if(useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserEffect.Stop();
                }
                    
            }

            return;
        }

        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        } 
    }

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowFactor);




        //visual stuff
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserEffect.Play();
        }
           
        lineRenderer.SetPosition(0, bulletSpawnPoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 direction = bulletSpawnPoint.position - target.position;
        laserEffect.transform.rotation = Quaternion.LookRotation(direction);
        laserEffect.transform.position = target.position + direction.normalized;
    }

    void Shoot()
    {
        turretSoundScript.PlaySound();

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Bullet bulletScript = bulletGO.GetComponent<Bullet>();
        
        if(bulletScript != null)
        {
            bulletScript.Seek(target);
        }
    }








    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
