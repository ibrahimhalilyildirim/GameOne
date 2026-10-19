using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}

    [SerializeField] private GoldCounterUI _goldCounterUI;
    private int _currentGoldCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnGoldCollected()
    {
        _currentGoldCount++;
        _goldCounterUI.SetGoldCounterText(_currentGoldCount);
    }
}
