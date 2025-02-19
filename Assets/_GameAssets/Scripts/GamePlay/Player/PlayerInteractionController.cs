using Unity.VisualScripting;
using UnityEngine;

// Oyuncunun etkileşime girdiği nesneleri yöneten kontrolcü sınıfı
public class PlayerInteractionController : MonoBehaviour
{
    // Oyuncunun kontrolünü sağlayan PlayerController referansı
    private PlayerController _playercontroller;

    // Bileşenleri başlangıçta almak için Awake fonksiyonu
    private void Awake()
    {
        // Oyuncunun PlayerController bileşenini al
        _playercontroller = GetComponent<PlayerController>();
    }

    // Oyuncu bir nesne ile çarpıştığında tetiklenen fonksiyon (tetikleyici ile)
    private void OnTriggerEnter(Collider other)
    {
        // Çarpışılan nesne ICollectable arayüzüne sahip mi kontrol et
        if (other.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            // Eğer nesne toplanabilir bir nesne ise Collect() metodunu çağır
            collectable.Collect();
        }
    }

    // Oyuncu fiziksel bir çarpışma yaşadığında tetiklenen fonksiyon
    private void OnCollisionEnter(Collision other)
    {
        // Çarpışılan nesne IBoostable arayüzüne sahip mi kontrol et
        if (other.gameObject.TryGetComponent<IBoostable>(out var boostable))
        {
            // Eğer nesne hız artırıcı bir nesne ise Boost() metodunu çağır ve oyuncu bilgisini gönder
            boostable.Boost(_playercontroller);
        }
    }
}
