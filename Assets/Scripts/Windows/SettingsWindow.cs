using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Button ReturnButton;
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ExitButton;

    private void OnEnable()
    {

        ReturnButton.onClick.AddListener(BindOnReturnButtonClick);
        StartButton.onClick.AddListener(BindOnStartButtonClick);
        ExitButton.onClick.AddListener(BindOnExitButtonClick);
    }

    private void OnDisable()
    {
        ReturnButton.onClick.RemoveListener(BindOnReturnButtonClick);
        StartButton.onClick.RemoveListener(BindOnStartButtonClick);
        ExitButton.onClick.RemoveListener(BindOnExitButtonClick);
    }
   
    private void BindOnReturnButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    private void BindOnStartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    private void BindOnExitButtonClick()
    {
        Application.Quit();
    }
}
