using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCode : MonoBehaviour
{
    private bool process;

    // Start is called before the first frame update
    void Start()
    {
        process = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Launchable") && process) {
            process = false;
            GetComponentInParent<HammerManager>().UpgradeHammer(gameObject);
        }
    }
}
