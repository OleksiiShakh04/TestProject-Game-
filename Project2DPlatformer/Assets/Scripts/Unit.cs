using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
 public virtual void ReceiveDamage() // коли юніт отримує шкоду(різна реалізація)
    {


        Destroy(gameObject);


    }

    protected virtual void CheckBullet(Collider2D collider) // перевірка чи у юніт попала чужа кукля
    {


        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {

            ReceiveDamage();
            

        }
    }



    
}
