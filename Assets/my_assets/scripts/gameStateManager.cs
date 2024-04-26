using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class gameStateManager : MonoBehaviour
{
    public Image playerHealthBar;
    public Image otherHealthBar;

    public int currentHealth;
    public int maxhealth = 100;
    public int giantHealth;
    public int giantMaxHealth = 100;
    public int cheeseHealth;
    public int cheeseMaxHealth = 100;
    public bool isTeleporting = false;
    public bool giantDead = false;

    bool docutscene1;

    public AudioSource cutscene1;
    public AudioSource cutscene2;
    public AudioSource cutscene3;

    public AudioSource giantBgMusic;
    public AudioSource cheeseBgMusic;

    public GameObject cursedPrefab;
    public GameObject ghostprefab;
    public GameObject sparkles;
    public GameObject skull;


    public GameObject cheeseObject;
    public Vector3 cheeseLocation;
    public Quaternion cheeseRotation;
    private ParticleSystem cheesePart;
    Animator cheeseAnim;
    private bool cheeseForward;
    public bool cheeseFight;
    public bool cheesePunching;

    public GameObject playerObject;
    private ParticleSystem playerPart;
    public Vector3 playerLocation;
    public Quaternion playerRotation;
    public GameObject playerAnimObject;
    Animator playerAnim;

    public GameObject soySauce;
    private ParticleSystem soyPart;

    public GameObject blueberries;
    private ParticleSystem bluesPart;

    public GameObject blueberry;
    private ParticleSystem blueberryPart;
    public Quaternion blueberryRotation;
    public Vector3 blueberryLocation;

    public GameObject other_food;
    private ParticleSystem otherPart;

    void Start()
    {
        docutscene1 = true;
        giantHealth = giantMaxHealth;
        isTeleporting = false;
        cheesePart = cheeseObject.GetComponent<ParticleSystem>();
        cheeseAnim = cheeseObject.GetComponent<Animator>();

        playerPart = playerObject.GetComponent<ParticleSystem>();
        playerAnim = playerAnimObject.GetComponent<Animator>();

        soyPart = soySauce.GetComponent<ParticleSystem>();

        bluesPart = blueberries.GetComponent<ParticleSystem>();

        blueberryPart = blueberry.GetComponent<ParticleSystem>();

        otherPart = other_food.GetComponent<ParticleSystem>();
        if (docutscene1)
        {
            StartCoroutine(startScene());
        }
        cheeseForward = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (cheeseForward)
        {
            cheeseObject.transform.Translate(Vector3.forward * Time.deltaTime * 1);
        }
        playerHealthBar.fillAmount = currentHealth / 100f;
        if (cheeseFight)
        {
            otherHealthBar.fillAmount = cheeseHealth / 100f;
        }
        if (!cheeseFight)
        {
            otherHealthBar.fillAmount = giantHealth / 100f;
        }
    }

    public void cheeseAttack()
    {
        if (cheeseFight)
        {

            Debug.Log("cheese attack goin on");
            cheeseAnim.SetBool("punching", true);
            cheesePunching = true;
        }
        
    }
    public void cheeseAttackStop()
    {
        if (cheeseFight)
        {
            Debug.Log("cheese attack stopping");
            cheeseAnim.SetBool("punching", false);
            cheesePunching = false;
        }

    }

    public void TakeDamageGiant(int amount)
    {

        giantHealth -= amount;
        if (giantHealth <= 0)
        {
            Debug.Log("Giant is ded");
            giantDead = true;
            GameObject giant = GameObject.Find("ellie_tpose");
            Destroy(giant);
            StartCoroutine(cheeseScene());
        }
        Debug.Log(giantHealth);
        Debug.Log("Damage has been taken");
    }

    public void TakeDamagePlayer(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.Log("player is ded");
            SceneManager.LoadScene("game_over");
            Debug.Log("trying to load level");

        }
        Debug.Log(currentHealth);
        Debug.Log("players been hurt");
    }
    public void TakeDamageCheese(int amount)
    {

        cheeseHealth -= amount;
        if (cheeseHealth <= 0)
        {
            Debug.Log("cheese is ded");
            cheeseBgMusic.Stop();
            StartCoroutine(finalScene());
        }
        Debug.Log(cheeseHealth);
        Debug.Log("cheese been hurt");
    }

    public void healPlayer(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxhealth)
        {
            currentHealth = maxhealth;
            Debug.Log("JUST HEALED PLAYER BY " + amount);
        }
    }
    
    IEnumerator startScene()
    {
        isTeleporting = true;
        cutscene1.Play();
        yield return new WaitForSecondsRealtime(1);
        cheesePart.Play();
        
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(1);
        var effect = Instantiate(sparkles, cheeseObject.transform.position, cheeseObject.transform.rotation);
        yield return new WaitForSecondsRealtime(18);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(7);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(63);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(4);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(30);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(7);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(16);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(4);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(23);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(5);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(36);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(6);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(4);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        otherPart.Play();
        yield return new WaitForSecondsRealtime(16);
        otherPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(6);
        playerPart.Stop();
        soyPart.Play();
        yield return new WaitForSecondsRealtime(7);
        soyPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(8);
        playerPart.Stop();
        soyPart.Play();
        var effect2 = Instantiate(skull, soySauce.transform.position, soySauce.transform.rotation);
        yield return new WaitForSecondsRealtime(8);
        soyPart.Stop();
        bluesPart.Play();
        yield return new WaitForSecondsRealtime(4);
        bluesPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(11);
        playerPart.Stop();
        cheesePart.Play();
        cheeseAnim.SetBool("talking", true);
        yield return new WaitForSecondsRealtime(8);
        cheesePart.Stop();
        cheeseAnim.SetBool("talking", false);
        bluesPart.Play();
        yield return new WaitForSecondsRealtime(3);
        bluesPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(11);
        playerPart.Stop();
        blueberryPart.Play();
        yield return new WaitForSecondsRealtime(5);
        blueberryPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(3);
        playerPart.Stop();
        isTeleporting = false;


    }

    IEnumerator cheeseScene()
    {
        isTeleporting = true;
        giantBgMusic.Stop();
        playerAnim.SetBool("running", false);
        playerAnim.SetBool("attacking", false);
        yield return new WaitForSecondsRealtime(1);
        cheeseObject.transform.position = cheeseLocation;
        cheeseObject.transform.rotation = cheeseRotation;
        Debug.Log(cheeseObject.transform.position);
        playerObject.transform.position = playerLocation;
        playerObject.transform.rotation = playerRotation;
        blueberry.transform.position = blueberryLocation;
        blueberry.transform.rotation = blueberryRotation;
        cutscene2.Play();
        cheeseAnim.SetBool("punching", false);
        Debug.Log("Onto cutscene :D");
        playerPart.Play();
        yield return new WaitForSecondsRealtime(2);
        playerPart.Stop();
        blueberryPart.Play();
        yield return new WaitForSecondsRealtime(2);
        blueberryPart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(3);
        playerPart.Stop();
        yield return new WaitForSecondsRealtime(2);
        cheesePart.Play();
        cheeseAnim.SetBool("yelling", true);
        yield return new WaitForSecondsRealtime(52);
        cheeseAnim.SetBool("yelling", false);
        cheesePart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(13);
        playerPart.Stop();
        cheeseAnim.SetBool("yelling", true);
        cheesePart.Play();
        yield return new WaitForSecondsRealtime(32);
        cheesePart.Stop();
        cheeseAnim.SetBool("yelling", false);
        yield return new WaitForSecondsRealtime(2);
        blueberry.transform.position = blueberryLocation + blueberryLocation;
        cheeseFight = true;
        isTeleporting = false;
        cheeseBgMusic.Play();
    }

    IEnumerator finalScene()
    {
        isTeleporting = true;
        cheeseFight = false;
        cheeseObject.transform.position = cheeseLocation;
        cheeseObject.transform.rotation = cheeseRotation;
        playerObject.transform.position = playerLocation;
        playerObject.transform.rotation = playerRotation;
        blueberry.transform.position = blueberryLocation;
        blueberry.transform.rotation = blueberryRotation;
        cheeseAnim.SetBool("punching", false);
        playerAnim.SetBool("running", false);
        playerAnim.SetBool("attacking", false);
        cutscene3.Play();
        yield return new WaitForSecondsRealtime(5);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(3);
        playerPart.Stop();
        cheeseAnim.SetBool("yelling", true);
        cheesePart.Play();
        yield return new WaitForSecondsRealtime(7);
        cheeseAnim.SetBool("yelling", false);
        cheesePart.Stop();
        playerPart.Play();
        yield return new WaitForSecondsRealtime(2);
        playerPart.Stop();
        cheeseAnim.SetBool("yelling", true);
        cheesePart.Play();
        yield return new WaitForSecondsRealtime(1);
        cheesePart.Stop();
        cheeseAnim.SetBool("yelling", false);
        cheeseForward = true;
        cheeseAnim.SetBool("weak_Running", true);
        yield return new WaitForSecondsRealtime(0.1f);
        cheeseAnim.SetBool("weak_Running", false);
        yield return new WaitForSecondsRealtime(4);
        playerAnim.SetBool("attacking", true);
        yield return new WaitForSecondsRealtime(0.1f);
        playerAnim.SetBool("attacking", false);
        cheeseForward = false;
        cheeseAnim.SetBool("ded", true);
        yield return new WaitForSecondsRealtime(0.1f);
        cheeseAnim.SetBool("ded", false);
        yield return new WaitForSecondsRealtime(3);
        playerPart.Play();
        yield return new WaitForSecondsRealtime(18);
        playerPart.Stop();
        yield return new WaitForSecondsRealtime(6);
        SceneManager.LoadScene("end");
    }
}
