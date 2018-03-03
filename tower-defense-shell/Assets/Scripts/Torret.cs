using UnityEngine;
//finding a target(within a range and the nearest target) -> then rotating to aim at the target
public class Torret : MonoBehaviour {
    public Transform target; //store current target in a private variable
    public float range = 15f;

    public string enemyTag = "Enemy";

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
    }

    void Update()
    {
        if (target == null) //if no target, dont do a thing
            return;


    }
    //have unity display the range using gizmo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
