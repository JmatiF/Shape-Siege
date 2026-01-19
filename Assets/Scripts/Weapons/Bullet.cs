using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(10, 40)]
    [SerializeField] private float speed = 25f;

    [Range(1,10)]
    [SerializeField] private float lifeTime = 5f;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        body.linearVelocity = transform.up * speed;
    }
}
