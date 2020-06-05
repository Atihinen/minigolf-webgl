using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject ball;
    
    private GameObject putter;
    private readonly string putterTag = "Putter";
    private Putter putterInstance;
    private Ball ballInstance;
    private float thurst = 850;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindWithTag(Helper.ballTag);
        ballInstance = ball.GetComponent<Ball>();
        putter = GameObject.FindWithTag(putterTag);
        putterInstance = putter.GetComponent<Putter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (ballInstance.getState().Equals(Helper.BallState.Stationary))
            {
                ballInstance.Swing(putterInstance.GetRotation(), thurst);
            }
        }
        else if (ballInstance.getState().Equals(Helper.BallState.Stationary))
        {
            putterInstance.MovePutter(ball.transform.position);
        }
    }
}
