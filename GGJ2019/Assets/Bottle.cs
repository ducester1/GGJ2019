using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public Vector3 initPos;
    public Quaternion initRot;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        initRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn()
    {
        Instantiate(this, initPos, initRot);
    }

    public void pickUp()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
}
