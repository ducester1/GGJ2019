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

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Weapon")
        {
            Damage(1);
            AudioSource sound = collisionInfo.gameObject.GetComponent<AudioSource>();
            sound.PlayOneShot(sound.clip);
        }
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
        Destroy(gameObject, 6);
    }

}
