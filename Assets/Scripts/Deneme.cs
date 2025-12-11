using UnityEngine;
using UnityEngine.InputSystem;

public class Deneme : MonoBehaviour
{
    void Update()
    {
        float sagaSolaDegeri = 0f;

        if (Keyboard.current.aKey.isPressed)
            sagaSolaDegeri = -1;

        if (Keyboard.current.dKey.isPressed)
            sagaSolaDegeri = 1;

        Debug.Log("Yataydaki Sağ Sol Değeri = " + sagaSolaDegeri);

        if (Keyboard.current.spaceKey.isPressed)
        {
            Debug.Log("Space tuşuna basılı");
        }

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            Debug.Log("Geri tuşuna basıldı");
        }
    }
}
