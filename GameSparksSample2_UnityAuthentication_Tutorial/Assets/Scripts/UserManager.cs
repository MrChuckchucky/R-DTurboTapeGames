using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;

public class UserManager : MonoBehaviour
{
	public static UserManager instance;
     void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	//These are the account details we want to pull in
	public string userName;
	public string userId;
    public string opponentName;
    public string opponentId;
    public bool isFirst;

	// Use this for initialization
	void Start()
	{
        UpdateInformation();
	}

	public void UpdateInformation()
	{
		//We send an AccountDetailsRequest
		new AccountDetailsRequest().Send((response) =>
		{
			//We pass the details we want from our response to the function which will update our information
			UpdateGUI(response.DisplayName, response.UserId);
		});
	}

	public void UpdateGUI(string name, string uid)
	{
		userName = name;
		userId = uid;
	}
}
