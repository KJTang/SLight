using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : IGameManager {
    Dictionary<string, GameObject> prefabs;

    public void Init() {
        prefabs = new Dictionary<string, GameObject>();
    }

    public void Update() {}

    public void Destroy() {
        ClearAll();
    }

    public void ClearAll() {
        prefabs.Clear();
        Resources.UnloadUnusedAssets();
    }

    public GameObject LoadPrefab(string prefabName, string prefabPath) {
        GameObject prefab;
        if (!prefabs.TryGetValue(prefabName, out prefab)) {
            prefab = Resources.Load(prefabPath) as GameObject;
            if (prefab != null) {
                prefabs.Add(prefabName, prefab);
            }
        }
        return prefab;
    }

    public void UnloadPrefab(string prefabName) {
        GameObject prefab;
        if (prefabs.TryGetValue(prefabName, out prefab)) {
            Resources.UnloadAsset(prefab);
        }
    }

    public GameObject GetPrefab(string prefabName) {
        GameObject prefab;
        prefabs.TryGetValue(prefabName, out prefab);
        return prefab;
    }
}