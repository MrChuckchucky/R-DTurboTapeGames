using UnityEngine;
using System.Collections;

public class MatchMakingUI : MonoBehaviour
{
    void Start()
    {
        SetVisibility(false);
    }

    public void SetVisibility(bool active)
    {
        transform.GetChild(0).gameObject.SetActive(active);
    }

    public void LaunchMatchMaking()
    {
        MatchMakingManager.instance.RankedMatch();
        SetVisibility(false);
    }
}
