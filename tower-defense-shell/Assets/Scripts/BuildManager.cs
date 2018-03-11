using UnityEngine;

public class BuildManager : MonoBehaviour {

    //simplified singleton pattern, only one instance of the build manager in the scene
    public static BuildManager instance;  // a build manager inside the build manager, a reference to the instance of the build manager

    void Awake()
    {
        if ( instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;  //equals nothing until we tell it what turret to build

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

}
