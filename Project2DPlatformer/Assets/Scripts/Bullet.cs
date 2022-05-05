using UnityEngine;
using System.Collections;
using System.Linq;

public class Bullet : MonoBehaviour
{
    private GameObject parent; // �������� ��'���, ���� ������ ���� ���� 
    private float speed = 10.0F;
    private Vector3 direction;

    private SpriteRenderer sprite;

    public Vector3 Direction { set { direction = value; } }
    public GameObject Parent { set { parent = value; } get { return parent; } }

    public Color Color
    {
        set { sprite.color = value; }
        get { return sprite.color; }
    }



    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>(); // ��������� ������� �������, ��� ���� ���� ����� ������ ����
    }

    private void Start()
    {
        Destroy(gameObject, 1.4F); // ���� ������ ���� ������ ����� ������  � ����������� ���� � ����� �� ������
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // ���� ��� � ��������� ��������
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        

        if (unit && unit.gameObject != parent) // ����������, ���� ���� ������ � ������ �������� � ��� �������� �� � �����������, �� ��������� ���� 
        {

            

            Destroy(gameObject);


        }

    }


}