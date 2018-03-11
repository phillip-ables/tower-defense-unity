using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;  //equals nothing until we tell it what turret to build

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

}
