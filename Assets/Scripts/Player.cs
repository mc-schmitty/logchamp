using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float PlayerSpeed;

    Rigidbody rigidbodyComponent;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Debug.Log(horizontalInput);

    }

    // Called every physics update
    private void FixedUpdate() 
    {
        rigidbodyComponent.velocity = Vector3.ClampMagnitude(new Vector3(horizontalInput * PlayerSpeed, rigidbodyComponent.velocity.y, verticalInput * PlayerSpeed), PlayerSpeed);
        
    }

    // Kill the player
    public void Die() 
    {
        PlayerSpeed = 0;
        
    }
}
