using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour
{
    public static GroundManager instance;
     void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    GameObject ground;
    GameObject groundsParent;

	// Use this for initialization
	public void Generation()
    {
        ground = Resources.Load("Ground") as GameObject;
        groundsParent = GameObject.FindGameObjectWithTag("GroundsParent");

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject oneGround = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                oneGround.transform.parent = groundsParent.transform;
            }
        }
        Spawn();
	}

    void Spawn()
    {
        if(UserManager.instance.isFirst)
        {
            GameObject player = GameObject.Instantiate(Resources.Load("Player"), new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            player.GetComponent<Renderer>().material.color = Color.red;
            GameObject opponent = GameObject.Instantiate(Resources.Load("Player"), new Vector3(4, 1, 4), Quaternion.identity) as GameObject;
            opponent.GetComponent<Renderer>().material.color = Color.blue;
            TurnManager.instance.player = player;
        }
        else
        {
            GameObject player = GameObject.Instantiate(Resources.Load("Player"), new Vector3(4, 1, 4), Quaternion.identity) as GameObject;
            player.GetComponent<Renderer>().material.color = Color.red;
            GameObject opponent = GameObject.Instantiate(Resources.Load("Player"), new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            opponent.GetComponent<Renderer>().material.color = Color.blue;
            TurnManager.instance.player = player;
        }
    }
}
