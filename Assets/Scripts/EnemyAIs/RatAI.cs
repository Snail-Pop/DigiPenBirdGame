using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    [SerializeField] 
    public GameObject target;
    Vector2 maxVel = new Vector3(2,2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(0);
    }


    void Move(int state){

        switch(state){

            case 0:
            Vector3 movDir = target.transform.position - transform.position; 
            gameObject.GetComponent<Rigidbody2D>().AddForce(movDir * 0.01f);  
            break;

        }

    }
}
