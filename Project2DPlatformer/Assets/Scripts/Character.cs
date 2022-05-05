using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Character : Unit
{

    [SerializeField] AudioSource audioGameOver;
    [SerializeField] AudioSource audioGetPick;
    [SerializeField] AudioSource audioShoot;
    [SerializeField] GameObject finish;

    [SerializeField] private float speed = 3.0F;
    [SerializeField] private float jumpForce = 15.0F;
    [SerializeField] int lives = 5;


    private HeathBar heathBar;
    private Bullet bullet;
    private bool isGrounded = false;




    public int Lives
    {

        get { return lives; }
        set { 
            if(value < 5)  lives = value;
            heathBar.Refresh(); // після кожної зміни очків життя, оновлюємо бар де показується відповідна кількість сердечок
        
        
        }

    }
 




    private CharState State 
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        heathBar = FindObjectOfType<HeathBar>();

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        
        


    }

    private void FixedUpdate()
    {
        CheckGround(); 
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run() // метод, що дає можливість персонажу рухатись
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }

    private void Jump() // метод, що дає можливість персонажу стрибати
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot() // метод, що дає можливість персонажу стріляти
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        audioShoot.Play();
        
    }

    public override void ReceiveDamage() // якщо персонаж отримав шкоду
    {

        // підносить трохи персонажа до гори
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 5.0F, ForceMode2D.Impulse);

        // віднімає одне життя і  відійграє звук шкоди персонажу
        Lives--;
        audioGetPick.Play(); 


       // перевіряє чи ще залишилось у персонажа кількість життів. Якщо ні, то виводить інформацію про те, що гра завершена
        if (Lives == 0)
        {
            Destroy(gameObject);
            audioGameOver.Play();
            finish.SetActive(true);
           
        }
    }

    private void CheckGround() // перевірка чи гравець є на землі(потрібно для анімації стрибка)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        CheckBullet(collider);
        
    }


   
}


public enum CharState // список доступних анімацій
{
    Idle,
    Run,
    Jump
}