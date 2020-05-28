using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putter : MonoBehaviour
{
    private GameObject origin;
    private readonly string originName = "Origin";
    private float originRotation;
    private float rotateSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        this.origin = GameObject.Find(originName);
        this.originRotation = this.origin.transform.eulerAngles.y;
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
}
