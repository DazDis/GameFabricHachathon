using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] public Slider HealthSlider;
    [SerializeField] public DeadWindow _deadWindow;
    [SerializeField] private TMP_Text _bugCount;
    public GameObject interfacePanel;

    //private int _countOfBugs = 0;
    private int _countOfHealth;

    public void ChangeBug(int value)
    {
       
        _bugCount.text = value.ToString(); 

    }
    public void ChangeHealth(int value)
    {
        HealthSlider.value = value;

    }
    private void Update()
    {
        HealthSlider.value -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Инвертируем видимость интерфейса
            interfacePanel.SetActive(!interfacePanel.activeSelf);
            if (interfacePanel.activeSelf) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}
