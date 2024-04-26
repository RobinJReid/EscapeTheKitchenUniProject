using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class health : MonoBehaviour
{
    public GameObject GameState;
    public GameObject Player;
    public Vector3 startLocation;
    public GameObject gamestate;
    private gameStateManager gameStateManager;
    public bool hasteleported;
    public GameObject particle;


    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = gamestate.GetComponent<gameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameStateManager.isTeleporting)
        {

        
        Debug.Log(other.tag + gameObject.tag);
        if (other.gameObject.tag == "weapon" && gameObject.tag == "giant")
            {
            Debug.Log("AAAAAAAA");
                var effect = Instantiate(particle, this.transform.position, this.transform.rotation);
                GameState.GetComponent<gameStateManager>().TakeDamageGiant(25);

        }
        if (other.gameObject.tag == "giant" && gameObject.tag == "Player")
        {
            Debug.Log("PLAYER TAKING DAMAGE");
            GameState.GetComponent<gameStateManager>().TakeDamagePlayer(25);
            var effect = Instantiate(particle, this.transform.position, this.transform.rotation);

            }
        if (other.gameObject.tag == "cheese" && gameObject.tag == "Player")
        {
             if (gameStateManager.cheeseFight)
             {
                 Debug.Log("CHEESE doing DAMAGE");
                 GameState.GetComponent<gameStateManager>().TakeDamagePlayer(10);
                 var effect = Instantiate(particle, this.transform.position, this.transform.rotation);
             }
           

            }
        if (other.gameObject.tag == "weapon" && gameObject.tag == "cheese")
        {
            Debug.Log("AAAAAAAA");
            if (gameStateManager.cheeseFight)
                {
                    GameState.GetComponent<gameStateManager>().TakeDamageCheese(25);
                    var effect = Instantiate(particle, this.transform.position, this.transform.rotation);
                }
            

            }
        if(other.gameObject.tag == "weapon" && gameObject.tag == "door")
        {
            //Debug.Log("TELEPORTING PLAYER");
            gameStateManager.isTeleporting = true;
            //Debug.Log(startLocation);
            Player.transform.position = startLocation;
            //Debug.Log(Player.transform.position);
            Player.transform.position = startLocation;
            hasteleported = true;
            if (Player.transform.position == startLocation)
            {
                //Debug.Log("player transform detected");
                StartCoroutine(waitAfterTeleport());
            }
        }

    }
        if (other.gameObject.tag == "cheese" && gameObject.tag == "attack_radius")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAESYRDUTYUKLKKIUYETWRTAYUIKL;UYTRFEGARSHTJYKUTLIY;OLKJYTHGREFDFGAHTJYUKTLIY;KJYTHGREFRTYRKULTIOIUYTERWETARYUTIKLIYTRETARWwraetsrytdyfkg");
            GameState.GetComponent<gameStateManager>().cheeseAttack();
        }

    }
    IEnumerator waitAfterTeleport()
    {
        yield return new WaitForSecondsRealtime(2);
        gameStateManager.giantBgMusic.Play();
        gameStateManager.isTeleporting = false;
        Debug.Log("Waited for 2 seconds in real time!");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cheese" && gameObject.tag == "attack_radius")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAESYRDUTYUKLKKIUYETWRTAYUIKL;UYTRFEGARSHTJYKUTLIY;OLKJYTHGREFDFGAHTJYUKTLIY;KJYTHGREFRTYRKULTIOIUYTERWETARYUTIKLIYTRETARWwraetsrytdyfkg");
            GameState.GetComponent<gameStateManager>().cheeseAttackStop();
        }
    }
}
