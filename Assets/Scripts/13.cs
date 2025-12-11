using UnityEngine;
using System.Collections.Generic;
public class NewMonoBehaviourScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       int sayi1 = 77;

    int sayi2;
    sayi2 = 60;

    string[] iller = new string[] { "Yalova", "Tokat", "Tekirdağ" };

    int[] sayilar = new int[3];
    sayilar[0] = 9;
    sayilar[1] = 8;
    sayilar[2] = 3;

    List<int> sayilar2 = new() { 1, 2, 3 };

    List<string> iller2 = new();
    iller2.Add("İstanbul");
    iller2.Add("Bursa");
    iller2.Add("Konya");

    Debug.Log("sayi2 = " + sayi2);
    Debug.Log("iller dizisinin 2. elemanı: " + iller[2]);
    Debug.Log("iller2 listesinin 3. elemanı: " + iller2[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
