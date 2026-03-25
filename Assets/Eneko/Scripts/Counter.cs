using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter;
    public TMP_Text text;
    private int counterMax = 20;

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
        if (counter >= counterMax)
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

    public int GetMax() { return counterMax; }
    public void SetMax(int newMax) { counterMax = newMax; } 
}