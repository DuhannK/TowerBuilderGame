using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("Blok Ayarlarý")]
    [SerializeField] private float gridSize = 0.5f;
    [SerializeField] private float fallSpeed = 3f; // Senin belirlediðin hýz

    private Rigidbody2D rb;
    private bool isLanded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        // Boyutla oynamýyoruz çünkü sen en mükemmel 0.97 deðerini buldun!
        // Sadece düþerken saða sola yamulmasýný kilitliyoruz.
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (isLanded) return;

        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-gridSize, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(gridSize, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLanded) return;

        // Sadece alttan temas varsa çalýþýr
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isLanded = true;

            // Yere deðdiði an kilitleri aç ve kule fiziðine dahil et
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 1f;

            if (transform.position.y > CameraController.highestY)
            {
                CameraController.highestY = transform.position.y;
            }

            FindObjectOfType<BlockSpawner>().SpawnBlock();
        }
    }
}