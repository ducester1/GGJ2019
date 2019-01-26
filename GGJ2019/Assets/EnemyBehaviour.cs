using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f) ;
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
