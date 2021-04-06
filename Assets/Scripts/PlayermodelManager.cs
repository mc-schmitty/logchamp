using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayermodelManager : MonoBehaviour
{
    public int iFrames;
    private bool isSwing;

    AudioSource DeathSFX;
    bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        iFrames = 0;
        isSwing = false;
        DeathSFX = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //Debug.Log(iFrames);
        iFrames = Mathf.Max(iFrames-1, 0);

        // Swing axe if true, otherwise update and return axe to regular position
        if(isSwing) {
            transform.Rotate(0, -8, 0);
            //isSwing = false;

            // Check if past rotation
            //print(transform.rotation.eulerAngles.y);
            if(transform.rotation.eulerAngles.y <= 240)
                isSwing = false;
        }
        else if(transform.rotation.eulerAngles.y >= 232 ) {
            //print(transform.rotation.eulerAngles.y);
            transform.Rotate(0, 1.8f, 0);
        }
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log("Collision!");
        if(other.CompareTag("Hazard") && iFrames == 0 && other.GetComponent<Rigidbody>().velocity.magnitude > 1.5f && !exploded) {
            //Debug.Log("Exploding rn");
            this.ExplodeAll();
            exploded = true;
        }
    }

    public void SwingAxe()
    {
        isSwing = true;
    }

    public void ExplodeAll() 
    {
        Playermodel[] pList = gameObject.GetComponentsInChildren<Playermodel>();
        for(int n=0; n < pList.Length; n++) {
            pList[n].Explode();
        }
        GetComponentInParent<Player>().Die();
        WinCon _winCon = GameObject.FindObjectOfType<WinCon>();
        DeathSFX.Play();
        _winCon.PlayerDeath();
    }
}
