using UnityEngine;

public class Collectible : MonoBehaviour
{   
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip collectSound; // Ses dosyası

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player")) 
        {
            // Ses çalsın
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Efekti oluştur
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Collectible'ı yok et
            Destroy(gameObject);
        }
    }
}
