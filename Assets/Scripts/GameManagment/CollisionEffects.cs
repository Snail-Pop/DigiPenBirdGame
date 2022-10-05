/*
 * Name: Tayvian R Eberle.
 * Date: 10/4/2022
 * Desc: Add this to run function that work with events when collision occurs in different ways.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEffects : MonoBehaviour
{
    [Tooltip("Select layers this should interact with. If you are using this script and select nothing... Why..?")]
    public LayerMask layerMask;

    public UnityEvent collisionEnterEvent = new();
    public UnityEvent collisionExitEvent = new();
    public UnityEvent collisionStayEvent = new();

    public Collision2D otherCollision;
    public Collider2D otherCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //left shift a binary 1 over by the layer index numver, layermasks have a 1 in each position that is checked, ad the single & is a bitwise and, so if it isn't 0 then the layer was in the mask
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionEnterEvent.Invoke();
            otherCollision = collision;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionExitEvent.Invoke();
            otherCollision = collision;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionStayEvent.Invoke();
            otherCollision = collision;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionEnterEvent.Invoke();
            otherCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionExitEvent.Invoke();
            otherCollider = collision;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            collisionStayEvent.Invoke();
            otherCollider = collision;
        }

    }
}
