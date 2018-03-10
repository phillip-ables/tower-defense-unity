using UnityEngine;
//finding a target(within a range and the nearest target) -> then rotating to aim at the target
public class Torret : MonoBehaviour {
    private Transform target; //store current target in a private variable
    public float range = 15f;
    public float fireRate = 1f; // we will fire one
    private float fireCountdown = 0f;  //after we fire on it will be set to one divided by fireRate


    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() //we dont want to do this every frame
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);//search all objects marked enemy and checking the closest one in range
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null) //if no target, dont do a thing
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);

        if (fireCountdown <= 0f)  //if time to shoot
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        Debug.Log("Shoot!");
    }

    //have unity display the range using gizmo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
