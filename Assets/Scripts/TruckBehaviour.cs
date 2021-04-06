using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    [SerializeField] private bool isCrashed;
    [SerializeField] private float speed;

    AudioSource[] truckSounds;

    // Start is called before the first frame update
    void Start()
    {
        isCrashed = false;
        truckSounds = GetComponentsInChildren<AudioSource>();
    }

    public void Drive() {
        GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.VelocityChange);
        truckSounds[0].Play();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Stopper"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.VelocityChange);
            
        }

        else if (other.CompareTag("Hazard") && !isCrashed)
        {
            Crash();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == 10)
        {
            truckSounds[1].Play();
            truckSounds[2].Play();
        }
    }

    // Sink truck into ground
    private void Crash() {
        truckSounds[3].Play();
        isCrashed = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<BoxCollider>().enabled = false;
        //Vector3 pos = transform.position;
        //transform.position.Set(pos.x, (pos.y)-6, pos.z);
        transform.Translate(0, -6f, 0);
        
    }
}
