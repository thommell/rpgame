using System.Collections.Generic;
using rpgame.Core.Components;

namespace rpgame.Core;

public class GameObject {
 // Variables
 private string name;
 private bool isActive;
 private Transform transform;
 private List<Component> components = new();
 private bool hasStarted;
    
 // Properties
 public string Name => name;
 public bool IsActive => isActive;
 public Transform Transform => transform;
 public List<Component> Components => components;
 public bool HasStarted => hasStarted; 
    
 // Constructors
 public GameObject(string pName, params Component[] pComponents) {
  name = pName;
  components.AddRange(pComponents);
     
  Initialize();
 }
 public GameObject(string pName, List<Component> pComponents) {}

 private void Initialize() {
 }
 // Methods
 public void Awake() {
        
 }

 public void Start() {
        
 }
}

/*TODO: GameObject life cycle
 Awake
 Start
 Update
 Draw
 Destroy
*/

/*TODO: GameObject fields
 */

/*TODO: GameObject Methods
 AddComponent
 GetComponent
 GetAllComponents
 */
