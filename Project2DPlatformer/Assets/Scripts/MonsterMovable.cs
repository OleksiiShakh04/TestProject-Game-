using UnityEngine;
using System.Collections;
using System.Linq;

public class MonsterMovable : Monster
{
    [SerializeField] private float speed = 3.0f; // швидкість з якою буде рухатися монстр

    private Vector3 direction; // напрямок, по якому рухатиметься персонаж 


  

    protected  void Start()
    {
        direction = transform.right;
    }


    protected  void Update()
    {
        Move();  
    }



    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        // якщо персонаж стрибнув на монтсра згори, то вбиває його, якщо увійшов у колайдер збоку, то пероснаж отримує шкоду
        if (unit && unit is Character) 
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.7F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }



    private void Move() // переміщає монстра вліво-вправо(коли монстр у щось впирається, і це не є персонаж, то змінює рух в інший бік)
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.65f, 0.1f);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>()) && colliders.All(x => !x.GetComponent<Bullet>())) direction *= -1.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);


    
    }




}
