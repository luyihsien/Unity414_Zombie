using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public float speed=5.0f;
    public float leftlimit=-2.93f;
    public float rightlimit=9.73f;
    private float direction=1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*direction*Time.deltaTime,0,0);
        if (transform.position.x>=rightlimit || transform.position.x<=leftlimit){
            direction*=-1;
        }
        
    }
}
