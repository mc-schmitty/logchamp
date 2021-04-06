using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSlammer : MonoBehaviour
{
    [SerializeField] Rigidbody hammerhead; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slammer(){
        float dir = transform.position.x;
        hammerhead.AddForce(new Vector3(dir, 0, 0)*100000, ForceMode.Force);
    }
}
