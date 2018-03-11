using UnityEngine;

public class Bullet : MonoBehaviour {
    //first this bullet needs a target
    //pass on the target from the turret
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)  // weve hit something, hit before we moce passed the target
        {
            HitTarget();
            return;
        }

        //we havent hit our target so we want to move
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // not local space which causes wierd oliptical pattern
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);  // create some hit particals
    }
}
