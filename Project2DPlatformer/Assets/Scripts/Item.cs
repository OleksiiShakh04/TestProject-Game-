using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


    [SerializeField] AudioSource audioTake; // звук підняття життя

   

    private void OnTriggerEnter2D(Collider2D collider) // якщо гравець увійшов у колайдер , додає йому одне життя 
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
