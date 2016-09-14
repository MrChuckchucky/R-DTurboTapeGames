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
    
    //Usefull informations
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
		//We send an AccountDetailsRequest to get the informations of the authenticate player
		new AccountDetailsRequest().Send((response) =>
		{
			UpdateInformations(response.DisplayName, response.UserId);
		});
	}

	public void UpdateInformations(string name, string uid)
	{
		userName = name;
		userId = uid;
	}
}
