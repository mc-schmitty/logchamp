using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTarget : MonoBehaviour
{
    private int dropframes;

    // Start is called before the first frame update
    void Start()
    {
        dropframes = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(dropframes > 0) {
            dropframes--;
        }
        else if(dropframes == 0) {
            Rigidbody.Destroy(gameObject);
        }
    }

    public void dropFake() {
        dropframes = 60;
        Rigidbody r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.None;
        r.AddForce(new Vector3(0, 20, -4), ForceMode.VelocityChange);
    }
}
