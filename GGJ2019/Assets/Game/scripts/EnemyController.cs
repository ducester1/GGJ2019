using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    Transform playerTransform;

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
            this.transform.Translate(this.transform.forward * -0.01f);
        }
    }

    IEnumerator Attack()
    {
        for (;;)
        {
            if (this.IsInPlayerRange(this.maxAttackDistance))
            {
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
}
