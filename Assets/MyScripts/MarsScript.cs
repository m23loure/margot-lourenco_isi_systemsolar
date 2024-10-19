using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarsScript : MonoBehaviour
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
        Position = GameObject.Find("Mars").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Mars").transform); 


    }
    private string SendText(){ 
        return "Mars\n" +
                                "• Type: Terrestrial planet\n" +
                                "• Diameter: ~6,779 km\n" +
                                "• Distance from Sun: ~227.9 million km\n" +
                                "• Surface Temperature: ~-63 °C (-81 °F)\n" +
                                "• Moons: 2 (Phobos and Deimos)\n" +
                                "• Orbit Period: 687 days\n";

    }
}
