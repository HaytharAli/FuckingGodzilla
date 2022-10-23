using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*TO-DO
 - Assign player number
 - Assign character number count up from 1 - 10 swapping between each player character incarnation 
 - Assign player character
*/

public class GameHost : MonoBehaviour
{
    public static GameHost instance;
    public GameObject playerPrefab;
    [SerializeField] GameObject player1, player2;
    private int roundNumber = 1;
    private float roundTimer;

    //UnityAction onRoundStart;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

    }
    void Start()
    {
        //onRoundStart += [Here goes any function that you want to be triggered by the event] 
        //EventChad.instance.onRoundStart.AddListener(onRoundStart);
        player1.GetComponent<CartersController>().PlayerNumber = 1;
        player2.GetComponent<CartersController>().PlayerNumber = 2;

        startingNewRound();
        EventChad.instance.onRoundStart.Invoke();
    }
     void Update()
     {
        roundTimer -= Time.deltaTime;
        Debug.Log("Time left in round: " + roundTimer);
        if(roundTimer < 0){
            startingNewRound();
            EventChad.instance.onRoundStart.Invoke();
        }
     }

     void spawnPlayer(int pNum, int roundNum)
     {
        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<CartersController>().PlayerNumber = pNum;
        player.GetComponent<CartersController>().CharacterNumber = (roundNum * 2) - 2 + pNum;
     }

     void startingNewRound(){
        roundTimer = 15;
        roundNumber++;
        spawnPlayer(1, roundNumber);
        spawnPlayer(2, roundNumber);
     }
}