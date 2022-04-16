using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    // this offset will be the distance between the camera and our ball
    Vector3 offset;
    // so this is the read by which the camera will change its position to follow the ball 
    public float lerpRate;
     public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }

    }
    void Follow()
    {
        // hna 3l4an agep al mkan al 7ally 
        Vector3 pos = transform.position;
        // target position that is the position where we want camera to go 
        Vector3 targetPos = ball.transform.position - offset;
        //this fuc does is it moves on from one value to aonther   ea3ne h7wl ta7t mn al position al 7ally ly al postion al 3aez al camera tpa feha 
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;

    }
}
