using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    [SerializeField] GameObject finish;


    private void OnTriggerEnter2D(Collider2D collider) // ���� ������� � ��� ������ � �������� �������, �� ��� ����������� � ������ ����, �� �������� ������� �� ��������� �����
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {

            finish.SetActive(true);


        }

    }
}
