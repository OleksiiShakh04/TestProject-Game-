using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour
{


    private Transform[] hearts = new Transform[5]; // к≥льк≥сть м≥сць п≥д сердечка
    private Character character; // посиланн€ на гравц€

    private void Awake()
    {

        character = FindObjectOfType<Character>();
        for(int i = 0; i < hearts.Length; i++)
        {

            hearts[i] = transform.GetChild(i);

        }
  

    }


    public void Refresh() // оновлюЇ ≥нформац≥ю  у ≥нтерфейс≥ щодо того, ск≥льки ще залишилось житт≥в у гравц€
    {

        for(int i = 0; i<hearts.Length; i++)
        {

            if (i < character.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);



        }




    }

}
