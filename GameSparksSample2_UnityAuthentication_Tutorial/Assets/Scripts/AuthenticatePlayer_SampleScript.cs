﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AuthenticatePlayer_SampleScript : MonoBehaviour 
{
	public Text userNameInput, passwordInput; // these are set through the editor

    GameObject userName, password;

    void Start()
    {
        //Get the text box
        userName = GameObject.FindGameObjectWithTag("AuthUserName");
        password = GameObject.FindGameObjectWithTag("AuthPassword");
    }
	
	public void AuthorizePlayerBttn()
	{
        //Send an authentication request with an account
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName (userName.transform.GetChild(2).GetComponent<Text>().text)
			.SetPassword (password.transform.GetChild(2).GetComponent<Text>().text)
			.Send ((response) => {

					if(!response.HasErrors)
					{
						Debug.Log("Player Authenticated... \n User Name: "+response.DisplayName);
                        Application.LoadLevel("Fight");
					}
					else
					{
						Debug.Log("Error Authenticating Player... \n "+response.Errors.JSON.ToString());
					}

		});
	}

	public void AuthenticateDeviceBttn()
	{
        //Request to authenticate yourself with your device. Not reachable in the prototype
		new GameSparks.Api.Requests.DeviceAuthenticationRequest ()
			.SetDisplayName ("Randy")
			.Send ((response) => {

					if(!response.HasErrors)
					{
						Debug.Log("Device Authenticated...");
					}
					else 
					{
						Debug.Log("Error Authenticating Device...");
					}
		});
	}
}

