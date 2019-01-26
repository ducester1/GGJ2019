using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    Transform playerTransform;

    float walkingVelocity = 0.05f;
    float attackIdleTime = 3.0f;
    float maxAttackDistance = 2.0f;

    // AnimationStates
    // walkState   == 0 || 1 || 2  (idle, walking, running)
    // attackState == 0 || 1 || 2 || 3 || 4 (none, kick, punch123...)
    // walkStates can only be activated if attack state is 0

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetInteger("walkState", 1);
        this.animator.SetInteger("attackState", 0);

        this.playerTransform = PlayerController.Instance.transform;

        StartCoroutine(this.Attack());
    }

    private void Update()
    {
        // Player can execute movement
        if (this.animator.GetInteger("attackState") == 0)
        {
            //this.transform.Translate(this.transform.forward * -0.01f);
            this.MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            PlayerController.Instance.transform.position,
            this.walkingVelocity
            );

        this.transform.LookAt(PlayerController.Instance.transform);

        //this.transform.eulerAngles.Set(
        //    -90,
        //    this.transform.eulerAngles.y,
        //    0
        //);


        /*
        this.transform.eulerAngles.Set(
            this.transform.eulerAngles.x,
            -this.getAngle(
                new Vector2(this.transform.position.x, this.transform.position.z),
                new Vector2(PlayerController.Instance.transform.position.x, PlayerController.Instance.transform.position.z)
                ),
            this.transform.eulerAngles.z
        );
        */

        //Vector2 fromVector2 = new Vector2(0, 1);
        //Vector2 toVector2 = new Vector2(-1, 0);

        //float ang = Vector2.Angle(fromVector2, toVector2);
        //Vector3 cross = Vector3.Cross(fromVector2, toVector2);

        //if (cross.z > 0)
        //ang = 360 - ang;


        // Rotate towards player using Y-axis
        //var lookPos = PlayerController.Instance.transform.position - this.transform.position;
        //lookPos.x = -90;
        //var rotation = Quaternion.LookRotation(lookPos);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 0.1f);
        //this.transform.R
    }

    IEnumerator Attack()
    {
        for (;;)
        {
            if (this.IsInPlayerRange(this.maxAttackDistance))
            {
                this.animator.SetInteger("walkState", 0);
                this.DoAttack();
            }
            yield return new WaitForSeconds(this.attackIdleTime);
        }
    }

    bool IsInPlayerRange(float maxDistance)
    {
        return Vector3.Distance(
            this.gameObject.transform.position,
            PlayerController.Instance.transform.position
            ) < Mathf.Abs(maxDistance);
    }

    void DoAttack()
    {
        Debug.Log("Attacking the player!!!");
        this.animator.SetInteger("attackState", Random.Range(1,5));

    }

    float getAngle(Vector2 a, Vector2 b)
    {
        var an = a.normalized;
        var bn = b.normalized;
        var x = an.x * bn.x + an.y * bn.y;
        var y = an.y * bn.x - an.x * bn.y;
        return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    }
}
