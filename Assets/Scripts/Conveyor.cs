using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private bool activated;
    private int shootCooldown;
    [SerializeField] private GameObject[] nodes;
    private int nextNode;
    [SerializeField] private GameObject regLog;
    [SerializeField] private GameObject bombLog;
    [SerializeField] private float launchSpeed;
    private Vector3 queueDir;
    private GameObject queueLog = null;
    private Vector3 readyDir;
    private GameObject readyLog = null;

    // Start is called before the first frame update
    void Start()
    {
        nextNode = 0;
        activated = false;
        shootCooldown = 130;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!activated)
            return;
        
        if(shootCooldown == 0){
            float randResult = Random.value;
            Ready(nextNode, randResult);
            if(nextNode < nodes.Length-1)
                nextNode++;
            else
                nextNode = 0;
        }
        shootCooldown--;
    }

    public void activate() {
        transform.Translate(4, 0, 0);
        activated = true;
    }

    private void Ready(int index, float logType) {
        Vector3 pos = transform.position;
        pos.Set(pos.x, pos.y+2, pos.z);

        Shoot();

        if(logType > 0.7) {
            // Create new log at end of queue
            queueLog = Instantiate(bombLog, pos, transform.rotation);
            queueDir = (nodes[index].transform.position - pos);
            queueDir.y = 0;
            queueDir = queueDir.normalized * launchSpeed;
        }
        else {
            queueLog = Instantiate(regLog, pos, transform.rotation);
            queueDir = (nodes[index].transform.position - pos);
            queueDir.y = 0;
            queueDir = queueDir.normalized * launchSpeed;
        }
        shootCooldown = 160;
    }

    private void Shoot() {
        if(readyLog != null) {
            Rigidbody r = readyLog.GetComponent<Rigidbody>();
            r.transform.Translate(-4, -2, -4);
            print("log ready to shoot" + readyDir);
            r.AddForce(readyDir, ForceMode.VelocityChange);
            r.constraints = RigidbodyConstraints.FreezePositionY;
            r.AddTorque(Vector3.Cross(Vector3.up, readyDir), ForceMode.VelocityChange);

        }

        if(queueLog != null) {
            readyLog = queueLog;
            readyDir = queueDir;
            readyLog.transform.Translate(3, 0, 0);
        }
    }
}
