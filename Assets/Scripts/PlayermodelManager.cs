using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayermodelManager : MonoBehaviour
{
    public int iFrames;

    // Start is called before the first frame update
    void Start()
    {
        iFrames = 0;
    }

    private void FixedUpdate()
    {
        //Debug.Log(iFrames);
        iFrames = Mathf.Max(iFrames-1, 0);
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log("Collision!");
        if(other.CompareTag("Hazard") && iFrames == 0 && other.GetComponent<Rigidbody>().velocity.magnitude > 2.5f) {
            //Debug.Log("Exploding rn");
            this.ExplodeAll();
        }
    }

    public void ExplodeAll() 
    {
        Playermodel[] pList = gameObject.GetComponentsInChildren<Playermodel>();
        for(int n=0; n < pList.Length; n++) {
            pList[n].Explode();
        }
        GetComponentInParent<Player>().Die();
        WinCon _winCon = GameObject.FindObjectOfType<WinCon>();
        _winCon.PlayerDeath();
    }
}
