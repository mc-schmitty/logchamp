using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
