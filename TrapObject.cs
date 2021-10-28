using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class TrapObject : MonoBehaviour
{

    int decayAmount = 15;

    public void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
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
