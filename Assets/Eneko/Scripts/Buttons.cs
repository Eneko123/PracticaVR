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
        if (leftSable.activeSelf) { leftSable.SetActive(false); leftText.text = "No"; }
        else { leftSable.SetActive(true); leftText.text = "Yes"; }
    }

    void ActiveDesactiveRigthSable()
    {
        if (rigthSable.activeSelf) { rigthSable.SetActive(false); rigthText.text = "No"; }
        else { rigthSable.SetActive(true); rigthText.text = "Yes"; }
    }

    void UpMax()
    {
        counter.SetMax(counter.GetMax() + 1);
    }
    void DownMax()
    {
        counter.SetMax(counter.GetMax() - 1);
    }

    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        countText.text = counter.GetMax().ToString();
    }
}
