using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(10, 40)]
    [SerializeField] private float speed = 25f;

    [Range(1,10)]
    [SerializeField] private float lifeTime = 5f;

    [SerializeField]
    private float damage = 1f;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<Entity>(out var entity))
        {
            entity.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        body.linearVelocity = transform.up * speed;
    }

}
