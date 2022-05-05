using UnityEngine;
using System.Collections;
using System.Linq;

public class Bullet : MonoBehaviour
{
    private GameObject parent; // отримуємо об'єкт, який пустив дану кулю 
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
        sprite = GetComponentInChildren<SpriteRenderer>(); // отримання спрайту потрібно, щоб потім мати змогу змінити колір
    }

    private void Start()
    {
        Destroy(gameObject, 1.4F); // після старту куля пролітає певну відстінь  і видаляється якщо в нікого не попала
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // політ кулі у вказаному напрямку
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        

        if (unit && unit.gameObject != parent) // перевіряємо, якщо куля зайшла у якийсь колайдер і цей колайдер не є батьківським, то видаляємо кулю 
        {

            

            Destroy(gameObject);


        }

    }


}