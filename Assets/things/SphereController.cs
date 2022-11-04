using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject camera;
    public Rigidbody rb;
    public float verticalInput;
    public float horizontalInput;
    public float speed = 10.0f;
    private bool IsJumping;
    public float unitsPerSecond = 1.0f;
    private float horizontalMovement = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        IsJumping = false; 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1f, 1f), 0, 0);
        Physics.gravity = new Vector3(0, -50.0F, 0);
        // rb.velocity = new Vector3(50, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rb.drag = 10;
        rb.velocity = new Vector3(0, 0, 5);
        Jump();
        HorizontalMove();
    }

    void Jump() {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJumping){
                IsJumping = true;
            rb.AddForce(Vector3.up*80,ForceMode.Impulse);
            Debug.Log("jump");
            } else {
                return;
            }
        }
    }

    void HorizontalMove() {
        horizontalInput = Input.GetAxis("Horizontal");
        // Input with Oculus Quest
        // horizontalInput = camera.transform.eulerAngles.
        // if ( horizontalMovement < 50 && horizontalMovement > -50){
            // horizontalMovement += horizontalInput;
            rb.transform.Translate(horizontalInput * 0.1F, 0, 0);
        // }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")){
            IsJumping = false;
        }
    }
}
