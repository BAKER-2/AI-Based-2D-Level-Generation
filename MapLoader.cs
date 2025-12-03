using UnityEngine;
using System;
using System.Collections.Generic;
using MiniJSON;    // ← your JSON parser

public class MapLoader : MonoBehaviour
{
    [Header("Assign your map.json here")]
    public TextAsset mapFile;        // drag your map.json into this slot
    [Header("The prefab to use for each wall tile")]
    public GameObject wallPrefab;    // drag in a 1×1 sprite prefab
    [Header("Spacing between tiles (usually 1)")]
    public float cellSize = 1f;

    void Start()
    {
        // 1) Check assignments
        if (mapFile == null)
        {
            Debug.LogError("❌ Map file not assigned!");
            return;
        }
        if (wallPrefab == null)
        {
            Debug.LogError("❌ Wall prefab not assigned!");
            return;
        }

        // 2) Parse JSON
        var dict = Json.Deserialize(mapFile.text) as Dictionary<string, object>;
        if (dict == null || !dict.ContainsKey("data"))
        {
            Debug.LogError("❌ JSON has no 'data' object");
            return;
        }
        var data = dict["data"] as Dictionary<string, object>;
        if (data == null || !data.ContainsKey("walls"))
        {
            Debug.LogError("❌ JSON 'data' has no 'walls' array");
            return;
        }

        // 3) Read walls list into a lookup set, and track bounds
        var wallsList = data["walls"] as List<object>;
        var emptyCoords = new HashSet<string>(); // these should remain empty
        int maxX = 0, maxY = 0;

        foreach (var entry in wallsList)
        {
            var pair = entry as List<object>;
            if (pair == null || pair.Count < 2) continue;

            int x = Convert.ToInt32(pair[0]);
            int y = Convert.ToInt32(pair[1]);
            emptyCoords.Add($"{x},{y}");
            if (x > maxX) maxX = x;
            if (y > maxY) maxY = y;
        }

        // 4) Invert: instantiate a wall at every position NOT in emptyCoords
        for (int x = 0; x <= maxX; x++)
        {
            for (int y = 0; y <= maxY; y++)
            {
                if (emptyCoords.Contains($"{x},{y}"))
                    continue;  // skip—this is "room" (negative space)
                
                var pos = new Vector3(x * cellSize, y * cellSize, 0f);
                Instantiate(wallPrefab, pos, Quaternion.identity, this.transform);
            }
        }
    }
}
