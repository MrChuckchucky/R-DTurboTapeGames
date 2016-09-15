using UnityEngine;
using System.Collections;

public class EndTurnUI : MonoBehaviour
{
    void Start()
    {
        SetVisibility(false);
    }

    public void SetVisibility(bool active)
    {
        transform.GetChild(0).gameObject.SetActive(active);
    }
}
