using UnityEngine;
using System.Collections;

public class Monster : Unit
{
  

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {

        Unit unit = collider.GetComponent<Unit>();


        CheckBullet(collider); // �������� �� � �������� ������ ����

        if (unit && unit is Character) // ���� �� ����������� ��������, ������� ���� �����
        {
            unit.ReceiveDamage();
        }
    }


    protected override void CheckBullet(Collider2D collider) // ���� ������ ���� ����� �������(����� ��, ���� ������ ��������) �� ���������� ����� 
    {

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject && bullet.Color == Color.white)
        {

            ReceiveDamage();


        }





    }




}
