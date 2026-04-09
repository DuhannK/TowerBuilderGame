using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yükleme iþlemleri için bu kütüphane þart!

public class DeathZone : MonoBehaviour
{
    // OnTriggerEnter2D, objenin collider'ýnda "Is Trigger" seçiliyse çalýþýr.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer bu alana herhangi bir þey (blok) deðerse oyunu sýfýrla.
        RestartGame();
    }

    private void RestartGame()
    {
        // SceneManager, o an açýk olan sahnenin adýný bulur ve onu en baþtan tekrar yükler.
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}