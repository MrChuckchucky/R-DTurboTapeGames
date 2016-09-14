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
    public static MatchMakingManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public GameObject debug;
    bool found;
    public string challengeId;
    string opponentId;
    string opponentName;
    GameObject popUp;
    
    void Start()
    {
        GameSparks.Api.Messages.MatchFoundMessage.Listener += OnMatchFound;
        debug = GameObject.FindGameObjectWithTag("Debug");
        CurrentChallenge();
        popUp = GameObject.FindGameObjectWithTag("Continue");
    }

	// Use this for initialization
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RankedMatch();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FindChallenge());
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
        debug.GetComponent<Text>().text = "";
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
            CreateChallenge();
        }
        else
        {
            StartCoroutine(FindChallenge());
        }
    }

    void CreateChallenge()
    {
        List<string> opponents = new List<string>();
        opponents.Add(UserManager.instance.opponentId);
        DateTime date = DateTime.Today.AddMonths(1);
        new CreateChallengeRequest().SetChallengeShortCode("RankedChallenge").SetAccessType("PRIVATE").SetStartTime(DateTime.Today.AddDays(1)).SetMaxPlayers(2).SetAutoStartJoinedChallengeOnMaxPlayers(false).SetUsersToChallenge(opponents).SetEndTime(date).Send((response) =>
        {
            if(response.HasErrors)
            {
                Debug.Log("fail" + response.Errors.JSON.ToString());
            }
            else
            {
                TurnManager.instance.challengeInstanceId = response.ChallengeInstanceId;
                StartCoroutine(FindChallenge());
                //GroundManager.instance.Generation();
            }
        });
    }

    void CurrentChallenge()
    {
        int index = 0;
        List<string> states = new List<string>();
        states.Add("RUNNING");
        new ListChallengeRequest().SetStates(states).Send((response) =>
        {
            foreach(var challenge in response.ChallengeInstances)
            {
                if(challenge.NextPlayer == UserManager.instance.userId)
                {
                    index++;
                    if(index == 1)
                    {
                        challengeId = challenge.ChallengeId;
                        if (challenge.Challenger.Id != UserManager.instance.userId)
                        {
                            opponentId = challenge.Challenger.Id;
                            opponentName = challenge.Challenger.Name;
                        }
                        else
                        {
                            UserManager.instance.isFirst = true;
                            foreach (var player in challenge.Challenged)
                            {
                                if (player.Id != UserManager.instance.userId)
                                {
                                    opponentId = player.Id;
                                }
                            }
                        }
                    }
                }
            }
            Debug.Log(index + " challenges to play");
            if(index > 0)
            {
                SpawnPopUp();
            }
        });
    }

    void SpawnPopUp()
    {
        debug.GetComponent<Text>().text = "Continue against " + opponentName + " ?";
        popUp.GetComponent<ContinueChallenge>().Enable(true);
    }

    IEnumerator FindChallenge()
    {
        bool valid = false;
        while (!valid)
        {
            new ListChallengeRequest().SetState("ISSUED").Send((response) =>
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

    public IEnumerator LoadInformations()
    {
        int index = 0;
        while (index != 30)
        {
            index++;
            debug.GetComponent<Text>().text = "LoadInformations";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "LoadInformations.";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "LoadInformations..";
            yield return new WaitForSeconds(0.5f);
            debug.GetComponent<Text>().text = "LoadInformations...";
            yield return new WaitForSeconds(0.5f);
        }
        debug.GetComponent<Text>().text = "";
    }
}
