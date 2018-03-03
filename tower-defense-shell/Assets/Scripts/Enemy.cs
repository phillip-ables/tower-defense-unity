using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;

    private Transform target; //some type of target only set in this script
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0]; //referencing our points because its static
    }

    private void Update()  // every update we want to move a little closer to that target
    {
        Vector3 dir = target.position - transform.position;//current position to target position 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


    }
}
