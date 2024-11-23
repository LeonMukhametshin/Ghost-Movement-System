using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        raceManager.FinishRace();
    }
}