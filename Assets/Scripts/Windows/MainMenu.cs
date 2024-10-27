using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ExitButton;

    private void OnEnable()
    {
        StartButton.onClick.AddListener(BindOnStartButtonClick);
        ExitButton.onClick.AddListener(BindOnExitButtonClick);
    }

    private void OnDisable()
    {
        StartButton.onClick.RemoveListener(BindOnStartButtonClick);
        ExitButton.onClick.RemoveListener(BindOnExitButtonClick);
    }

    private void BindOnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void BindOnExitButtonClick()
    {
        Application.Quit();
    }
}
