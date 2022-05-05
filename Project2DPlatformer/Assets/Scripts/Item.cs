using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


    [SerializeField] AudioSource audioTake; // ���� ������� �����

   

    private void OnTriggerEnter2D(Collider2D collider) // ���� ������� ������ � �������� , ���� ���� ���� ����� 
    {
        Character character = collider.GetComponent<Character>();

        if (character && character.Lives < 5)
        {
            character.Lives++;
            audioTake.Play();
            Destroy(gameObject);
            
        }
    }
}
