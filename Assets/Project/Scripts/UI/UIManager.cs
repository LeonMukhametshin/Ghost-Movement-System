using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text raceText;
    [SerializeField] private Button startButton;

    public void Initialize(System.Action startRaceCallback)
    {
        startButton.onClick.AddListener(() => startRaceCallback());
    }

    public void UpdateRaceText(int currentRace)
    {
        raceText.text = $"Race: {currentRace}";
    }

    public void ShowStartButton()
    {
        startButton.gameObject.SetActive(true);
    }

    public void HideStartButton()
    {
        startButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveAllListeners();
    }
}
