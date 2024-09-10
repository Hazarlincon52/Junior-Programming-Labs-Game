using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAround : MonoBehaviour
{
    [SerializeField] private float startPosXLeft;
    [SerializeField] private float startPosXRight;
    [SerializeField] private float startPosYUp;
    [SerializeField] private float startPosYDown;
    [SerializeField] private float moveSpeed;

    enum State
    {
        LeftToRight,
        RightToLeft,
        UpToDown,
        DownToUp,
    }

    [SerializeField] private State state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.UpToDown:
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                if (transform.localPosition.y <= startPosYDown)
                {
                    state = State.LeftToRight;
                }
                break;
            case State.DownToUp:
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                if (transform.localPosition.y >= startPosYUp)
                {
                    state = State.RightToLeft;
                }
                break;
            case State.LeftToRight:
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                if (transform.position.x >= startPosXRight)
                {
                    state = State.DownToUp;
                }
                break;
            case State.RightToLeft:
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                if (transform.position.x <= startPosXLeft)
                {
                    state = State.UpToDown;
                }
                break;
        }

        
    }
}
