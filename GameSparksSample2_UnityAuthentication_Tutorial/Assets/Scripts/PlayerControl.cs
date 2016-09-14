using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    bool canPlay;
    string[] gameBoard;

	void Start ()
    {
        gameBoard = new string[6];
        new GetChallengeRequest().SetChallengeInstanceId(TurnManager.instance.challengeInstanceId).Send((response) =>
        {
            gameBoard = response.Challenge.ScriptData.GetStringList("gameBoard").ToArray();
            if (response.HasErrors)
            {
                Debug.Log("Game load failed : " + response.Errors.JSON.ToString());
            }
            else
            {
                if (response.Challenge.NextPlayer == null && response.Challenge.Challenger.Id == UserManager.instance.userId)
                {
                    UserManager.instance.isFirst = true;
                    canPlay = true;
                }
                else if (response.Challenge.NextPlayer == null)
                {
                    UserManager.instance.isFirst = false;
                }
                else if (response.Challenge.NextPlayer == UserManager.instance.userId)
                {
                    canPlay = true;
                }
                if (GroundManager.instance.theGround == null)
                {
                    GroundManager.instance.Generation();
                }
                if (UserManager.instance.userId == gameBoard[0])
                {
                    Replace(gameBoard[2], TurnManager.instance.player);
                    Replace(gameBoard[5], TurnManager.instance.opponent);
                }
                else
                {
                    Replace(gameBoard[5], TurnManager.instance.player);
                    Replace(gameBoard[2], TurnManager.instance.opponent);
                }
                if(!canPlay)
                {
                    StartCoroutine(Check());
                }
            }
        });
	}

    void Replace(string pos, GameObject subject)
    {
        string[] position = pos.Split(';');
        string[] posX = position[0].Split('=');
        string[] posY = position[1].Split('=');
        string[] posZ = position[2].Split('=');
        string interX = "";
        string interZ = "";
        for (int i = 1; i < posX[1].Length; i++)
        {
            interX += posX[1][i];
        }
        for (int i = 0; i < posZ[1].Length - 1; i++)
        {
            interZ += posZ[1][i];
        }
        float x = float.Parse(posX[1]);
        float y = float.Parse(posY[1]);
        float z = float.Parse(interZ);
        subject.transform.position = new Vector3(x, y, z);
    }
	
	void Update ()
    {
        if (canPlay)
        {
            Vector3 pos = TurnManager.instance.player.transform.position;
            GroundManager.instance.Mouvement(pos.x, pos.z);
            canPlay = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.GetComponent<Renderer>().material.color == Color.blue)
                {
                    TurnManager.instance.player.transform.position = new Vector3(hit.collider.transform.position.x, 1, hit.collider.transform.position.z);
                }
            }
        }
	}

    public IEnumerator Check()
    {
        bool valid = false;
        while(!valid)
        {
            new GetChallengeRequest().SetChallengeInstanceId(TurnManager.instance.challengeInstanceId).Send((response) =>
            {
                gameBoard = response.Challenge.ScriptData.GetStringList("gameBoard").ToArray();
                if (response.HasErrors)
                {
                    Debug.Log("Game load failed : " + response.Errors.JSON.ToString());
                }
                else
                {
                    if(response.Challenge.NextPlayer == UserManager.instance.userId)
                    {
                        valid = true;
                        canPlay = true;
                        if (UserManager.instance.userId == gameBoard[0])
                        {
                            Replace(gameBoard[2], TurnManager.instance.player);
                            Replace(gameBoard[5], TurnManager.instance.opponent);
                        }
                        else
                        {
                            Replace(gameBoard[5], TurnManager.instance.player);
                            Replace(gameBoard[2], TurnManager.instance.opponent);
                        }
                    }
                }
            });
            yield return new WaitForSeconds(10);
        }
    }
}
