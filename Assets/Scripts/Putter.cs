using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putter : MonoBehaviour
{
    private GameObject origin;
    private readonly string originName = "Origin";
    private float rotateSpeed = 25f;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        this.origin = GameObject.Find(originName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(this.origin.transform.position, this.origin.transform.up, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(this.origin.transform.position, -1*this.origin.transform.up, rotateSpeed * Time.deltaTime);
        }
    }

    public Vector3 GetRotation()
    {
        return -1*transform.up;
    }

    public void MovePutter(Vector3 position)
    {
        distance = position - origin.transform.position;
        transform.position += distance;
    }
}
