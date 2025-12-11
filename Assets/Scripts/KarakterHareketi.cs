using UnityEngine;
using UnityEngine.SceneManagement;
public class KarakterHareketi : MonoBehaviour
{
    public GameObject panel;
    public float hareketHizi = 5f;
    public float donmeHizi = 250f;
    public float ziplamaGucu = 6f;

    private Rigidbody rb;
    private bool ziplayabilir = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // W - S (İLERİ - GERİ)
        float ileriGeri = Input.GetAxis("Vertical");

        // A - D (SAĞ - SOL)
        float sagaSola = Input.GetAxis("Horizontal");

        Vector3 hareket =
            transform.forward * ileriGeri +
            transform.right * sagaSola;

        hareket *= hareketHizi * Time.deltaTime;
        transform.Translate(hareket, Space.World);

        // Mouse sol tuş ile döndürme
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float donme = mouseX * donmeHizi * Time.deltaTime;
            transform.Rotate(Vector3.up, donme);
        }

        // Zıplama
        if (ziplayabilir && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            ziplayabilir = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            ziplayabilir = true;
        }
    }
    public void PanelAc()
    {
        panel.SetActive(true);
        Debug.Log("asdaaa");
    }
}
