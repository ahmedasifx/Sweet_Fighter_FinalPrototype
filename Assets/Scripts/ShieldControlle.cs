using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControlle : MonoBehaviour
{
    int Is_PositionHash;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        Is_PositionHash = Animator.StringToHash("Is_Position");
    }


    // Update is called once per frame
    void Update()
    {
        bool Is_Position = animator.GetBool(Is_PositionHash);
        bool forwardPressed = Input.GetKey("s");

        if (!Is_Position && forwardPressed)
        {
            animator.SetBool(Is_PositionHash, true);
        }
        if (Is_Position && !forwardPressed)
        {
            animator.SetBool(Is_PositionHash, false);
        }

    }

}
