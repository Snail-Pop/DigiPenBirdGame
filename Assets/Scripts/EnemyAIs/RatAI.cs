/*
Name: Tayvian R Eberle
Date: 10/5/2022
Desc: Is what the name implies, handles simple, run towards & lunge behaviors anything it is attached to.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    [SerializeField] 
    public GameObject target;
    float leapTimer = 0;
    bool movWait = false;
    float moveTimer = 0;

    SpriteRenderer myRenderer;

    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(0);   
    }

    void Move(int mode){
        
        switch(mode){
            case 0:
            RunDirectAndLeap(7.5f, 4f, 3f, 0.5f, 5);
            break;
            case 1:
            RunDirect(5);
            break;
        }
    }

    void RunDirect(float speed){
        Vector2 movDir = target.transform.position - transform.position; 
        float distance = movDir.magnitude;
        gameObject.GetComponent<Rigidbody2D>().position += movDir.normalized / speed;
    }

    void RunDirectAndLeap(float leapSpeed, float minDistance, float leapCooldown, float movWaitTime, float speed){
        
        Vector2 movDir = target.transform.position - transform.position; 
        float distance = movDir.magnitude;
        
        if(!movWait){
            gameObject.GetComponent<Rigidbody2D>().position += (movDir.normalized * speed) * Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            myAnimator.SetBool("leaping", false);
        }
        else if(moveTimer > movWaitTime){
            movWait = false;
            moveTimer = 0;
        }
        else{
            moveTimer += Time.deltaTime;
        }

        if(distance < minDistance && leapCooldown < leapTimer){
            Leap(10, movDir);
            movWait = true;
            leapTimer = 0;
        }
        else{
            leapTimer += Time.deltaTime;
        }


        if(movDir.normalized == Vector2.zero)
        {
            myAnimator.SetBool("walking", false);
        }
        else
        {
            myAnimator.SetBool("walking", true);
            myAnimator.SetFloat("movX", movDir.x);
        }
        
    }

    void Leap(float leapSpeed, Vector2 direction){

        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * leapSpeed, ForceMode2D.Impulse);
        myAnimator.SetBool("leaping", true);

    }
}
