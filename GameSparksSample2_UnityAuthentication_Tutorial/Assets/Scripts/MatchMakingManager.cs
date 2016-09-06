using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameSparks;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using System;

public class MatchMakingManager : MonoBehaviour
{
    GameObject debug;
    bool found;
    
    void Start()
    {
        GameSparks.Api.Messages.MatchFoundMessage.Listener += OnMatchFound;
        debug = GameObject.FindGameObjectWithTag("Debug");
    }

	// Use this for initialization
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RankedMatch();
        }
	}

    void RankedMatch()
    {
        new GameSparks.Api.Requests.MatchmakingRequest().SetMatchShortCode("RankedMatch").SetSkill(100).Send((response) =>
            {
                if (!response.HasErrors)
                {
                    StartCoroutine("ResearchMatch");
                }
                else
                {
                    found = true;
                    debug.GetComponent<Text>().text = "MatchNotFound";
                    Debug.Log("Error Matching Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }

    void OnMatchFound(GameSparks.Api.Messages.MatchFoundMessage message)
    {
        StopCoroutine("ResearchMatch");
        string matchId = message.MatchId;
        found = true;
        bool first = false;
        foreach(GameSparks.Api.Messages.MatchFoundMessage._Participant player in message.Participants)
        {
            if(!first)
            {
                first = true;
                if(UserManager.instance.userId == player.Id)
                {
                    UserManager.instance.isFirst = true;
                }
            }
            if(UserManager.instance.userId != player.Id)
            {
                UserManager.instance.opponentId = player.Id;
                UserManager.instance.opponentName = player.DisplayName;
            }
        }
        if(UserManager.instance.isFirst)
        {
            StartCoroutine(FindChallenge());
        }
        else
        {
            CreateChallenge(matchId);
        }
    }

    void CreateChallenge(string ID)
    {
        List<string> opponents = new List<string>();
        opponents.Add(UserManager.instance.opponentId);
        DateTime date = DateTime.Today.AddDays(1);
        new CreateChallengeRequest().SetChallengeShortCode("RankedChallenge").SetAccessType("PRIVATE").SetAutoStartJoinedChallengeOnMaxPlayers(true).SetUsersToChallenge(opponents).SetEndTime(date).Send((response) =>
        {
            if(response.HasErrors)
            {
                Debug.Log("fail" + response.Errors.JSON.ToString());
            }
            else
            {
                TurnManager.instance.challengeInstanceId = response.ChallengeInstanceId;
                Debug.Log(response.ChallengeInstanceId);
                GroundManager.instance.Generation();
            }
        });
    }

    IEnumerator FindChallenge()
    {
        bool valid = false;
        List<string> states = new List<string>();
        //states.Add("WAITING");
        states.Add("RUNNING");
        /*states.Add("ISSUED");
        states.Add("RECEIVED");
        states.Add("COMPLETE");
        states.Add("DECLINED");*/
        while (!valid)
        {
            new ListChallengeRequest().SetStates(states).Send((response) =>
            {
                foreach (var challenge in response.ChallengeInstances)
                {
                    new AcceptChallengeRequest().SetChallengeInstanceId(challenge.ChallengeId).Send((responses) =>
                    {
                        if (!response.HasErrors)
                        {
                            TurnManager.instance.challengeInstanceId = challenge.ChallengeId;
                            valid = true;
                            GroundManager.instance.Generation();
                            StopCoroutine("FindChallenge");
                        }
                    });
                }
            });
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator ResearchMatch()
    {
        int index = 0;
        while(!found && index < 30)
        {
            index++;
            debug.GetComponent<Text>().text = "ResearchMatch";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "ResearchMatch.";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "ResearchMatch..";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "ResearchMatch...";
            yield return new WaitForSeconds(0.5f);
        }
        debug.GetComponent<Text>().text = "";
    }
}
