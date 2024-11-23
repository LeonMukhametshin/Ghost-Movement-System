using UnityEngine;

public class RecordingPlayer : MonoBehaviour
{
    [SerializeField] private string recordingId;

    private bool isPlaying = false;
    private Recording recording;
    private int playingIndex = 0;

    private void Start()
    {
        recording = RecordingStore.LoadRecording(recordingId);
        if (recording == null) this.gameObject.SetActive(false);
    }

    public void StartReplay()
    {
        isPlaying = true;
        playingIndex = 0;
    }

    public void PauseReplay() => isPlaying = false;

    public void ResumeReplay() => isPlaying = true;

    private void FixedUpdate()
    {
        if (isPlaying && playingIndex + 1 < recording.transformStates.Count)
        {
            TransformState ts = recording.transformStates[playingIndex];
            transform.SetPositionAndRotation(
                new Vector3 (ts.position.x, ts.position.y, ts.position.z), 
                new Quaternion(ts.rotation.x, ts.rotation.y, ts.rotation.z, ts.rotation.w)
            );
            transform.localScale = new Vector3(ts.scale.x, ts.scale.y, ts.scale.z);
            playingIndex++;
        }
    }
}
