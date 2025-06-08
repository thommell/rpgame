using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using rpgame.Scenes;

namespace rpgame.Core.SceneManaging;

/// <summary>
/// Handle loading, unloading and switching between scenes.
/// </summary>
public sealed class SceneManager {
    // Variables
    private static SceneManager instance;
    private List<Scene> scenes;
    private Scene currentActiveScene;
    
    // Properties
    public static SceneManager Instance => instance ??= new SceneManager();

    // Methods
    public void Initialize() {
        if (scenes == null) {
            scenes = CreateScenes();
            currentActiveScene = scenes[0];
        }
        InitializeCurrentScene();
        LoadCurrentScene();
    }
    public void Update(GameTime gameTime) {
        if (!currentActiveScene.IsLoaded) {
            throw new Exception("The scene hasn't been loaded yet.");
        }
        currentActiveScene.Update(gameTime);
    }
    private void InitializeCurrentScene() {
        currentActiveScene.InitializeScene();
    }
    private void LoadCurrentScene() {
        currentActiveScene.Load();
        currentActiveScene.LateLoad();
        currentActiveScene.SetSceneActive();
    }
    private Scene GetScene<T>() where T : Scene {
        return new Scene();
    }
    private Scene GetScene(string pSceneName) {
        return new Scene();   
    }
    private List<Scene>CreateScenes() {
        List<Scene> scenes = new() {
            new TestScene("test")
        };
        return scenes;
    }

}

/* TODO: SceneManager Lifetime cycle
 Load/Initialize current scene
 Unload current scene
 Update current scene
 Draw current scene
 POSSIBILITIES:
 - NextScene?
*/

/* TODO: SceneManager behaviour
 Optional support for additive scenes
 */
