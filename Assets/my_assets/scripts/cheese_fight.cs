using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese_fight : MonoBehaviour
{
    public GameObject gameState;
    private gameStateManager gameStateManager;

    public GameObject player;
    Animator cheeseAnim;



    void Start()
    {
        gameStateManager = gameState.GetComponent<gameStateManager>();
        cheeseAnim = this.GetComponent<Animator>();
    }


    void Update()
    {
            if (gameStateManager.cheeseFight == true)
            {
                //Debug.Log("Time to rot :D");
                Transform playerTransform = player.transform;
                transform.LookAt(playerTransform);
                this.transform.Translate(Vector3.forward * Time.deltaTime * 1);
                if (!gameStateManager.cheesePunching)
                {
                    cheeseAnim.SetBool("running", true);
                }
                if (gameStateManager.cheesePunching)
                {
                    cheeseAnim.SetBool("running", false);
                }
        }
            
    }
}
