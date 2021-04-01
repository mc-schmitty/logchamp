using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermodel : MonoBehaviour
{
    private Vector3 randPos;
    private Quaternion randRot;
    private bool doExplode = false;

    // Start is called before the first frame update
    void Start()
    {
        randPos = new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.001f, 0.05f), Random.Range(-0.05f, 0.05f));
        randRot = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(doExplode)
            transform.SetPositionAndRotation(transform.position + randPos, transform.rotation * randRot);
    }

    public void Explode()
    {
        doExplode = true;
    }
}
