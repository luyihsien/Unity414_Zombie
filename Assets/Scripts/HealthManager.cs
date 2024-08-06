using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health=2;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioSource audioSource;
    public AudioClip deathSound;
    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts){
            img.sprite=emptyHeart;
        }
        for (int i=0;i<health;i++){
            hearts[i].sprite=fullHeart;
        }
    }
    public void ChangeHealth(int amount){
        health-=amount;
        if (health<=0){
            Time.timeScale=0f;
            audioSource.PlayOneShot(deathSound);
        }
    }
}
