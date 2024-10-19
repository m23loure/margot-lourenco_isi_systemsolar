using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JupiterScript : MonoBehaviour
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
        Position = GameObject.Find("Jupiter").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Jupiter").transform); 


    }
    private string SendText(){
        return "Jupiter\n" +
                                "• Type: Gas giant\n" +
                                "• Diameter: ~139,820 km\n" +
                                "• Distance from Sun: ~778.5 million km\n" +
                                "• Surface Temperature: ~-145 °C (-234 °F)\n" +
                                "• Moons: 79 (notable: Ganymede)\n" +
                                "• Orbit Period: 11.86 years\n";
    }
}
