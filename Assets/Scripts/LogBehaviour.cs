using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private Rigidbody logTop;
    
    [SerializeField] private float LaunchSpeed;
    [SerializeField] private float ReflectSpeed;


    private Rigidbody rigidBodyComponent;

    bool QueueLaunch = false;
    Vector3 AxeHitPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerStay(Collider treeCollider)
    {
        //Debug.Log("colliding");
        if(treeCollider.CompareTag("Launchable")) {
            //treeCollider.GetComponent<LogBehaviour>().AxeHit(rigidBodyComponent);
            AxeHit(treeCollider.GetComponent<Rigidbody>());
        }
        else if(treeCollider.CompareTag("Cabin")) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if(rigidBodyComponent.constraints != RigidbodyConstraints.FreezeAll && rigidBodyComponent.velocity.magnitude < 3.5f) {
            Destroy(gameObject);
        }

        if(QueueLaunch) {
            QueueLaunch = false;
            //unfreeze tree
            rigidBodyComponent.constraints = RigidbodyConstraints.FreezePositionY;
            logTop.constraints = RigidbodyConstraints.None;


            //force bottom part of tree
            Vector3 launchForceVec = rigidBodyComponent.position - AxeHitPosition;
            launchForceVec.y = 0;
            launchForceVec = launchForceVec.normalized * LaunchSpeed;

            rigidBodyComponent.AddForce(launchForceVec, ForceMode.VelocityChange);
            rigidBodyComponent.AddTorque(Vector3.Cross(Vector3.up,launchForceVec), ForceMode.VelocityChange);
            logTop.AddForce(-launchForceVec, ForceMode.Impulse);
        }

        
    }

    public void AxeHit(Rigidbody otherBody)
    {
        health--;
        //Debug.Log(health);
        if(health > 0) {
            // Particle effects, health update
        }
        else if(health == 0) {
            // Freeing hit, launch self+log  
            QueueLaunch = true;
            AxeHitPosition = otherBody.position;
        }
        else if(health < 0) {

            if(otherBody.CompareTag("Player")) {
                rigidBodyComponent.velocity = new Vector3(rigidBodyComponent.velocity.x, 0, -(rigidBodyComponent.velocity.z)) * ReflectSpeed;
            }
            else if(rigidBodyComponent.constraints != RigidbodyConstraints.FreezeAll) {
                Destroy(gameObject);
            }
            else {
                health++;
            }
        }
    }
}
