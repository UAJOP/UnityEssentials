using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    public Rigidbody ballRigidbody; // Topun Rigidbody'sini atayacaksın
    public Transform player; // Player'ı Inspector'dan bağla
    public float triggerDistance = 2f; // Mesafe eşiği
    public GameObject confettiEffectPrefab; // Konfeti efekti (Inspector’dan bağla)
    public AudioClip winSound; // Kazanma sesi (Inspector’dan bağla)
    
    private bool hasTriggered = false; // Tekrar tetiklenmeyi engellemek için
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Audio kaynağı ekle
    }

    private void Update()
    {
        if (!hasTriggered && Vector3.Distance(transform.position, player.position) < triggerDistance)
        {
            hasTriggered = true; // Tekrar çalışmasını engelle

            // Topun yerçekimini aç
            if (ballRigidbody != null)
            {
                ballRigidbody.useGravity = true;
            }

            // Konfeti efekti oluştur (Player’ın üstünde belirsin)
            if (confettiEffectPrefab != null)
            {
                Vector3 confettiPosition = player.position + new Vector3(0, 0, 0); // Oyuncunun biraz üstüne konumlandır
                Quaternion confettiRotation = Quaternion.Euler(-90, 0, 0); // Efekti -90 derece döndür

                GameObject confetti = Instantiate(confettiEffectPrefab, confettiPosition, confettiRotation);

                // **Particle System’i manuel başlat**
                ParticleSystem ps = confetti.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }

                // Efekti sahneden 5 saniye sonra temizle
                Destroy(confetti, 5f);
            }

            // Kazanma sesi çal
            if (winSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            Debug.Log("Kazanma efekti tetiklendi! 🎉");
        }
    }
}
