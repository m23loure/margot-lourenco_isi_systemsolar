using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
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
        Position = GameObject.Find("Earth").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Earth").transform); 


    }
    private string SendText(){

    return"Earth\n" +
                                "• Type: Terrestrial planet\n" +
                                "• Diameter: ~12,742 km\n" +
                                "• Distance from Sun: ~149.6 million km (1 AU)\n" +
                                "• Surface Temperature: ~15 °C (59 °F)\n" +
                                "• Moons: 1 (Moon)\n" +
                                "• Orbit Period: 365.25 days\n";
    }
}
