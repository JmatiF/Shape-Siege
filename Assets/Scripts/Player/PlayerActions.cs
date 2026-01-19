using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private GameObject inHand;

    void Update()
    {
        if (inHand != null && Mouse.current.leftButton.isPressed)
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
