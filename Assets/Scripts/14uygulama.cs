using UnityEngine;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    void Start()
    {
        int sayi1 = 60, sayi2 = 77, sayi3 = 77;
        int toplam = 0, fark = 0, carpim = 0, mod = 0;
        float bolum = 0;

        toplam = sayi1 + sayi2;
        fark = sayi1 - 10;
        carpim = sayi1 * sayi2;
        bolum = (float)sayi2 / sayi1;
        mod = 10 % 3;

        sayi1 = 2;
        sayi2 = 3;

        Debug.Log(sayi1 == sayi2);
        Debug.Log(sayi1 > sayi2);
        Debug.Log(sayi1 < sayi2);
        Debug.Log(sayi1 >= sayi2);
        Debug.Log(sayi1 <= sayi2);
        Debug.Log(sayi1 != sayi2);

        sayi1 = 2;
        sayi2 = 3;

        Debug.Log((sayi1 < sayi2) && (sayi1 > 0));
        Debug.Log((sayi1 > sayi2) && (sayi1 > 0));
        Debug.Log((sayi1 > sayi2) || (sayi1 > 0));
        Debug.Log(!(sayi1 > sayi2));
        Debug.Log(!(sayi1 > 0));

        sayi3 = sayi1;
        sayi1 += 1;
        Debug.Log(sayi1);

        sayi2 -= 1;
        Debug.Log(sayi2);

        sayi2 *= 2;
        Debug.Log(sayi2);

        sayi2 /= 2;
        Debug.Log(sayi2);

        sayi1 = 2;
        sayi2 = 3;
        sayi3 = 0;

        sayi1++;
        Debug.Log(sayi1);

        sayi2--;
        Debug.Log(sayi2);

        sayi3 = ++sayi1;
        Debug.Log(sayi3);

        sayi3 = sayi1++;
        Debug.Log(sayi3);
    }
}

