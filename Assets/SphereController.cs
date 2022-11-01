using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalInput;
    public float speed = 10.0f;
    private bool IsJumping;
    public float unitsPerSecond = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsJumping = false; 
        // Physics.gravity = new Vector3(0, -50.0F, 0);
        // rb.velocity = new Vector3(50, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rb.drag = 10;
                Physics.gravity = new Vector3(0, -50.0F, 0);
        rb.velocity = new Vector3(-5, 0, 0);
        Jump();
        MoveCamera();
    }

    void Jump() {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJumping){
                IsJumping = true;
            rb.AddForce(Vector3.up*30,ForceMode.Impulse);
            Debug.Log("jump");
            } else {
                return;
            }
        }
    }

    void MoveCamera() {
        // grab the camera's current location
        Vector3 pos = Camera.main.transform.position;
    
        // move it right based on the amount of time the previous frame took
        pos.x += unitsPerSecond / Time.deltaTime;
    
        // move the camera to the new position
        Camera.main.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")){
            IsJumping = false;
        }
    }
}
