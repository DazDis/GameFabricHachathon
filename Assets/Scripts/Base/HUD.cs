using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] public Slider HealthSlider;
    [SerializeField] private TMP_Text _bugCount;
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
    }
}
