using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't Build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (Instantiate(turretToBuild, transform.position, transform.rotation));


    }

    void OnMouseEnter() // built in unity callback like update
    {
        //everytime the mouse enters the collider
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
