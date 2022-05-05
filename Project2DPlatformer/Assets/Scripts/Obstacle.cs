using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
    
        if(unit && unit is Character) // якщо персонаж зайшов у колайдер, то наносить йому шкоду 
        {

            unit.ReceiveDamage();

        }   
    
    }

}
