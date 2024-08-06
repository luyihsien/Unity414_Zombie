using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2 : MonoBehaviour
{
    public Transform target;
    public float speed = 4.0f;
    private bool facingRight = false;
    private Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        float mv = transform.position.x - target.position.x;

        // Only move if mv is significant
        if (Mathf.Abs(mv) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            myAnim.SetFloat("Walk", Mathf.Abs(mv));
        }
        else
        {
            myAnim.SetFloat("Walk", 0f);
        }

        // Flip the character based on its direction
        if (mv > 0 && facingRight) // Moving left, flip to left
        {
            Flip();
        }
        else if (mv < 0 && !facingRight) // Moving right, flip to right
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

