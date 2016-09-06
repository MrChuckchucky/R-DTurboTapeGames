using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSparks.Core;
using System.Collections.Generic;

public class SaveLoad_SampleScript : MonoBehaviour {


	public Text experiancePoints, playerGold;
	public GameObject playerRefrence;
	public Text[] loadedData;

    GameObject xp, position, gold;

    void Start()
    {
        xp = GameObject.FindGameObjectWithTag("XP");
        position = GameObject.FindGameObjectWithTag("Position");
        gold = GameObject.FindGameObjectWithTag("Gold");
    }


	public void SavePlayerBttn()
	{
		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("SAVE_PLAYER")
			.SetEventAttribute ("XP", xp.transform.GetChild(2).GetComponent<Text>().text)
			.SetEventAttribute ("POS", position.transform.GetChild(2).GetComponent<Text>().text)
			.SetEventAttribute ("GOLD", gold.transform.GetChild(2).GetComponent<Text>().text)
			.Send ((response) => {

					if(!response.HasErrors)
					{
						Debug.Log("Player Saved To GameSparks...");
					}
					else
					{
						Debug.Log("Error Saving Player Data...");
					}
		});
	}

	public void LoadPlayerBttn()
	{
		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("LOAD_PLAYER")
				.Send ((response) => {
					
					if(!response.HasErrors)
					{
						Debug.Log("Recieved Player Data From GameSparks...");
						GSData data = response.ScriptData.GetGSData("player_Data");
						Debug.Log("Player ID: "+data.GetString("playerID"));
                        Debug.Log("Player XP: " +data.GetString("playerXP"));
                        Debug.Log("Player Gold: " +data.GetString("playerGold"));
                        Debug.Log("Player Pos: " +data.GetString("playerPos"));
					}
					else
					{
						Debug.Log("Error Loading Player Data...");
					}
				});
	}
}








