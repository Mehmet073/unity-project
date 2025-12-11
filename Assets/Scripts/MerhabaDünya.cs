using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int Arabahizi;
    private int oyuncuSkoru;
    int bla;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("merhaba  dünya");
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("arabanın hızı: "+Arabahizi);
    }
}
