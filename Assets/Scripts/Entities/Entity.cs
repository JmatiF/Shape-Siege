using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField]
    private float life = 10f;

    [SerializeField]
    private float damage = 1f;

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
    }

    public float getDamage()
    {
        return damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
