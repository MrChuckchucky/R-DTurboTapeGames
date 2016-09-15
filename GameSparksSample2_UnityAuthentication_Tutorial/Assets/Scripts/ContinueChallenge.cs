using UnityEngine;
using System.Collections;

public class ContinueChallenge : MonoBehaviour
{
    GameObject me;
    GameObject matchMakingButton;

	void Start ()
    {
        matchMakingButton = GameObject.FindGameObjectWithTag("MatchMaking");
        me = this.gameObject;
        Enable(false);
	}

    public void Enable(bool active)
    {
        //Show/Hide the buttons Yes and No to continue the challenge
        for (int i = 0; i < me.transform.childCount; i++)
        {
            me.transform.GetChild(i).gameObject.SetActive(active);
        }
    }

    public void Yes()
    {
        //Collect informations
        Enable(false);
        GroundManager.instance.Regeneration();
        TurnManager.instance.challengeInstanceId = MatchMakingManager.instance.challengeId;
    }

    public void No()
    {
        //Hide the buttons
        Enable(false);
        matchMakingButton.GetComponent<MatchMakingUI>().SetVisibility(true);
    }
}
