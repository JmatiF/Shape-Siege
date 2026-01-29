using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public enum EnemyType
    {
        Melee,
        Ranged,
        Hybrid
    }

    [SerializeField]
    private EnemyType enemyType = EnemyType.Melee;

    private Collider2D rangeCollider;
    private EnemyAttack enemyAttack;

    [SerializeField]
    private float attackCooldown = 1.2f;

    private float attackTimer = 0f;

    void Awake()
    {
        Transform range = transform.Find("RangeAttack");
        enemyAttack = GetComponent<EnemyAttack>();

        if (range != null)
        {
            rangeCollider = range.GetComponent<Collider2D>();
            
        }
        else
        {
            Debug.LogWarning("RangeAttack: Not found", this);
        }

        attackTimer = 0f;
    }

    bool CanAttack()
    {
        attackTimer -= Time.deltaTime;
        return attackTimer <= 0f;
    }

    void ResetAttackTimer()
    {
        attackTimer = attackCooldown;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Entity>(out var entity))
            return;

        if (!CanAttack())
            return;

        enemyAttack.Attack(enemyType, entity);
        ResetAttackTimer();
    }

}
