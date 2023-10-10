using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damagableHit;
    Animator animator;

    [SerializeField]
    private int _maxHealth = 100;

    public HealthBar healthBar;

    //public GameObject e1;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;

        }
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get
        {
            return _health;

        }
        set
        {
            _health = value;

            if (_health <= 0)
            {
                IsAlive = false;
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
                //Instantiate(e1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Time.timeScale = 0;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;

    

    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set " + value);

        }

    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.LockVelocity);




        }
        set
        {
            animator.SetBool(AnimationStrings.LockVelocity, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }

        


    }
    // Start is called before the first frame update

    public bool Hit(int damage,Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            
            TakeDamage(damage);
            isInvincible = true;

            animator.SetTrigger(AnimationStrings.hit);
            LockVelocity = true;

            damagableHit?.Invoke(damage,knockback);
            return true;

        }
        return false;
    }


    void TakeDamage(int damage)
    {
        Health -= damage;

        healthBar.SetHealth(Health);
    }

}
