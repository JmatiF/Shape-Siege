using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Vector2 mousePos;
   
    public float speed = 5f;

    
    private Rigidbody2D body;


    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        // Movement
        Movement();

        // Rotation
        Rotation();

    }


    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 dirrection = new Vector2(xInput, yInput).normalized;

        body.linearVelocity = dirrection * speed;
    }

    void Rotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) 
            * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
