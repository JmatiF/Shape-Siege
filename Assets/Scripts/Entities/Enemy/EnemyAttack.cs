using UnityEngine;
using static EnemyActions;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttack : MonoBehaviour
{
    private Entity selfEntity;

    private void Awake()
    {
        selfEntity = GetComponent<Entity>();
    }
    public void Attack(EnemyType enemyType, Entity entity)
    {
        if (enemyType == EnemyType.Melee)
        {
            MeleeAttack(entity);
        }
    }

    private void MeleeAttack(Entity target)
    {
        float selfDamage = selfEntity.GetDamage();
        target.TakeDamage(selfDamage);
    }
}
