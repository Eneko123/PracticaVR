using UnityEngine;
using TMPro;

public class Buttons : MonoBehaviour
{
    public GameObject leftSable;
    public GameObject rigthSable;
    Counter counter;
    public TMP_Text countText;
    public TMP_Text leftText;
    public TMP_Text rigthText;

    void ActiveDesactiveLeftSable()
    {
        GameConfig.leftSableActive = !GameConfig.leftSableActive;
        if (GameConfig.leftSableActive)
            leftText.text = "Yes";
        else
            leftText.text = "No"; 
    }

    void ActiveDesactiveRigthSable()
    {
        GameConfig.rightSableActive = !GameConfig.rightSableActive;
        if (GameConfig.leftSableActive)
            rigthText.text = "Yes";
        else
            rigthText.text = "No";
    }

    void UpMax() { GameConfig.counterMax++; }
    void DownMax() { GameConfig.counterMax--; }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        countText.text = counter.GetMax().ToString();
    }
}
