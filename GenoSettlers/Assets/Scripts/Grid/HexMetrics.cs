﻿using UnityEngine;

namespace Assets.Scripts.Grid
{
    public static class HexMetrics
    {
        public const float outerRadius = 6f;

        public const float innerRadius = outerRadius * 0.866025404f;

        public static Vector3[] corners = {
            new Vector3(-0.5f * outerRadius, 0f, innerRadius),
            new Vector3(0.5f * outerRadius, 0f, innerRadius),
            new Vector3(outerRadius, 0f, 0f),
            new Vector3(0.5f * outerRadius, 0f, -innerRadius),
            new Vector3(-0.5f * outerRadius, 0f, -innerRadius),
            new Vector3(-outerRadius, 0f, 0f),
        };
    }
}
