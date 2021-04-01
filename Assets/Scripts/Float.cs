using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    float iniPos;
    float curPos;
    [SerializeField] float limit = 0.4f;
    float posAmt = 0.003f;

    // Start is called before the first frame update
    void Start()
    {
        iniPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        curPos = gameObject.transform.position.y;
        if(curPos - iniPos > limit)
            posAmt = -0.003f;
        else if(curPos - iniPos < -limit)
            posAmt = 0.003f;
        
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posAmt, gameObject.transform.position.z);
    }
}
