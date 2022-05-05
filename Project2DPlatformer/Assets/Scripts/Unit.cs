using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
 public virtual void ReceiveDamage() // ���� ��� ������ �����(���� ���������)
    {


        Destroy(gameObject);


    }

    protected virtual void CheckBullet(Collider2D collider) // �������� �� � ��� ������ ���� �����
    {


        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {

            ReceiveDamage();
            

        }
    }



    
}
