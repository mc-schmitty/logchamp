using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinManager : MonoBehaviour
{
    [SerializeField] GameObject[] cabinPrefabs;
    public int cabinVersion;
    int maxCabin;
    private bool isUpgrade = false;
    GameObject prevObj = null;
    public WinCon winObject;

    // Start is called before the first frame update
    void Start()
    {
        cabinVersion = 0;
        //Defines the cabin index at which we notify the win con
        maxCabin = cabinPrefabs.Length;
    }

    private void FixedUpdate()
    {
        if(isUpgrade) {
            Vector3 pos = prevObj.transform.position;
            Quaternion rot = prevObj.transform.rotation;
            Destroy(prevObj);
            Instantiate(cabinPrefabs[cabinVersion], pos, rot, transform);
            cabinVersion++;
            isUpgrade = false;
            //Cabin is built! Tell the level win con object.
            if (cabinVersion == maxCabin)
            {
                winObject.CabinBuilt();
            }
        }
    }

    public void UpgradeCabin(GameObject cabin) {
        prevObj = cabin;
        isUpgrade = true;
    }
}
