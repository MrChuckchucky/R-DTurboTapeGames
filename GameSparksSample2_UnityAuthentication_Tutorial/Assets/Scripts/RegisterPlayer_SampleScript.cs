using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterPlayer_SampleScript : MonoBehaviour {

	public Text displayNameInput, userNameInput, passwordInput; // these are set through the editor

    GameObject displayName, password, userName;

    void Start()
    {
        displayName = GameObject.FindGameObjectWithTag("DisplayName");
        password = GameObject.FindGameObjectWithTag("Password");
        userName = GameObject.FindGameObjectWithTag("UserName");
    }

	public void RegisterPlayerBttn()
	{
		Debug.Log ("Registering Player...");
        /*displayNameInput.text = displayName.transform.GetChild(2).GetComponent<Text>().text;
        passwordInput.text = password.transform.GetChild(2).GetComponent<Text>().text;
        userNameInput.text = userName.transform.GetChild(2).GetComponent<Text>().text;
        new GameSparks.Api.Requests.RegistrationRequest ()
			.SetDisplayName (displayNameInput.text)
			.SetUserName (userNameInput.text)
			.SetPassword (passwordInput.text)
			.Send ((response) => {

					if(!response.HasErrors)
					{
						Debug.Log("Player Registered \n User Name: "+response.DisplayName);
					}
					else
					{
						Debug.Log("Error Registering Player... \n "+response.Errors.JSON.ToString());
					}
		});*/
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayName.transform.GetChild(2).GetComponent<Text>().text)
            .SetUserName(userName.transform.GetChild(2).GetComponent<Text>().text)
            .SetPassword(password.transform.GetChild(2).GetComponent<Text>().text)
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Player Registered \n User Name: " + response.DisplayName);
                }
                else
                {
                    Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }
}