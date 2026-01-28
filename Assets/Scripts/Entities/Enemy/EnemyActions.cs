using System.Security.Principal;
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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Entity>(out var entity))
        {
            enemyAttack.Attack(enemyType, entity);
            
        }

    }

}
