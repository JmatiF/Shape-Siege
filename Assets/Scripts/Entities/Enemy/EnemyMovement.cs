using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform target;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float rotateSpeed = 5f;

    private Rigidbody2D body;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!target)
        {
            GetTarget(); 
        }
        else
        {
            RotateToTarget();
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        body.linearVelocity = transform.up * speed;
    }

    void RotateToTarget()
    {
        Vector2 targetDirr = target.position - transform.position;

        float angle = Mathf.Atan2(targetDirr.y, targetDirr.x) * Mathf.Rad2Deg
            - 90f;

        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

    }

    void GetTarget()
    {
        if ( GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
