using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField]
    private float life = 10f;

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
