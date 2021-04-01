using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("colliding");
        if(other.CompareTag("Launchable")) {
            LaunchSelf();
        }
    }

    // Launches head and disables the triggerbox
    public void LaunchSelf() 
    {
        //GetComponent<BoxCollider>().enabled = false;
        gameObject.layer = 8;
        GetComponentInParent<TargetBase>().LoseHead();
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.WakeUp();
        rigid.AddForce(new Vector3(Random.Range(-1f, 1f), 19.5f, Random.Range(-1f, 1f)), ForceMode.Impulse);
        rigid.AddTorque(new Vector3(Random.value, Random.value, Random.value), ForceMode.Impulse);
    }
}
