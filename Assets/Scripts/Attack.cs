using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if(damageable != null)
        {
           
           bool gethit= damageable.Hit(attackDamage,knockback);
            if (gethit)
            {
                Debug.Log(collision.name + " hit for " + attackDamage);
            }
        }
        
    }

}
