using UnityEngine;

public class Shop : MonoBehaviour {  

    public void PurchaseStandardTurret ()  // called from our ui element becasue we have it public, build manager, turret, money, ui things (removing or closing down shop until you have placed a turret)
    {
        Debug.Log("Standard Turret Purchased");
    }
    public void PurchaseAnotherStandardTurret()  // called from our ui element becasue we have it public, build manager, turret, money, ui things (removing or closing down shop until you have placed a turret)
    {
        Debug.Log("Another Turret Purchased");
    }

}
