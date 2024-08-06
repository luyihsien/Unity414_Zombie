using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skymgr : MonoBehaviour
{
    public static Skymgr Instance;
    private float MinX=-5.64f;
    private float MaxY=2.84f;
    private float MaxX=2.82f;
    private float MinY=-4.52f;
    private GameObject sunPre;
    // Start is called before the first frame update
    void Start()
    {
        Instance=this;
        sunPre=Resources.Load<GameObject>("Sun");
        Debug.Log(sunPre);
        InvokeRepeating("CreateSun",2,5);   
    }
    private void CreateSun(){
        GameObject go=GameObject.Instantiate(sunPre);
        Sun sun=go.GetComponent<Sun>();
        float X=Random.Range(MinX,MaxX);
        float Y=Random.Range(MinY,MaxY);
        sun.InitSkySun(X,Y,Y);
    }
}
