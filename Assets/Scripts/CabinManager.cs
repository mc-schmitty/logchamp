using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinManager : MonoBehaviour
{
    [SerializeField] GameObject[] cabinPrefabs;
    public int cabinVersion;
    private bool isUpgrade = false;
    GameObject prevObj = null;
    // Start is called before the first frame update
    void Start()
    {
        cabinVersion = 0;
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
            Instantiate(cabinPrefabs[cabinVersion], pos, rot, transform);
            cabinVersion++;
            isUpgrade = false;
        }
    }

    public void UpgradeCabin(GameObject cabin) {
        prevObj = cabin;
        isUpgrade = true;
    }
}
