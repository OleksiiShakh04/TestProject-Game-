using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    [SerializeField] GameObject finish;


    private void OnTriggerEnter2D(Collider2D collider) // якщо гравець у нас увійшов у колайдер прапора, то гра завершується і вибиває вікно, де можливий перехід на наступний рівень
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {

            finish.SetActive(true);


        }

    }
}
