using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float distanceToPlayer;
    private GameObject player;
    public GameObject breakEffect;
    [SerializeField]
    private float hitBoxDistance;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
         playerHealth = player.GetComponent<Health>();
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        print("Distance to other: " + distanceToPlayer);
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        print("Distance to other: " + distanceToPlayer);

        if(distanceToPlayer <= hitBoxDistance)
        {
            Instantiate(breakEffect, transform.position,transform.rotation);
            playerHealth.TakeDamage(1);

            Destroy(gameObject);
        }

    }
}
