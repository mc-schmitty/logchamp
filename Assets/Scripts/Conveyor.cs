using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private bool activated;
    private int shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        shootCooldown = 120;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!activated)
            return;
        
        
    }

    public void activate() {
        transform.Translate(2, 0, 0);
        activated = true;
    }
}
