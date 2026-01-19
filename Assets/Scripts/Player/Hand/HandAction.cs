using UnityEngine;
using UnityEngine.InputSystem;

public class HandAction : MonoBehaviour
{
    [SerializeField]
    private GameObject inHand;

    void Update()
    {
        if (inHand != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            
            WeaponLeftMouse();
        }
    }

    void WeaponLeftMouse()
    {
        var weapon = inHand.GetComponent<Weapon>();

        if (weapon != null)
        {
            weapon.LeftMouse();
        }
    }
}
