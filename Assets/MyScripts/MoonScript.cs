using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoonScript : MonoBehaviour
{
    private Vector3 Position; 
    private Vector3 Offset= new Vector3(0,2,2); 
    // Start is called before the first frame update
    void Start()
    {//Debug.Log("Coucou je suis un script qui fonctionne ! "); 
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    void OnMouseDown(){
       
        Debug.Log("hey I'm clicked ! "); 
        this.CenterCamera(); 
           string infos = this.SendText(); 
        PlanetManager.current.InformationText(infos); 
    }
    void CenterCamera(){
        Position = GameObject.Find("Moon").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Moon").transform); 


    }
    private string SendText(){
        return "Moon (Earth's Moon)\n" +
                                "• Type: Natural satellite\n" +
                                "• Diameter: ~3,474 km\n" +
                                "• Distance from Earth: ~384,400 km\n" +
                                "• Surface Temperature: ~-173 °C (-280 °F) (night), 127 °C (260 °F) (day)\n" +
                                "• Orbit Period: 27.3 days";
    }
}
