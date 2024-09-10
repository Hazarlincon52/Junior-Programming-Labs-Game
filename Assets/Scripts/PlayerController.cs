using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject camerak;
    [SerializeField] private Transform[] cameraPosPerStage;
    
    private PlatformMove pM;
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 90f;
    private float xRange = 15f;
    private float horizontalInput;
    private float speed = 80f;
    private float maxSpeed = 8f;
    
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGameActive())
        {

            horizontalInput = Input.GetAxis("Horizontal");
            //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            rb.AddForce(Vector3.right * horizontalInput * speed);
           
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }

            //Wall Boundry
            if (transform.position.x <= -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x >= xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.instance.IsGameActive())
        {
            if (other.gameObject.CompareTag("Enter 1-2"))
            {
                camerak.transform.position = cameraPosPerStage[1].transform.position;
                GameManager.instance.SetStageText(2);

            }

            if (other.gameObject.CompareTag("Exit 1-1"))
            {
                camerak.transform.position = cameraPosPerStage[0].transform.position;
                GameManager.instance.SetStageText(1);
            }

            if (other.gameObject.CompareTag("Enter 2-1"))
            {
                camerak.transform.position = cameraPosPerStage[2].transform.position;
                GameManager.instance.SetStageText(3);

            }

            if (other.gameObject.CompareTag("Exit 1-2"))
            {
                camerak.transform.position = cameraPosPerStage[1].transform.position;
                GameManager.instance.SetStageText(2);
            }
            
            if(other.gameObject.CompareTag("Goal"))
            {
                GameManager.instance.SetWin();
                Destroy(other.gameObject);
                GameManager.instance.SetGameActive();
            }
        }
        
    }

}
