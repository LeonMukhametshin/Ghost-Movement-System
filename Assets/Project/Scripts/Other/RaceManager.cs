using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private RecorderManager recorderManager;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private int currentRace = 1; 
    private bool raceStarted = false; 

    private void Start()
    {
        Time.timeScale = 0f; 
        uiManager.UpdateRaceText(currentRace);
        uiManager.Initialize(() => StartRace());
    }

    public void StartRace()
    {
        if (raceStarted) return;

        raceStarted = true;
        Time.timeScale = 1f; 
        recorderManager.StartRecording();
        uiManager.HideStartButton();
    }

    public void FinishRace()
    {
        raceStarted = false;
        recorderManager.StopRecording();
        levelManager.LoadNextLevel();
    }
}
