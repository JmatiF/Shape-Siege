using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform playerBody; // Player transform

    private float angle;
    private Vector2 lookDir;

    private bool isRightSide;
    private bool lastSide;

    void Update()
    {
        HandleQuadrants();
        GetPosAngle();
        SetPosAngle();

    }
    void HandleQuadrants()
    {
        isRightSide = angle >= -90f && angle <= 90f;

        if (isRightSide != lastSide)
        {
            ChangeBodySide();
            ChangeHandSide();

            lastSide = isRightSide;
        }
    }
    void GetPosAngle()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        lookDir = mouseWorldPos - (Vector2)playerBody.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    }

    void SetPosAngle()
    {
        // rotation of the hand

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // and stay in the same position
        transform.position = playerBody.position + (Vector3)(lookDir.normalized * Vector3.Distance(transform.position, playerBody.position));

    }

    void ChangeBodySide()
    {
        Vector3 scale = playerBody.localScale;

        scale.x = isRightSide ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

        playerBody.localScale = scale;
    }
    void ChangeHandSide()
    {
        Vector3 scale = transform.localScale;
        scale.x = isRightSide ? 1f : -1f; // To match the Player sclae 
        scale.y = isRightSide ? 1f : -1f; // To change the Hand scale 
        transform.localScale = scale;
    }


}
