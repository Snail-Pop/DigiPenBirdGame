using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    [Tooltip("Selected prefab will be shot from whatever this script is attached to")]
    public GameObject projectile;
    public float speed = 10;
    private float timer;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        //Check for input from the Fire1 axis (Default: mouse1 || joystickButton0)
        if (Input.GetAxisRaw("Fire1") > 0 && timer >= cooldown)
        {
            timer = 0;
            //set spawn location
            Vector3 spawnPos = transform.position;
            //get mouse location
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            //setup direction to fire
            Vector3 fireDir = (mousePos - spawnPos).normalized;
            //make prefab real
            GameObject cloneProj = Instantiate(projectile, spawnPos, Quaternion.identity);
            //launch in desired direction
            cloneProj.GetComponent<Rigidbody2D>().velocity = fireDir * speed;
        }
    }
}
