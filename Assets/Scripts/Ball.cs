using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Helper.BallState currentState;
    public Transform lens;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentState = Helper.BallState.Stationary;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Magnitude: " + rb.velocity.magnitude);
        if (currentState.Equals(Helper.BallState.Swinged))
        {
            if(rb.velocity.magnitude < 0.1f)
            {
                ResetForce();
                currentState = Helper.BallState.Stationary;
                
            }
        }
    }

    private void ResetForce()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void Swing(Vector3 rotation, float thrust)
    {
        currentState = Helper.BallState.Swinging;
        StartCoroutine(WaitAndSwing(0.6f, rotation, thrust));
    }

    public Helper.BallState getState()
    {
        return currentState;
    }

    private IEnumerator WaitAndSwing(float waitTime, Vector3 rotation, float thrust)
    {
        _swing(rotation, thrust);
        yield return new WaitForSeconds(waitTime);
        currentState = Helper.BallState.Swinged;

    }

    private void _swing(Vector3 rotation, float thrust)
    {
        rb.AddForce(rotation * thrust);
    }
}