using UnityEngine;

public class ObjectRecorder : MonoBehaviour
{
    [SerializeField] private string recordingId;

    private bool isRecording;

    public Recording recording { get; private set; } = new();

    public void StartRecording()
    {
        isRecording = true;
        recording = new Recording() { id = recordingId };
    }
   
    public void PauseRecording() => isRecording = false;

    public void ResumeRecording() => isRecording = true;

    public void StopRecording(bool save)
    {
        isRecording = false;

        if (save)
        {
            RecordingStore.SaveRecording(recording);
        }
    }

    private void FixedUpdate()
    {
        if (isRecording)
        {
            recording.time += Time.fixedDeltaTime;

            TransformState transformState = new()
            {
                position = new TransformState.Position(transform.position),
                rotation = new TransformState.Rotation(transform.rotation),
                scale = new TransformState.Scale(transform.localScale)
            };

            recording.transformStates.Add(transformState);
        }
    }
}
