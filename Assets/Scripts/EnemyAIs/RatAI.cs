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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(0);
    }

    void Move(int mode){
        
        switch(mode){
            case 0:
            RunDirectAndLeap(7.5f, 3f, 0.3f, 10);
            break;
            case 1:
            RunDirect(10);
            break;
        }

    }

    void RunDirect(float speed){
        Vector2 movDir = target.transform.position - transform.position; 
        float distance = movDir.magnitude;
        gameObject.GetComponent<Rigidbody2D>().position += movDir.normalized / speed;
    }

    void RunDirectAndLeap(float minDistance, float leapCooldown, float movWaitTime, float speed){
        
        Vector3 movDir = target.transform.position - transform.position; 
        float distance = movDir.magnitude;
        
        if(!movWait){
            transform.position += movDir.normalized / speed;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
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
    }

    void Leap(float leapSpeed, Vector2 direction){

        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * leapSpeed, ForceMode2D.Impulse);
        
    }
}
