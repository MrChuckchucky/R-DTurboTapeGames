using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    bool canPlay;
    string[] gameBoard;
    GameObject endTurnButton;

	void Start ()
    {
        endTurnButton = GameObject.FindGameObjectWithTag("EndTurn");
        gameBoard = new string[6];
        //Request to load information from the server
        new GetChallengeRequest().SetChallengeInstanceId(TurnManager.instance.challengeInstanceId).Send((response) =>
        {
            //gameBoard is the values that the server store
            gameBoard = response.Challenge.ScriptData.GetStringList("gameBoard").ToArray();
            if (response.HasErrors)
            {
                Debug.Log("Game load failed : " + response.Errors.JSON.ToString());
            }
            else
            {
                //Check if it's your turn
                if (response.Challenge.NextPlayer == UserManager.instance.userId)
                {
                    canPlay = true;
                }
                //Place the player at the right place and your player is always the red and the blue is always your opponnent
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
                //If it's not your turn, check every 10 seconds if your opponent have played
                if(!canPlay)
                {
                    StartCoroutine(Check());
                }
            }
        });
	}

    //Transform the string into position value
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
        //Change the position of the characters with the informations from the server
        subject.transform.position = new Vector3(x, y, z);
    }
	
	void Update ()
    {
        if (canPlay)
        {
            //Change the color of the ground where you can move
            Vector3 pos = TurnManager.instance.player.transform.position;
            GroundManager.instance.Mouvement(pos.x, pos.z);
            canPlay = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            //Move your character if you clic on a blue ground
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.GetComponent<Renderer>().material.color == Color.blue)
                {
                    TurnManager.instance.player.transform.position = new Vector3(hit.collider.transform.position.x, 1, hit.collider.transform.position.z);
                    endTurnButton.GetComponent<EndTurnUI>().SetVisibility(true);
                }
            }
        }
	}

    public IEnumerator Check()
    {
        //Send a request every 10 seconds to know if your opponnent have played
        bool valid = false;
        while(!valid)
        {
            new GetChallengeRequest().SetChallengeInstanceId(TurnManager.instance.challengeInstanceId).Send((response) =>
            {
                //Get the new gameBoard
                gameBoard = response.Challenge.ScriptData.GetStringList("gameBoard").ToArray();
                if (response.HasErrors)
                {
                    Debug.Log("Game load failed : " + response.Errors.JSON.ToString());
                }
                else
                {
                    //If it's your turn
                    if(response.Challenge.NextPlayer == UserManager.instance.userId)
                    {
                        //Stop the coroutine
                        valid = true;
                        //Set up your movement
                        canPlay = true;
                        //Change the position of the characters
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
