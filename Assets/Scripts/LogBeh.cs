using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBeh : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private Rigidbody logTop;
    
    [SerializeField] private float LaunchSpeed;
    [SerializeField] private float ReflectSpeed;


    private Rigidbody rigidBodyComponent;

    TreeMiddleman treeCountNotifier;

    bool QueueLaunch = false;
    Vector3 AxeHitPosition;

    AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        treeCountNotifier = GetComponentInParent<TreeMiddleman>();
        sfx = GetComponent<AudioSource>();
        sfx.pitch = (Random.Range(0.5f, 1.2f));
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
            print("AFK log destroyed");
            //Destroy(gameObject);
        }

        if(QueueLaunch) {
            QueueLaunch = false;
            //unfreeze tree
            rigidBodyComponent.constraints = RigidbodyConstraints.FreezePositionY;
            if(logTop)
                logTop.constraints = RigidbodyConstraints.None;


            //force bottom part of tree
            Vector3 launchForceVec = rigidBodyComponent.position - AxeHitPosition;
            launchForceVec.y = 0;
            launchForceVec = launchForceVec.normalized * LaunchSpeed;

            rigidBodyComponent.AddForce(launchForceVec, ForceMode.VelocityChange);
            rigidBodyComponent.AddTorque(Vector3.Cross(Vector3.up,launchForceVec), ForceMode.VelocityChange);
            if(logTop)
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
            //Inform the manager that a new tree was chopped down
            treeCountNotifier.Chop();
            sfx.Play();
        }
        else if(health < 0) {

            if(otherBody.CompareTag("Player")) {
                //rigidBodyComponent.velocity = new Vector3(rigidBodyComponent.velocity.x, 0, -(rigidBodyComponent.velocity.z)) * ReflectSpeed;
                // reflect now same as launch
                Vector3 launchForceVec = rigidBodyComponent.position - AxeHitPosition;
                launchForceVec.y = 0;
                rigidBodyComponent.velocity = launchForceVec.normalized * rigidBodyComponent.velocity.magnitude * ReflectSpeed;
                
            }
            else if(rigidBodyComponent.constraints != RigidbodyConstraints.FreezeAll) {
                print("Death by low health");
                Destroy(gameObject);
            }
            else {
                health++;
            }
        }
    }
}

