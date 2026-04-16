using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
    
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
