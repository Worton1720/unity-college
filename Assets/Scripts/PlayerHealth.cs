using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static bool isDead = false;
    void Awake(){
        isDead = false;
    }
    public void Die()
    {
        Destroy(GetComponent<CWPlayerControl>());
        Destroy(GetComponentInChildren<CWJumpTrigger>());
        GetComponent<BoxCollider2D>().enabled = false;
        isDead = true;
        Camera.main.backgroundColor = new Color(Random.value, Random.value, Random.value); // ну надо же как то показать смерть игрока да
        StartCoroutine(WaitForLevelRetry());
    }
    public void DIE()
    {
        Die();
        string[] timestamps = { "0", "10", "19", "26", "38", "44", "60", "68", "81", "100" };

        string randomTime = timestamps[new System.Random().Next(timestamps.Length)];
        string url = $"https://www.youtube.com/watch?v=FdmsevEh6gQ&t={randomTime}s&autoplay=1";
        
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    IEnumerator WaitForLevelRetry()
    {
        while (true)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            yield return null;
        }
    }
}
