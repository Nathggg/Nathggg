using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Damage : MonoBehaviour
{
    
       int decayAmount = 5;

    public void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player") 
        {
            var player = collision.GetComponent<Player>();
            player.TakeDamage(decayAmount);
        }
    }
}
