using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D),typeof(TouchingDirection),typeof(Damageable))]

public class PlayerControler : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    Vector2 moveInput;
    TouchingDirection touchingDirection;

    int Is_PositionHash;
    Damageable damageable;
   
    



    public float CurrentMovespeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMove)
                {
                    if (IsRunning)
                    {
                        return runSpeed;
                    }
                    else
                    {

                        return walkSpeed;
                    }


                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }
          
        }
    }

    [SerializeField]
    private bool _isMoving=false;

    
    public float jumpImpulse=10f;

   

    public bool IsMove { get
        {
            return _isMoving; 
        }
        private set { 

            _isMoving = value;
            animator.SetBool("IsMoving", value);
 
        } }


    [SerializeField]
    private bool _isRunning=false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;

        }
    
    
    
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public bool IsAlive
    {
        get { 
            
            
            return animator.GetBool(AnimationStrings.isAlive);
            
        
        }
    }

    

    Rigidbody2D rb;
    Animator animator;
   

    // Start is called before the first frame update

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirection=GetComponent<TouchingDirection>();
        Is_PositionHash = Animator.StringToHash("Is_Position");
        damageable=GetComponent<Damageable>();
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!damageable.LockVelocity)
        {
            rb.velocity = new Vector2(moveInput.x * CurrentMovespeed, rb.velocity.y);
        }
        
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }


   public void OnMove(InputAction.CallbackContext context) 
    {

        moveInput=context.ReadValue<Vector2>();

        if (IsAlive)
        {
            IsMove = moveInput != Vector2.zero;

        }
        else 
        {
            IsMove= false;
        
        
        }
        
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
            
        } else if (context.canceled)
        {
            IsRunning= false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (touchingDirection.IsGrounded &&context.started && CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);

            animator.SetTrigger(AnimationStrings.jump);
        }
    }

    

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attack);

        }
    }

    public void OnSpeacialAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.SpecialAttackTrigger);

        }                                                                         
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.isBlock);

        }

       

    }

    public void OnHit(int damage,Vector2 knockback)
    {
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }





}
