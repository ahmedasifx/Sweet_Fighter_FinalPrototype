using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage = 10;
    public Vector2 moveSpeed = new Vector2(3f,0);
    public Vector2 Knockback = new Vector2(0, 0);


    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x,moveSpeed.y );

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable= collision.GetComponent<Damageable>();
        
        if(damageable != null)
        {
            Vector2 deliveredKonckback = transform.localScale.x > 0 ? Knockback : new Vector2(-Knockback.x, Knockback.y);

            bool gethit = damageable.Hit(damage, deliveredKonckback);
            if (gethit)
            {
                
                Debug.Log(collision.name + " hit for " + damage);
                Destroy(gameObject);
            }

        }
    }
}
