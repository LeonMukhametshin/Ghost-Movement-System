using System;
using UnityEngine;

[Serializable]
public record TransformState
{
    private static readonly int roundTo = 3;

    [HideInInspector] public Position position;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public Scale scale;


    [Serializable]
    public record Position 
    {
        public float x;
        public float y;
        public float z;

        public Position(Vector3 pos)
        {
            x = MathF.Round(pos.x, roundTo);
            y = MathF.Round(pos.y, roundTo);
            z = MathF.Round(pos.z, roundTo);
        }
        
        public Position(string pos)
        {
            string[] vals = pos.Split(':');
            x = float.Parse(vals[0]);
            y = float.Parse(vals[1]);
            z = float.Parse(vals[2]);
        }
    }

    [Serializable]
    public record Rotation
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Rotation(Quaternion rot)
        {
            x = MathF.Round(rot.x, roundTo);
            y = MathF.Round(rot.y, roundTo);
            z = MathF.Round(rot.z, roundTo);
            w = MathF.Round(rot.w, roundTo);
        }

        public Rotation(string rot)
        {
            string[] vals = rot.Split(':');
            x = float.Parse(vals[0]);
            y = float.Parse(vals[1]);
            z = float.Parse(vals[2]);
            w = float.Parse(vals[3]);
        }
    }

    [Serializable]
    public record Scale
    {
        public float x;
        public float y;
        public float z;

        public Scale(Vector3 sca)
        {
            x = MathF.Round(sca.x, roundTo);
            y = MathF.Round(sca.y, roundTo);
            z = MathF.Round(sca.z, roundTo);
        }

        public Scale(string sca)
        {
            string[] vals = sca.Split(':');
            x = float.Parse(vals[0]);
            y = float.Parse(vals[1]);
            z = float.Parse(vals[2]);
        }
    }
}
