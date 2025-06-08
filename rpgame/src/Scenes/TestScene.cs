using System;
using System.Collections.Generic;
using rpgame.Core;
using rpgame.Core.SceneManaging;

namespace rpgame.Scenes;

public class TestScene : Scene {
    public TestScene(string pName) : base(pName) {
    }
    protected override List<GameObject> CreateGameObjects() {
        List<GameObject> gameObjects = new List<GameObject>();
        GameObject temp = new GameObject("temp");
        gameObjects.Add(temp);
        return gameObjects;
    }

    public override void Load() {
        Console.WriteLine($"GameObjects after load: {GameObjects.Count}");
        RemoveObject("temp");
    }

    public override void LateLoad() {
        Console.WriteLine($"GameObjects after LateLoad: {GameObjects.Count}");
    }
}