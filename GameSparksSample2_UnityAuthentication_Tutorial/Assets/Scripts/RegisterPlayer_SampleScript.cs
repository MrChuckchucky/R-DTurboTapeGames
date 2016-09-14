using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterPlayer_SampleScript : MonoBehaviour {

	public Text displayNameInput, userNameInput, passwordInput; // these are set through the editor

    GameObject displayName, password, userName;

    void Start()
    {
        //Get the text box
        displayName = GameObject.FindGameObjectWithTag("DisplayName");
        password = GameObject.FindGameObjectWithTag("Password");
        userName = GameObject.FindGameObjectWithTag("UserName");
    }

	public void RegisterPlayerBttn()
	{
        //Request to create a new account
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