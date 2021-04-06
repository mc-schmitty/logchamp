using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    [SerializeField] GameObject[] cabinPrefabs;
    public int hammerVersion;
    int maxCabin;
    private bool isUpgrade = false;
    GameObject prevObj = null;
    [SerializeField] private BossScript bossObject;
    // Start is called before the first frame update
    void Start()
    {
        hammerVersion = 0;
        //Defines the cabin index at which we notify the win con
        maxCabin = cabinPrefabs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(isUpgrade) {
            Vector3 pos = prevObj.transform.position;
            Quaternion rot = prevObj.transform.rotation;
            Destroy(prevObj);
            Instantiate(cabinPrefabs[hammerVersion], pos, rot, transform);
            hammerVersion++;
            isUpgrade = false;
            //Cabin is built! Tell the level win con object.
            if (hammerVersion == maxCabin)
            {
                bossObject.HammerBuilt();
            }
        }
    }

    public void UpgradeHammer(GameObject cabin) {
        prevObj = cabin;
        isUpgrade = true;
    }

    public void raiseUp() {
        //Vector3 pos = transform.position;
        //transform.position.Set(pos.x, pos.y+6, pos.z);
        transform.Translate(0, 6, 0);
    }

    // Slam the hammer
    public void Slammer() {
        GetComponentInChildren<HammerSlammer>().Slammer();
    }
}
