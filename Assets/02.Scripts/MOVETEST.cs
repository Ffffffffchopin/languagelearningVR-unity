using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVETEST : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 80.0f;

    void Update()
    {
        float Move = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float Rotate = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;

        transform.Translate(0, 0, Move);
        transform.Rotate(0, Rotate, 0);
    }
}