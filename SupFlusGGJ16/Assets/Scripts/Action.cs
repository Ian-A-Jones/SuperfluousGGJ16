using UnityEngine;
using System.Collections;

public struct Action
{
    public float timeStamp;

    //Movement variables
    public Vector3 pos;
    public float move;
    public bool jump;

    public float health;

    public void Reset()
    {
        pos = Vector3.zero;
        move = 0;
        jump = false;
        health = 0;
        timeStamp = 0;
    }
}