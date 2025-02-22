using UnityEngine;

public class CubeSound : MonoBehaviour
{
    public AudioSource audioSource; // Ses bileşeni
    public AudioClip woodHitSound;  // Ahşap çarpma sesi
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
        // Eğer top çarptıysa ve çarpma yeterince hızlıysa sesi çal
        if (collision.gameObject.CompareTag("Ball") && collision.relativeVelocity.magnitude > minVelocity)
        {
            audioSource.PlayOneShot(woodHitSound); // Ahşap sesi çal
        }
    }
}
