using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    [SerializeField] private Canvas choiceCanvas;
    public void ShowCanvas(Canvas canvasToShow) {
        canvasToShow.gameObject.SetActive(true);
    }

    public void PlayButton() {
        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);
        
        // Wy�wietlenie po chwili informacji o mo�liwo�ci p�j�cia do sklepu / wylosowania minigierki
        ShowCanvas(choiceCanvas);
    }

    public void SettingsButton() {
        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);

        // Wy�wietlenie canvasu Settings
        ShowCanvas(choiceCanvas);
    }

    public void QuitButton() {
        // WY�wietlenie potwierdzenia ch�ci wyj�cia

        // Wyj�cie z aplikacji
        Application.Quit();
    }

    public void ShopButton() {
        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);

        // W��czenie animacji i przej�cie do sceny sklepu

    }

    public void GameButton() {
        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);
        Invoke("RandomizeScene", 2f);
    }

    public void BackButton() {
        transform.parent.gameObject.SetActive(false);

        ShowCanvas(choiceCanvas);
    }

    public void RandomizeScene() {
        TransitionScript.RandomizeScene();
    }
}
