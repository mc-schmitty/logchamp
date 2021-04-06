using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollisionCheck : MonoBehaviour
{

    Rigidbody rigidbodyComponent;
    LineRenderer lineDraw;
    bool drawLine = true;
    private int axeKeyBuffer;
    private int axeCooldown;

    [SerializeField] private float AimLineLength = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        lineDraw = GetComponent<LineRenderer>();
        axeCooldown = 0;
        
    }

    void OnTriggerStay(Collider treeCollider)
    {
        //Debug.Log("colliding");
        if(treeCollider.CompareTag("Launchable")) {
            LogBehaviour checkLog = treeCollider.GetComponent<LogBehaviour>();
            if(checkLog) {
                // Draw line from tree
                if(checkLog.health > 0 && drawLine) {
                    drawLine = false;       // Only deals with the first collision
                    //Vector3 tempV = new Vector3(3*(treeCollider.transform.position.x - transform.position.x) + transform.position.x, transform.position.y, 3*(treeCollider.transform.position.z - transform.position.z) + transform.position.z);
                    Vector3 lineOffset = treeCollider.transform.position - transform.position;
                    lineOffset.y = 0;
                    lineOffset = lineOffset.normalized * AimLineLength;

                    lineDraw.SetPosition(0, treeCollider.transform.position);
                    lineDraw.SetPosition(1, treeCollider.transform.position + lineOffset);
                }
                // Draw line from incoming log
                else if(drawLine) {
                    drawLine = false;       // Only deals with the first collision
                    Vector3 lineOffset = treeCollider.transform.position - transform.position;
                    lineOffset.y = 0;
                    lineOffset = lineOffset.normalized * AimLineLength;

                    lineDraw.SetPosition(0, treeCollider.transform.position);
                    lineDraw.SetPosition(1, treeCollider.transform.position + lineOffset);
                }
                if(axeKeyBuffer > 0) {  // Launch log
                    checkLog.AxeHit(rigidbodyComponent);
                    // Brief invuln from falling trees

                    GetComponentInChildren<PlayermodelManager>().iFrames = 60;
                }
            }
            else if(treeCollider.GetComponent<Target>() && axeKeyBuffer > 0) {
                // Launch Target
                treeCollider.GetComponent<Target>().LaunchSelf();
            }
            axeKeyBuffer = 0;
        }
    }

    /*private void OnTriggerExit(Collider other) {
        lineDraw.SetPosition(0, Vector3.zero);
        lineDraw.SetPosition(1, Vector3.zero);
    }*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && axeCooldown == 0) {
            axeKeyBuffer = 7;
            axeCooldown = 60;
            GetComponentInChildren<PlayermodelManager>().SwingAxe();
        }
    }

    private void FixedUpdate() {
        lineDraw.SetPosition(0, Vector3.zero);
        lineDraw.SetPosition(1, Vector3.zero);
        drawLine = true;
        axeKeyBuffer = Mathf.Max(axeKeyBuffer-1, 0);
        axeCooldown = Mathf.Max(axeCooldown-1, 0);
        
    }
}
