using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehaviuur : MonoBehaviour
{
    //SO reference
    public SO_Enemy enemyScriptableObject;

    //Damage via SO ref
    public int damageCapability;

    //Updated value of enemy
    public int currentNumber;

    //Display damageNumber
    public TextMeshPro displayedNumber;

    //Has the battle been won by the player?
    public bool isEnemyDead = false;

    //Music theme
    private AudioClip musicTheme;

    //Win noise and screen
    [SerializeField] private AudioClip victorySfx;
    public GameObject winScreen;

    //Damage noise
    private AudioClip damageSfx;

    //Modifiers
    public float weaknessMod = 1.0f;
    public float vulnMod = 1.0f;

    //Status effects
    public int poisonAmount = 0;

    private void Awake()
    {
        displayedNumber = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set enemy to enemy meant to be encountered from game manager
        enemyScriptableObject = ManagerSingleton.Instance.nextEncounteredEnemy;

        //Set damage to damage (very smart)
        damageCapability = enemyScriptableObject.damage;

        //Set to starting damageNumber once encounter starts
        currentNumber = enemyScriptableObject.startingNumber;

        //Set music theme and play it immidietly
        musicTheme = enemyScriptableObject.enemyMusicTrack;
        playEnemyMusicTheme(musicTheme);

        //Set attack sound
        damageSfx = enemyScriptableObject.enemyAttackSound;

        //Set the sprite to scriptable object sprite
        gameObject.GetComponent<MeshRenderer>().material = enemyScriptableObject.enemySpriteMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        //Set display to what is the actual value
        displayedNumber.SetText(currentNumber.ToString() + "/" + enemyScriptableObject.startingNumber);

        //For testing
        if (Input.GetKeyDown(KeyCode.L))
        {
            changeValueByCard(2f, OffensiveAction.multiplyByNumber);
        }

        //Victory
        enemyDeath();


    }


    public void enemyDeath()
    {
        if (currentNumber <= 0 && !isEnemyDead)
        {
            SoundSystemSingleton.Instance.StopTheMusic();
            SoundSystemSingleton.Instance.PlaySfxSound(victorySfx);
            isEnemyDead = true;

            //Rewards show
            winScreen.SetActive(true);

            //Gain gold
            ManagerSingleton.Instance.gainGold(Random.Range(enemyScriptableObject.lowerGoldRange, enemyScriptableObject.upperGoldRange));
        }
    }

    public void changeValueByCard(float amount, OffensiveAction operand)
    {
        //Dodawanie/odejmowanie
        if (operand == OffensiveAction.dealDamage)
        {
            currentNumber = Mathf.RoundToInt(currentNumber - amount);
        }

        //Mno�enie/dzielenie
        if (operand == OffensiveAction.multiplyByNumber)
        {
            currentNumber = Mathf.RoundToInt(currentNumber * amount);
        }

        //Pot�gowanie/pierwiastkowanie
        if (operand == OffensiveAction.raiseToPowerOfNumber)
        {
            currentNumber = Mathf.RoundToInt(Mathf.Pow(currentNumber, amount));
        }

        //Tu doda si� jak�� logik� z d�wi�kami, animacj� (np. jaki� screenshake?)
        // numberDisplay.getcomponent<anim>().blablablabl
    }

    // FUNKCJE ZACHOWA�
    // Zgodnie z sugesti� na spotkaniu k�ka, przeciwnicy powinni mie� kilka zachowa�
    // Np. podzielenie si� przez n, dodanie do siebie n, pomno�enie si� przez -1
    // ale najbardziej podstawowym (i najprostszym do zaprogramowania) zachowaniem jest atak

    public void enemyActionAttack()
    {
        ManagerSingleton.Instance.playerCurrentHealth -= Mathf.RoundToInt(damageCapability * weaknessMod);
        SoundSystemSingleton.Instance.PlaySfxSound(damageSfx);
    }

    public void halfWayThere()
    {
        currentNumber = Mathf.RoundToInt(currentNumber / 2);
    }

    public void playEnemyMusicTheme(AudioClip theme)
    {
        SoundSystemSingleton.Instance.PlayMusicSound(theme);
    }

    public void takeDamage(int amount)
    {
        currentNumber -= amount; //TODO add * modifiers
    }

    public void takePoisonDamage()
    {
        currentNumber -= poisonAmount;
    }
}
