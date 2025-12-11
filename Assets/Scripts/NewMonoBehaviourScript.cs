using UnityEngine;

public class NewMonoBehaviourScriptr3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    int toplam1 = 0;

    for (int i = 1; i <= 10; i++)
    {
        toplam1 += i;
    }

    Debug.Log("Toplam (for): " + toplam1);

    int toplam2 = 0;
    int sayac = 1;

    while (sayac <= 10)
    {
        toplam2 += sayac;
        sayac++;
    }

    Debug.Log("Toplam (while): " + toplam2);
}

}
