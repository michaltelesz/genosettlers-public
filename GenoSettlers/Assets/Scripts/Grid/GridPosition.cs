using Assets.Scripts.Grid;
using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public struct GridPosition : IEquatable<GridPosition>
{
    private readonly int _q;
    private readonly int _r;

    public int Q => _q;
    public int R => _r;
    public int S => -_q-_r;

    public GridPosition(int q, int r)
    {
        _q = q;
        _r = r;
    }

    public static GridPosition FromOffsetCoordinates(int x, int y)
    {
        return new GridPosition(x, y - Mathf.FloorToInt(x / 2f));
    }

    public int DistanceTo(GridPosition other)
    {
        return DistanceTo(other.Q, other.R, other.S);
    }

    public int DistanceTo(int q, int r, int s)
    {
        int distQ = Mathf.Abs(_q - q);
        int distR = Mathf.Abs(_r - r);
        int distS = Mathf.Abs(S - s);

        return Mathf.Max(new[] { distQ, distR, distS });
    }

    public override string ToString()
    {
        return $"{Q}, {R}, {S}";
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is GridPosition && Equals((GridPosition)obj);
    }

    public bool Equals(GridPosition other)
    {
        return this._q == other._q && this._r == other._r;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this._q, this._r);
    }

    public static GridPosition FromPixels(Vector3 position)
    {
        float floatQ = position.x / (HexMetrics.outerRadius * 1.5f);
        float floatR = position.z / (HexMetrics.innerRadius * 2f) - floatQ * 0.5f;
        float floatS = -floatQ - floatR;

        int intQ = Mathf.RoundToInt(floatQ);
        int intR = Mathf.RoundToInt(floatR);
        int intS = Mathf.RoundToInt(floatS);

        float dQ = Mathf.Abs(floatQ - intQ);
        float dR = Mathf.Abs(floatR - intR);
        float dS = Mathf.Abs(floatS - intS);

        if(dQ > dR)
        {
            if(dQ > dS)
            {
                return new GridPosition(-intR - intS, intR);
            }
            return new GridPosition(intQ, intR);
        }

        return new GridPosition(intQ, -intQ - intS);
    }

    internal Vector3 ToPixels()
    {
        return new Vector3()
        {
            x = _q * (HexMetrics.outerRadius * 1.5f),
            y = 0f,
            z = (_r + _q * 0.5f) * (HexMetrics.innerRadius * 2f)
        };
    }
}
