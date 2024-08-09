using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed=6.0f;
    private bool facingRight=true;
    public float jumpforce=10f;
    Animator myAnim;
    Rigidbody2D myRigi;
    bool isJumPressed,canJump;
    public HealthManager healthManager;
    public int damage=1;
    public GameObject SwipeCollider;
    void Start() {
        myAnim=GetComponent<Animator>();
        myRigi=GetComponent<Rigidbody2D>();
        isJumPressed=false;
        canJump=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump==true){
            isJumPressed=true;
            canJump=false;
        }
        if (Input.GetKeyDown(KeyCode.T)){
            myAnim.SetTrigger("Swipe");
        }

    }
    void FixedUpdate() {
        float moveHorizontal=Input.GetAxis("Horizontal");
        myAnim.SetFloat("Run",Mathf.Abs(moveHorizontal));
        Vector3 movement=new Vector3(moveHorizontal,0.0f,0.0f);
        transform.position=transform.position+movement*speed*Time.deltaTime;
        if (moveHorizontal>0 && !facingRight)
        Flip();
        else if (moveHorizontal<0 && facingRight)
        Flip();
        if (isJumPressed){
            myRigi.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
            isJumPressed=false;
        }
        
    }

    void Flip(){
        facingRight=!facingRight;
        Vector3 theScale=transform.localScale;
        theScale.x*=-1;
        transform.localScale=theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag=="box"){
            canJump=true;
        }
        if  (collision.gameObject.CompareTag("Enemy")){
            healthManager.ChangeHealth(damage);
        }     
    }
    public void SwipeColliderOn(){
        SwipeCollider.SetActive(true);

    }
    public void SwipeColliderOff(){
        SwipeCollider.SetActive(false);

    }

}
