/*
Name: Tayvian Reed Eberle
Date: 9/28/2022
Desc: Add this to the player object you want controlled using velocity and the old Unity input system
 */

using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Player speed variable")]
    public float speed;

    Rigidbody2D myRB2D;
    SpriteRenderer myRenderer;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRB2D = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 movement = Vector2.zero;
        //Get input from old system
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Make sure movement is a unit vector, and scale movement
        myRB2D.velocity = movement.normalized * speed;

        if(movement == Vector2.zero)
        {
            myAnimator.SetBool("walking", false);
        }
        else
        {
            myAnimator.SetBool("walking", true);
            myAnimator.SetFloat("moveY", movement.y);
            myAnimator.SetFloat("moveX", movement.x);
        }

    }
}
