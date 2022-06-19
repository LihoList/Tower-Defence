
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform target;
    int waypointIndex = 0;

    Enemy enemyScript;

    private void Start()
    {
        enemyScript = GetComponent<Enemy>();

        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position; //direction vector
        transform.Translate(direction.normalized * enemyScript.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemyScript.speed = enemyScript.startSpeed;

    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            EndWay();
            return;
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }

    void EndWay()
    {
        PlayerStats.lives--;

        Destroy(gameObject);
    }
}
