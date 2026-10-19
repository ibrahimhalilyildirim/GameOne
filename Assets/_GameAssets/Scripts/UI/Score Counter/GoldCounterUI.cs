using TMPro;
using UnityEngine;

public class GoldCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldCounterText;

    public void SetGoldCounterText(int counter)
    {
        _goldCounterText.text = counter.ToString();
    }
}
