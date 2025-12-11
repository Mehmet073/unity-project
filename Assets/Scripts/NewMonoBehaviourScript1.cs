using UnityEngine;

public class overload : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Parametresiz Metot = " + Topla());
        Debug.Log("Bir Parametreli Metot = " + Topla(96));
        Debug.Log("İki Parametreli Metot = " + Topla(1000, 1));
    }

    public int Topla()
    {
        int sayi1 = 30, sayi2 = 3;
        return sayi1 + sayi2;
    }

    public int Topla(int sayi1)
    {
        int sayi2 = 3;
        return sayi1 + sayi2;
    }

    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }
}
