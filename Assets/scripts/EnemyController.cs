using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    Movement enemyMovement;

    public Vector3 begin;
    public Vector3 end;

    bool beginning;
    void Awake()
    {
        enemyMovement = GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        if (beginning)
        {
            enemyMovement.UpdateMovement(begin - transform.position);
            if ((transform.position - begin).magnitude < 2)
                beginning = false;
        }
        else
        {
            enemyMovement.UpdateMovement(end - transform.position);
            if ((transform.position - end).magnitude < 2)
                beginning = true;
        }
    }

    public Movement Possess()
    {
        this.enabled = false;
        return enemyMovement;
    }

    public void Release()
    {
        this.enabled = true;
    }
}