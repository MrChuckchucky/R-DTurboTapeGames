using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    int kill;
    public GameObject player;
    public GameObject opponent;
    public string challengeInstanceId = "";

    public void EndTurn()
    {
        string pos = "{x = " + player.transform.position.x + "; y = " + player.transform.position.y + "; z = " + player.transform.position.z + "}";
        new LogChallengeEventRequest().SetChallengeInstanceId(challengeInstanceId).SetEventKey("LifeCount").SetEventAttribute("pid",UserManager.instance.userId).SetEventAttribute("kill",kill).SetEventAttribute("pos", pos).Send((response) =>
        {
            if(response.HasErrors)
            {
                Debug.Log("fail" + response.Errors.JSON.ToString());
            }
            else
            {
                Debug.Log("success");
                GroundManager.instance.Reinit();
                player.GetComponent<PlayerControl>().StartCoroutine("Check");
            }
        });
    }
}
