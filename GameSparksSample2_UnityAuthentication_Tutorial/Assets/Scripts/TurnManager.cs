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

    //Informations that you need to send informations on the server. Kill isn't used for the moment
    int kill;
    public GameObject player;
    public GameObject opponent;
    GameObject endTurnButton;
    public string challengeInstanceId = "";

    void Start()
    {
        endTurnButton = GameObject.FindGameObjectWithTag("EndTurn");
    }

    public void EndTurn()
    {
        //Transform informations into a string to send things to the server
        string pos = "{x = " + player.transform.position.x + "; y = " + player.transform.position.y + "; z = " + player.transform.position.z + "}";
        //Request to update the ScriptData on the server
        new LogChallengeEventRequest().SetChallengeInstanceId(challengeInstanceId).SetEventKey("LifeCount").SetEventAttribute("pid",UserManager.instance.userId).SetEventAttribute("kill",kill).SetEventAttribute("pos", pos).Send((response) =>
        {
            if(response.HasErrors)
            {
                Debug.Log("fail" + response.Errors.JSON.ToString());
            }
            else
            {
                Debug.Log("success");
                //Recolor the ground
                GroundManager.instance.Reinit();
                //Send a request every 10 seconds to check if the other player have played
                player.GetComponent<PlayerControl>().StartCoroutine("Check");
                endTurnButton.GetComponent<EndTurnUI>().SetVisibility(false);
            }
        });
    }
}
