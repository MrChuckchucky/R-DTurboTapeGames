using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public GameObject[,] theGround;

	// Use this for initialization
	public void Generation()
    {
        theGround = new GameObject[5, 5];
        ground = Resources.Load("Ground") as GameObject;
        groundsParent = GameObject.FindGameObjectWithTag("GroundsParent");

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                GameObject oneGround = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                oneGround.transform.parent = groundsParent.transform;
                theGround[i, j] = oneGround;
            }
        }
        StartCoroutine(SpawnTime());
	}

    IEnumerator SpawnTime()
    {
        StartCoroutine(MatchMakingManager.instance.LoadInformations());
        yield return new WaitForSeconds(60);
        StopCoroutine(MatchMakingManager.instance.LoadInformations());
        MatchMakingManager.instance.debug.GetComponent<Text>().text = "";
        Spawn();
    }

    public void Regeneration()
    {
        theGround = new GameObject[5, 5];
        ground = Resources.Load("Ground") as GameObject;
        groundsParent = GameObject.FindGameObjectWithTag("GroundsParent");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject oneGround = Instantiate(ground, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                oneGround.transform.parent = groundsParent.transform;
                theGround[i, j] = oneGround;
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
            TurnManager.instance.opponent = opponent;
        }
        else
        {
            GameObject player = GameObject.Instantiate(Resources.Load("Player"), new Vector3(4, 1, 4), Quaternion.identity) as GameObject;
            player.GetComponent<Renderer>().material.color = Color.red;
            GameObject opponent = GameObject.Instantiate(Resources.Load("Player"), new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            opponent.GetComponent<Renderer>().material.color = Color.blue;
            TurnManager.instance.player = player;
            TurnManager.instance.opponent = opponent;
        }
        TurnManager.instance.player.AddComponent<PlayerControl>();
    }

    public void Reinit()
    {
        foreach(GameObject oneGround in theGround)
        {
            oneGround.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Mouvement(float indexX, float indexY)
    {
        int posX = int.Parse(Mathf.RoundToInt(indexX).ToString());
        int posY = int.Parse(Mathf.RoundToInt(indexY).ToString());
        if (posX > 0)
        {
            theGround[posX - 1, posY].GetComponent<Renderer>().material.color = Color.blue;
        }
        if(posX < 4)
        {
            theGround[posX + 1, posY].GetComponent<Renderer>().material.color = Color.blue;
        }
        if (posY > 0)
        {
            theGround[posX, posY - 1].GetComponent<Renderer>().material.color = Color.blue;
        }
        if (posY < 4)
        {
            theGround[posX, posY + 1].GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
