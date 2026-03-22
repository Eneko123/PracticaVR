using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter;
    public TMP_Text text;

    void Start()
    {
        counter = 0;
        UpdateText();
    }

    void Update()
    {
        WinCondition();
    }

    void WinCondition()
    {
        if (counter >= 20)
        {
            text.text = "¡HAS GANADO!";
        }
        else
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        text.text = counter + " / 20";
    }
}