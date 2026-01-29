using UnityEngine;

public class Entity : MonoBehaviour
{

    private Rigidbody2D body;

    [SerializeField]
    private float life = 10f;

    [SerializeField]
    private float damage = 1f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
            Die();
    }

    public float GetDamage()
    {
        return damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
