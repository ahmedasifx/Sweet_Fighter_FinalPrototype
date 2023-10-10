using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Transform target; // The player's transform
    public float moveSpeed = 5f; // The speed at which the enemy will move towards the player
    creamAi cream;
    private Animator anim;
    // The point from which the enemy will fire projectiles
   
   
   
    


   



    private void Update()
    {
        anim = GetComponent<Animator>();
        cream = anim.GetComponent<creamAi>();



        if (target != null) // Make sure the target is not null
        {
            // Move towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            anim.SetBool("Move",true);
            cream.LookAtPlayer();




           



        }
        else
        {
            anim.SetBool("Move", false);

        }


    }

    // Called when the enemy collides with the player
  
}
