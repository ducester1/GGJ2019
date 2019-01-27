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
            //rb.isKinematic = newValue;
        }
    }
    void SetColliders(bool newValue)
    {
        BoxCollider[] boxes = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider bc in boxes)
        {
            bc.enabled = newValue;
        }
        CapsuleCollider[] caps = GetComponentsInChildren<CapsuleCollider>();
        foreach (CapsuleCollider cc in caps)
        {
            cc.enabled = newValue;
        }
        SphereCollider[] spheres = GetComponentsInChildren<SphereCollider>();
        foreach (SphereCollider sc in spheres)
        {
            sc.enabled = newValue;
        }
        GetComponent<CapsuleCollider>().enabled = true;
    }
    private void Update()
    {
        if (hp <= 0) Die();
    }
    void Start()
    {
        //SetKinematic(true);
        SetColliders(false);
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
        //SetKinematic(false);
        SetColliders(true);
        GetComponent<Animator>().enabled = false;
        //GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 20);
    }

}
