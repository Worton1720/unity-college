using UnityEngine;

public class ObjectActivatorTrigger : MonoBehaviour
{
    public GameObject otherGameObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // сравниваем тег входящего объекта, нужно чтобы это был игрок иначе кринж
        {
            otherGameObject.SetActive(true);
        }
    }
}
