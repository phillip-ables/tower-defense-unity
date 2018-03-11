using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
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
