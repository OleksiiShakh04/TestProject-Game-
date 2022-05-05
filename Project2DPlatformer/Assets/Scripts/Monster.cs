using UnityEngine;
using System.Collections;

public class Monster : Unit
{
  

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {

        Unit unit = collider.GetComponent<Unit>();


        CheckBullet(collider); // перевірка чи у колайдер попала куля

        if (unit && unit is Character) // якщо це доторкнувся персонаж, нанести йому шкоду
        {
            unit.ReceiveDamage();
        }
    }


    protected override void CheckBullet(Collider2D collider) // якщо попала куля білого кольору(тобто та, якою стріляє персонаж) то наноситься шкода 
    {

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject && bullet.Color == Color.white)
        {

            ReceiveDamage();


        }





    }




}
