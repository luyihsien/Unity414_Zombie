using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float TargetY;
    private GameObject sunNum;
    public void InitSkySun(float x,float y,float targetY){
        transform.position=new Vector3 (x,y,0);
        TargetY=targetY;
    }
}
