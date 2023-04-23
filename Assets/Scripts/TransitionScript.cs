using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using UnityEngine;
using System;


public class TransitionScript : MonoBehaviour {

    private static string cardsGameName = "EnemyFight_Dungeon1";
    private static string runningGameName = "AdditionScene";
    private static string combatGameName = "PiJ-minigraIntro";
    private static string cauldronGameName = "Niko-minigierka";
    private static string shopSceneName = "Shop";

    private static List<string> gameScenes;

    private static int randomIndex;
    private static int scenesAmount; 

    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas shopGameCanvas;

    public static bool cameFromAnotherScene = false;

    void Start() {
        if(cameFromAnotherScene) {
            menuCanvas.gameObject.SetActive(false);
            Invoke("ShowShopGameChoice", 1.2f);
        }
    }

    public static void RandomizeGameScene() {
        gameScenes = GetGameScenes(GameProgression.GetCurrentGameStage());
        scenesAmount = gameScenes.Count;
        randomIndex = UnityEngine.Random.Range(0, scenesAmount);

        float delay = 2f;
        var mainThread = SynchronizationContext.Current;
        Task.Delay(TimeSpan.FromSeconds(delay)).ContinueWith(_ =>
            mainThread.Post(__ => LoadNextScene(gameScenes[randomIndex]), null));
    }

    public static void LoadNextScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void ShowShopGameChoice() {
        shopGameCanvas.gameObject.SetActive(true);
    }

    private static List<string> GetGameScenes(int currentGameStage) {
        if (currentGameStage == 1) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if (currentGameStage == 2) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if (currentGameStage == 3) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if(currentGameStage == 4) {
            return new List<string> { "TheEndWin" };
        } else {
            return new List<string>();
        }
    }
}