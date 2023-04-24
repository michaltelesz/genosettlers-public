﻿using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct GridPosition : IEquatable<GridPosition>
{
    private int _q;
    private int _r;

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
        return new GridPosition(x, y - x / 2);
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
}