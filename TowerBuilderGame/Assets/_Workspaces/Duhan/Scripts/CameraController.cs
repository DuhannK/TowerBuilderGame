using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Static deðiþken: Sahnede tek bir tane bulunur ve tüm bloklar buna kolayca ulaþabilir.
    public static float highestY = -4f;

    [Header("Kamera Ayarlarý")]
    [SerializeField] private float smoothSpeed = 3f; // Kameranýn yukarý kayma yumuþaklýðý
    [SerializeField] private float yOffset = 2f; // Kameranýn bloðun ne kadar üstüne bakacaðý

    private float minY; // Kameranýn inebileceði en alt nokta (baþlangýç noktasý)

    private void Start()
    {
        // Oyuna her baþladýðýmýzda veya yandýðýmýzda deðiþkeni sýfýrlýyoruz.
        highestY = -4f;
        minY = transform.position.y;
    }

    private void Update()
    {
        // Hedef yüksekliði belirle. (Mathf.Max sayesinde kule devrilse bile kamera aþaðý inmez, yukarýda kalýr).
        float targetY = Mathf.Max(minY, highestY + yOffset);

        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // Lerp komutu, kameranýn aniden ýþýnlanmasý yerine sinematik ve pürüzsüz bir þekilde yukarý kaymasýný saðlar.
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}