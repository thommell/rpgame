using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rpgame.Core.SceneManaging;

public class Scene {
 // Variables
 private bool isLoaded;
 private string name;
 private List<GameObject> gameObjects = new();
 
 // Different lists to remove/add objects after an update tick
 private List<GameObject> gameObjectsToAdd = new();
 private List<GameObject> gameObjectsToRemove = new();
 
 // Properties
 public bool IsLoaded => isLoaded;
 public List<GameObject> GameObjects => gameObjects;
 public string Name => name;
 
 // Constructors
 public Scene() {
  name = null;
 }
 protected Scene(string pName) {
  name = pName;
 }
 
 // Methods
 public void InitializeScene() {
  if (isLoaded) return;
  gameObjects = CreateGameObjects();
 }

 public virtual void Update(GameTime gameTime) {
  RemoveObjects();
 }
 public virtual void Load() {
 }

 public virtual void LateLoad() {
 }

 private void AddNewObjects() {
  gameObjects.AddRange(gameObjectsToAdd);
  gameObjectsToAdd.Clear();
 }

 private void RemoveObjects() {
  List<GameObject> sharedObjects = GetSharedNames(gameObjects, gameObjectsToRemove);
  foreach (GameObject sharedObject in sharedObjects) {
   gameObjects.Remove(sharedObject);
  }
  // Clear old remove list
  gameObjectsToRemove.Clear();
 }

 protected void RemoveObject(GameObject pGameObject) {
  if (pGameObject == null) return;
  gameObjectsToRemove.Add(pGameObject);
 }

 protected void RemoveObject(string pName) {
  if (pName == null) return;
  gameObjectsToRemove.Add(new GameObject(pName));
 }
 private List<GameObject> GetSharedNames(List<GameObject> listA, List<GameObject> listB) {
  var objs = new List<GameObject>();
  var names = GetNames(listA);
  foreach (var item in listB) {
   if (names.Contains(item.Name)) {
    objs.Add(item);
   }
  }
  return objs;
 }

 private List<string> GetNames(List<GameObject> pGameObjects) {
  List<string> names = new();
  foreach (var item in pGameObjects) {
   names.Add(item.Name);
  }
  return names;
 }
 

 protected virtual List<GameObject> CreateGameObjects() {
  throw new NotImplementedException("There are no objects in the current scene.");
 }

 public void SetSceneActive() {
  isLoaded = true;
 }
}

/* TODO: Scene Lifetime
 Load
 Unload
 Update
 Draw
*/

/* TODO: Scene fields
 gameObjects
 isLoaded
 toAdd
 toRemove
 */

/* TODO: Scene methods:
 AddGameObject
 RemoveGameObject
 GetAllGameObjects
 */

