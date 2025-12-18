# unity-project
## 🎯 Oyun Amacı

Bu oyun, oyuncunun ekranda gösterilen kelimenin doğru mu yanlış mı olduğunu hızlı bir şekilde analiz ederek doğru yöne hareket etmesini amaçlar.

Oyuncu, karakteri kontrol ederek doğru cevabı temsil eden alana yönelir ve sorulara fiziksel etkileşim (çarpışma) ile cevap verir.

Her doğru cevap oyuncuya puan kazandırırken, yanlış cevaplarda puan kaybı yaşanır.

Oyun belirli bir süre sınırı ve soru sayısı içerisinde oynanır. Süre dolduğunda veya tüm sorular cevaplandığında oyun sona erer ve oyuncunun toplam puanı ekranda gösterilir.

Oyunun amacı, oyuncunun hem hızlı düşünme hem de doğru karar verme becerilerini geliştirmektir.

Projenin çalışan hali:
![image alt](https://github.com/Mehmet073/unity-project/blob/3dc791bb7c1767e3a068d496c0c3823c49588b72/Kelime%20Macerasi%20-%20AnaSahne%20-%20Windows%2C%20Mac%2C%20Linux%20-%20Unity%206.1%20(6000.1.9f1)%20_DX12_%202025-12-18%2022-58-07.mp4)

Menü Ekranı:

![image alt](https://github.com/Mehmet073/unity-project/blob/be95d55a6f77469a04c716af169841d76cf1d986/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-18%20225505.png)

## 🕹️ Kodlar 

Kelime Oyun Kontorolü

```csharp
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class KelimeOyunKontrolu : MonoBehaviour
{

    public TextMeshPro soruEkranYazisi;
    public GameObject karakterGovdesi1, karakterGovdesi2;
    public TextMeshProUGUI puanYazisi, sureYazisi;
    public GameObject bitisEkrani;
    public TextMeshProUGUI bitisMesaji;

    public int TOPLAM_SURE_GENEL = 150;

    private int TOPLAM_SURE_AZALAN;
    private int puanDegiskeni = 0;
    private int soruSayisi = 0;
    private int saklananZorlukSecenegi = 0;
    private int saklananKarakterSecenegi = 0;
    private int sorulacakSoruSayisi;

    private List<Soru> sorularListesi;

    private bool oyuncuCevabi;
    private bool aktifSoruCevabi;
    private bool soruCevaplandiMi = true;


    [System.Serializable]
    public class Soru
    {
        public string Kelime;
        public bool DogruMu;
    }
    void Start()
    {

        saklananZorlukSecenegi = PlayerPrefs.GetInt("zorlukSecenegi", 0);


        if (saklananZorlukSecenegi == 0)
        {
            sorulacakSoruSayisi = 5;
        }
        else if (saklananZorlukSecenegi == 1)
        {
            sorulacakSoruSayisi = 10;
        }



        saklananKarakterSecenegi = PlayerPrefs.GetInt("karakterSecenegi", 0);


        if (saklananKarakterSecenegi == 0)
        {
            karakterGovdesi1.SetActive(true);
            karakterGovdesi2.SetActive(false);
        }
        else if (saklananKarakterSecenegi == 1)
        {
            karakterGovdesi1.SetActive(false);
            karakterGovdesi2.SetActive(true);
        }

        SorulariJSONdanOku();

        if (soruCevaplandiMi)
            SoruUret();

        TOPLAM_SURE_AZALAN = TOPLAM_SURE_GENEL;

        InvokeRepeating(nameof(SureSay), 0f, 1f);


    }


   private void SureSay()
{
    TOPLAM_SURE_AZALAN--;

    sureYazisi.text = "Süre = " + TOPLAM_SURE_AZALAN + " sn";
    Debug.Log("Kalan süre: " + TOPLAM_SURE_AZALAN);

    if (TOPLAM_SURE_AZALAN <= 0)
    {
        TOPLAM_SURE_AZALAN = TOPLAM_SURE_GENEL;
        CancelInvoke(nameof(SureSay));
        bitisEkrani.SetActive(true);
        bitisMesaji.text = "Süre bitti puanınız = " + puanDegiskeni;
    }
}


    private void KulCvbnaGoreIslem(int puan)
    {
        puanDegiskeni += puan;
        puanYazisi.text = "puan = " + puanDegiskeni;
        soruSayisi++;

        if(soruSayisi == sorulacakSoruSayisi)
        {
            soruEkranYazisi.text = puan + " Puan";
            puanYazisi.text = "Puan = " + (puanDegiskeni * 1);
            Invoke(nameof(BitisEkrani), 1f);
            bitisMesaji.text="Tebrikler,Puanınız = "+ (puanDegiskeni * 1);
            TOPLAM_SURE_AZALAN = TOPLAM_SURE_GENEL;
            CancelInvoke("SureSay");
        }
        else
        {
            soruEkranYazisi.text = puan + " Puan";
            StartCoroutine(BekleVeSoruUret(1f, 1f));
        }
    }


    IEnumerator BekleVeSoruUret(float saniye1, float saniye)
    {
        yield return new WaitForSeconds(saniye1);
        soruEkranYazisi.text = "Soru Hazırlanıyor";
        yield return new WaitForSeconds(saniye);
        SoruUret();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dogru") && !soruCevaplandiMi)
        {
            oyuncuCevabi = true;
            soruCevaplandiMi = true;
            if (aktifSoruCevabi == oyuncuCevabi)
                KulCvbnaGoreIslem(10);
            else
                KulCvbnaGoreIslem(-2);
        }
        else if(collision.gameObject.CompareTag("Yanlis") && !soruCevaplandiMi)
        {
            oyuncuCevabi = false;
            soruCevaplandiMi = true;
            if (aktifSoruCevabi == oyuncuCevabi)
                KulCvbnaGoreIslem(10);
            else
                KulCvbnaGoreIslem(-2);
        }
    }

    public void TekrarOyna()
    {

        bitisEkrani.SetActive(false);
        puanDegiskeni = 0;
        sureYazisi.text="Süre = "+TOPLAM_SURE_AZALAN.ToString()+"sn";
        puanYazisi.text = "Puan = 0";
        InvokeRepeating(nameof(SureSay), 0f, 1f);
        TOPLAM_SURE_AZALAN = TOPLAM_SURE_GENEL;
        soruSayisi = 0;
        if (soruCevaplandiMi)
            SoruUret();

    }

    void BitisEkrani()
    {
        soruEkranYazisi.text = "Oyun Bitti...";
        bitisEkrani.SetActive(true);
    }



    public void SorulariJSONdanOku()
    {
        string jsonText = Resources.Load<TextAsset>("Kelimeler").text;

        if (!string.IsNullOrEmpty(jsonText))
        {
            sorularListesi=JsonConvert.DeserializeObject<List<Soru>>(jsonText);
        }
    }
    public Soru RastgeleSoruOlustur()
    {
        int index = Random.Range(0, sorularListesi.Count);
        Soru secilenSoru = sorularListesi[index];
        sorularListesi.RemoveAt(index);
        return secilenSoru;
    }
    public void SoruUret()
    {
        Soru aktifSoru = RastgeleSoruOlustur();

        string aktifSoruMetni = aktifSoru.Kelime;
        aktifSoruCevabi = aktifSoru.DogruMu;

        soruEkranYazisi.text = (soruSayisi + 1) +" - "+aktifSoruMetni;

        soruCevaplandiMi=false;

    }

}
```
Karakter hareket kodları :

```csharp
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
        
        float ileriGeri = Input.GetAxis("Vertical");

        
        float sagaSola = Input.GetAxis("Horizontal");

        Vector3 hareket =
            transform.forward * ileriGeri +
            transform.right * sagaSola;

        hareket *= hareketHizi * Time.deltaTime;
        transform.Translate(hareket, Space.World);

       
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float donme = mouseX * donmeHizi * Time.deltaTime;
            transform.Rotate(Vector3.up, donme);
        }

        
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

```
