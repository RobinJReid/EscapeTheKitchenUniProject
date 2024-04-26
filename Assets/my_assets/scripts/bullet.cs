using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    //adapted from UNITY 3D SCHOOL ., 2021. Simple Shooting | 3D | Bullets | Unity Game Engine. [online video]. Nov 21. Available from: https://www.youtube.com/watch?v=EwiUomzehKU [Accessed 22 April 2024].
    public float life = 3;
    public gameStateManager gameStateManager; // Just one variable to hold the reference

    void Start()
    {
        // Find the gameStateManager object and get its component
        GameObject gameStateObject = GameObject.Find("gameStateManager");
        gameStateManager = gameStateObject.GetComponent<gameStateManager>();
    }

    void Awake()
    {
        StartCoroutine(destroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            gameStateManager.GetComponent<gameStateManager>().healPlayer(25);
            
        }
    }

    IEnumerator destroy()
    {
        
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject, life);
    }
}
