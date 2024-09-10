using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float startPosXLeft;
    [SerializeField] private float startPosXRight;
    [SerializeField] private float moveSpeed;

    enum State
    { 
        LeftToRight,
        RightToLeft,
    }

    [SerializeField] private State state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.LeftToRight:
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                if (transform.position.x >= startPosXRight)
                {
                    state = State.RightToLeft;
                }
                break;
            case State.RightToLeft:
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                if (transform.position.x <= startPosXLeft)
                {
                    state = State.LeftToRight;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetAsFirstSibling();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }

    }
}
