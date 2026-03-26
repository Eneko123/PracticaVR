using UnityEngine;

public class SableManager : MonoBehaviour
{
    public GameObject leftSable;
    public GameObject rightSable;

    void Start()
    {
        leftSable.SetActive(GameConfig.leftSableActive);
        rightSable.SetActive(GameConfig.rightSableActive);
    }
}
