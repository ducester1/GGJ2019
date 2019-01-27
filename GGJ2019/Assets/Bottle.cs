using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private float minHeight;
    private bool respawned;
    public Vector3 initPos;
    public Quaternion initRot;

    // Start is called before the first frame update
    void Start()
    {
        respawned = false;
        minHeight = 0.3f;
        initPos = this.transform.position;
        initRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < minHeight && respawned == false)
        {
            spawn();
        }
    }

    public void spawn()
    {
        respawned = true;
        Instantiate(this, initPos, initRot);
        Destroy(gameObject, 5);
    }
}
