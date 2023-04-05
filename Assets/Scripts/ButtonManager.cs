using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour {
    [SerializeField] private Canvas choiceCanvas;
    [SerializeField] private AudioClip buttonClickSfx;

    public void ShowCanvas(Canvas canvasToShow) {
        canvasToShow.gameObject.SetActive(true);
    }

    public void PlayButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);
        
        // Wy�wietlenie po chwili informacji o mo�liwo�ci p�j�cia do sklepu / wylosowania minigierki
        ShowCanvas(choiceCanvas);
    }

    public void OptionsButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);

        // Wy�wietlenie canvasu Settings
        ShowCanvas(choiceCanvas);
    }

    public void QuitButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // WY�wietlenie potwierdzenia ch�ci wyj�cia

        // Wyj�cie z aplikacji
        Application.Quit();
    }

    public void ShopButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);

        // W��czenie animacji i przej�cie do sceny sklepu
        Invoke("SwitchToShop", 2f);
    }

    public void GameButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);
        Invoke("RandomizeScene", 2f);
    }

    public void BackButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        transform.parent.gameObject.SetActive(false);

        ShowCanvas(choiceCanvas);
    }

    private void RandomizeScene() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        TransitionScript.RandomizeScene();
    }

    private void SwitchToShop() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        SceneManager.LoadSceneAsync("Shop");
    }

    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;
    public void MusicOnButton() {
        Debug.Log("MusicOnButton");
        SoundSystemSingleton.Instance.StopTheMusic();

        // Wy��cza siebie
        buttonToHide.SetActive(false);

        // W��cza ButtonOff
        buttonToShow.SetActive(true);
    }

    public void MusicOffButton() {
        Debug.Log("MusicOffButton");
        SoundSystemSingleton.Instance.PlayTheMusicAgain();

        // Wy��cza siebie
        buttonToHide.SetActive(false);

        // W��cza ButtonOn
        buttonToShow.SetActive(true);
    }

    public void BackToTunnelButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wy��czeniu canvasu 'sartowego'
        TransitionScript.cameFromAnotherScene = true;

        // Powr�t do tunelu
        SceneManager.LoadSceneAsync("TransitionScene");
    }

    public void PolishButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wy��cza siebie
        buttonToHide.SetActive(false);

        // W��cza ButtonOn
        buttonToShow.SetActive(true);
        
        // "Zmienia j�zyk"
        Settings.SwitchLanguage("english");

    }

    public void EnglishButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wy��cza siebie
        buttonToHide.SetActive(false);

        // W��cza ButtonOn
        buttonToShow.SetActive(true);

        // "Zmienia j�zyk"
        Settings.SwitchLanguage("polish");
    }

    public void ResumeGameButton() {
        Settings.ResumeGame();
    }

    public void BackToMenuButton() {
        // Wy��czeniu canvasu 'sartowego'
        TransitionScript.cameFromAnotherScene = false;

        // Powr�t do tunelu
        SceneManager.LoadSceneAsync("TransitionScene");
    }

    // DROPDOWNY
    public void ScreenSizeDropdownChange(int index)
    {
        switch (index)
        {
            case 0: Settings.ChangeScreenSize(1920, 1080); break;
            case 1: Settings.ChangeScreenSize(1366, 768); break;
            case 2: Settings.ChangeScreenSize(800, 600); break;
        }
    }


}
