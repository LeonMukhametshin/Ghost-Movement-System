using UnityEngine;

public class RecorderManager : MonoBehaviour
{
    [SerializeField] private ObjectRecorder objectRecorder;
    [SerializeField] private RecordingPlayer playerRecorder;

    public void StartRecording()
    {
        objectRecorder?.StartRecording();
        playerRecorder?.StartReplay();
    }

    public void StopRecording()
    {
        objectRecorder?.StopRecording(true);
    }
}
