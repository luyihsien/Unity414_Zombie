using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BgController : MonoBehaviour
{
    public Sprite dayBackground;
    public Sprite nightBackground;
    DateTime currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime=DateTime.Now;
        Debug.Log($"Now is {currentTime}");
        if (currentTime.Hour>=6 && currentTime.Hour<18){
            SetBackground(dayBackground);
        }
        else{
            SetBackground(nightBackground);

        }
    }
    private void SetBackground(Sprite background){
        SpriteRenderer spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=background;
    }
}
