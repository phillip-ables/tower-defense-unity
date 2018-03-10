using UnityEngine;

public class Bullet : MonoBehaviour {
    //first this bullet needs a target
    //pass on the target from the turret
    private Transform target;

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
    }
}
