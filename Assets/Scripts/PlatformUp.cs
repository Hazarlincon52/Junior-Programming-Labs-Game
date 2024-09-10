using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    [SerializeField] private float startPosYUp;
    [SerializeField] private float startPosYDown;
    [SerializeField] private float moveSpeed;
    enum State
    {
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
                    state = State.DownToUp;
                }
                break;
            case State.DownToUp:
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                if (transform.localPosition.y >= startPosYUp)
                {
                    state = State.UpToDown;
                }
                break;
        }
    }
}
