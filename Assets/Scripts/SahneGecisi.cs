using System.Collections.Generic;
using UnityEngine;
// TextMeshPro’ya sahip UI nesneleri için gerekli
using TMPro;
using UnityEngine.SceneManagement; // Sahne işlemleri için

public class SahneGecisi : MonoBehaviour
{
    // Karakter ve zorluk açılır listeleri
    public TMP_Dropdown karakter;
    public TMP_Dropdown zorluk;

    void Start()
    {
        // Daha önce kaydedilmiş karakter seçeneği varsa al, yoksa 0 al
        int saklananKarakterSecenegi =
            PlayerPrefs.GetInt("karakterSecenegi", 0);

        // Açılır listedeki değeri kaydedilen değere eşitle
        karakter.value = saklananKarakterSecenegi;
    }

    public void SahneDegistir(string sahneAdi)
    {
        // Seçilen karakter değerini kaydet
        PlayerPrefs.SetInt("karakterSecenegi", karakter.value);

        // Kaydı diske yaz
        PlayerPrefs.Save();

        // Sahnieyi değiştr
        SceneManager.LoadScene(sahneAdi);
    }

    public void OyunuKapat()
    {
        // Oyunu kapat
        Application.Quit();
    }
}
