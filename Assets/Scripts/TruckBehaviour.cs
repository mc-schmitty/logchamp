using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    [SerializeField] private bool isCrashed;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        isCrashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drive() {
        GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Stopper"))
            GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.VelocityChange);
        else if(other.CompareTag("Hazard") && !isCrashed)
            Crash();
    }

    // Sink truck into ground
    private void Crash() {
        isCrashed = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<BoxCollider>().enabled = false;
        //Vector3 pos = transform.position;
        //transform.position.Set(pos.x, (pos.y)-6, pos.z);
        transform.Translate(0, -6f, 0);
        
    }
}
