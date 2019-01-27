using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private bool once;
    private float minHeight;
    private GameObject player;

    public Vector3 initPos;
    public Quaternion initRot;
    public GameObject asset;

    void Start()
    {
        once = false;
        player = GameObject.Find("Player");
        minHeight = 0.3f;
        initPos = this.transform.position;
        initRot = this.transform.rotation;
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if (this.transform.position.y < minHeight && Vector3.Distance(player.transform.position, transform.position) > 1.5 && !once)
        {
            once = true;
            Instantiate(asset, initPos, initRot);
            Destroy(gameObject, 3);
        }
    }
}
