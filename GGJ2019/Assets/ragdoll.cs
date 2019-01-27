using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    public int maxHp = 10;
    public int hp;
    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }
    private void Update()
    {
        if (hp <= 0) Die();
    }
    void Start()
    {
        SetKinematic(true);
        hp = maxHp;
    }
    public void Damage(int damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        if (hp <= 0) Die();
    }
    void Die()
    {
        SetKinematic(false);
        GetComponent<Animator>().enabled = false;
        //GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 20);
    }
}
