using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioSource audioSource; // Ses kaynağını atamak için
    public AudioClip bounceSound;   // Çarpma sesi
    public float minVelocity = 0.5f; // Minimum hız eşiği

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Eğer atanmadıysa, GameObject'teki AudioSource bileşenini al
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışma şiddetini kontrol et (çok küçük çarpışmalarda ses çalmasını engellemek için)
        if (collision.relativeVelocity.magnitude > minVelocity)
        {
            audioSource.PlayOneShot(bounceSound); // Çarpışma sesi çal
        }
    }
}
