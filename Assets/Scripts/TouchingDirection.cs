using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{

    public ContactFilter2D CastFilter;
    public float groundDistance = 0.05f;

    PolygonCollider2D touchingcol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    Animator animator;
    [SerializeField]
    private bool _isgrounded;


    public bool IsGrounded
    {
        get
        {
            return _isgrounded;

        }
        private set
        {
            _isgrounded = value;
            //animator.SetBool(AnimationStrings.isgrounded, value);
           animator.SetBool(AnimationStrings.isgrounded, value);
        }
    }

    private void Awake()
    {
        touchingcol = GetComponent<PolygonCollider2D>();
        animator= GetComponent<Animator>();

    }
    // Start is called before the first frame update
    


     void FixedUpdate()
    {
        IsGrounded = touchingcol.Cast(Vector2.down, CastFilter, groundHits, groundDistance) > 0;
    }

    // Update is called once per frame
    
}
   