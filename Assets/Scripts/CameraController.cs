/*
Name: Tayvian Reed Eberle
Date: 9/28/2022
Desc: Makes Camera follow objcet (player) and has screenshake
 */

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.U2D.Path;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("This is the game object the camera will follow")]
    public GameObject target;

    [Range(0, 1), Tooltip("The closer to 1 the faster the camera will follow (must be between 0 and 1)")]
    public float smoothVal = 0.5f;

    private static float shakeDuration;
    private static float shakeMagnitude;
    private static float startShakeDuration;


    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartShake(2, 0.4f);
        }

        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;
            //Make a random adjustment based on time and magnitude of the shake
            Vector2 randShake = Random.insideUnitCircle * Mathf.Lerp(shakeMagnitude, 0, 1 - (shakeDuration / startShakeDuration));

            transform.position += (Vector3)randShake;
        }
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position;

        //Keep camera Z value
        targetPos.z = transform.position.z;
        //Move towards target based on smoothVal
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothVal);

    }

    public static void StartShake(float duration, float magnitude)
    {

        if(duration > shakeDuration)
        {
            shakeDuration = duration;
            startShakeDuration = duration;

        }
        if (magnitude > shakeMagnitude)
        {
            shakeMagnitude = magnitude;
        }

    }

}
