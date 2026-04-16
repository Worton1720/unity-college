using Unity.VisualScripting;
using UnityEngine;

public class Ship : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // сравниваем тег входящего объекта, нужно чтобы это был игрок иначе кринж
        {
            Debug.Log("!");

            other.GetComponent<PlayerHealth>().DIE();
        }
    }
}
