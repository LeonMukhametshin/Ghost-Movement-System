using System;
using System.IO;
using UnityEngine;

public static class RecordingStore
{
    private static readonly string recordingLocation = "/ghostrecordings/";
    
    public static bool SaveRecording(Recording recording)
    {
        string directoryPath = Application.persistentDataPath + recordingLocation;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Created directory: " + directoryPath);
        }

        string filepath = Path.Combine(directoryPath, recording.id + ".grs");

        Debug.Log("Attempting to save recording to: " + filepath);

        string filetext = RecordingtoString(recording);

        File.WriteAllText(filepath, filetext);
        Debug.Log("Recording successfully saved to: " + filepath);
        return true;
    }
    
    public static Recording LoadRecording(string id)
    {
        try
        {
            string text = File.ReadAllText(Path.Combine(Application.persistentDataPath + recordingLocation, id + ".grs"));
            return StringToRecording(text);
        }
        catch (Exception) { return null; }
    }

    private static string RecordingtoString(Recording recording)
    {
        string metaText = $"{recording.id}:{recording.time};";

        string stateText = "";

        foreach(TransformState ts in recording.transformStates)
        {
            stateText += $"{ts.position.x}:{ts.position.y}:{ts.position.z}/{ts.rotation.x}:{ts.rotation.y}:{ts.rotation.z}:{ts.rotation.w}/{ts.scale.x}:{ts.scale.y}:{ts.scale.z};";
        }

        return metaText + stateText;
    }

    private static Recording StringToRecording(string text)
    {
        Recording recording = new();

        string[] lines = text.Split(';');
        string[] metaText = lines[0].Split(':');
        recording.id = metaText[0];
        recording.time = float.Parse(metaText[1]);

        //rest of lines
        foreach (string line in lines[1..^1])
        {
            string[] states = line.Split('/');

            recording.transformStates.Add(new TransformState()
            {
                position = new TransformState.Position(states[0]),
                rotation = new TransformState.Rotation(states[1]),
                scale = new TransformState.Scale(states[2])
            });
        }

        return recording;
    }

    private static float GetRecordingTime(string id)
    {
        try
        {
            string json = File.ReadAllText(Path.Combine(Application.persistentDataPath + recordingLocation, id + ".grs"));
            return float.Parse(json.Split(';')[0].Split(':')[1]);
        }
        catch
        {
            return int.MaxValue;
        }
    }
}
