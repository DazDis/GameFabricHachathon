using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    public GameObject interfacePanel;

    void Update()
    {
        // Проверяем нажатие клавиши Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Инвертируем видимость интерфейса
            interfacePanel.SetActive(!interfacePanel.activeSelf);
        }
    }
}
