using TMPro;
using UnityEngine;

public class Tip : MonoBehaviour
{
    [SerializeField] TMP_Text Tip1;
    [SerializeField] TMP_Text Tip2;
    [SerializeField] TMP_Text Tip3;

  
    public void Maketip3()
    {
        Tip1.gameObject.SetActive(false);
        Tip2.gameObject.SetActive(false);
        Tip3.gameObject.SetActive(true);
    }
    public void CloseTips()
    {
        Tip3.gameObject.SetActive(false);
    }
}
