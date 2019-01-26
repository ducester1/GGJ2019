using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private const int MAX_HEALTH = 3 ;
    public int health;
    public Image damageHud;
    void Start()
    {
        health = MAX_HEALTH;
        var tempColor = damageHud.color;
        tempColor.a = 0f;
        damageHud.color = tempColor;
    }

    // Update is called once per frame
    public void Update()
    {
        if( health <= MAX_HEALTH / 3)
        {
            var tempColor = damageHud.color;
            tempColor.a = 1f;
            damageHud.color = tempColor;


        }
        if (health <= 0)
        {
            print("GameOver");
        }
    }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "badStuff")
        {
            print("Taking damage");
            TakeDamage(1);

        }
    }
}
