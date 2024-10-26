using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthCount;
    [SerializeField] private TMP_Text _bugCount;
    private int _countOfBugs = 0;
    private int _countOfHealth;

    public void ChangeBug(int value)
    {
        _countOfBugs += value;
        _bugCount.text = _countOfBugs.ToString(); 

    }
    public void ChangeHealth(int value)
    {
        _healthCount.text = value.ToString();

    }

}
