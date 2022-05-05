using UnityEngine;
using System.Collections;

public class MonsterFire : Monster
{
    [SerializeField] private float rate = 2.0F; // ������� � ���� ���� ������� ������ ������
    [SerializeField] private Color bulletColor = Color.red; // ���� ���� 
    
    private Bullet bullet;

    protected  void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet"); // ��������� ������ ��� 
    }

    protected void Start()
    {
        InvokeRepeating("Shoot", rate, rate); // ���� ������� ���, ������ ���� ������� ������ �� ������� �������� 
    }





    private void Shoot() // ��������� ������� ��� 
    {
        Vector3 position = transform.position; position.y += 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = bulletColor;
        
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        CheckBullet(collider); // �������� �� �� ������ ���� � ��������
        

        // ���� � �������� ������ ��������, �������� ���� �����
        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }



    protected override void CheckBullet(Collider2D collider) 
    {

        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject && bullet.Color == Color.white )
        {

            ReceiveDamage();


        }





    }


}
