using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Walk : MonoBehaviour
{
    public GameObject A;
    public Vector3 pos1 = new Vector3(-33.5f, 0.5f, -3.5f); // 도착점
    public Vector3 pos2 = new Vector3(-3.5f, 0f, -3.5f); // 시작점
    private bool turn = false;

    void Update()
    {
        if (A.transform.position.x == pos1.x)
            turn = true;

        if (A.transform.position.x == pos2.x)
            turn = false;


        if (turn == true)
        {
            A.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            A.transform.position = Vector3.MoveTowards(A.transform.position, pos2, Time.deltaTime);
        }

        if (turn == false)
        {
            A.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            A.transform.position = Vector3.MoveTowards(A.transform.position, pos1, Time.deltaTime);
        }
    }
}