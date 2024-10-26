using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    public GameObject interfacePanel;

    void Update()
    {
        // ��������� ������� ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ����������� ��������� ����������
            interfacePanel.SetActive(!interfacePanel.activeSelf);
        }
    }
}
