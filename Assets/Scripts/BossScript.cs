using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private int frame;
    [SerializeField] Rigidbody player;
    [SerializeField] GameObject poordude;
    [SerializeField] Rigidbody logperatve;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        ActivateTiming();
        frame++;
    }

    // Manages timed events, basically bootleg timeline 
    private void ActivateTiming()
    {
        switch (frame)
        {
            case 90:
                FakeTarget[] fList = GetComponentsInChildren<FakeTarget>();
                for(int n = 0; n < fList.Length; n++) {
                    fList[n].dropFake();
                }
                print("Dropping Fake Targets");
                break;
            case 120: 
                GetComponentInChildren<TruckBehaviour>().Drive();
                print("Driving truck");
                break;
            case 580:
                GameObject.Destroy(poordude);
                print("Killed blue guy");
                break;
            case 641:
                logperatve.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                print("Log Operative Unleashed");
                break;
            case 800:
                GetComponentInChildren<Conveyor>().activate();
                print("Start extending the conveyor");
                break;
            case 960:
                player.constraints = RigidbodyConstraints.FreezeRotation;
                print("Unfroze Player");
                break;
            case 1020:
                HammerManager[] h = GetComponentsInChildren<HammerManager>();
                for(int n = 0; n < h.Length; n++){
                    h[n].raiseUp();
                }
                print("Hammers Raised");
                break;
            default:
                print(frame);
                break;      // Break not needed but now its not red so
        }
    }
}
