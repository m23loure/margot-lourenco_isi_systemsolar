using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UranusScript : MonoBehaviour
{   private Vector3 Position; 
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
        Position = GameObject.Find("Uranus").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Uranus").transform); 


    }
    private string SendText(){
        return "Uranus\n" +
                                "• Type: Ice giant\n" +
                                "• Diameter: ~50,724 km\n" +
                                "• Distance from Sun: ~2.87 billion km\n" +
                                "• Surface Temperature: ~-224 °C (-371 °F)\n" +
                                "• Moons: 27 (notable: Titania)\n" +
                                "• Orbit Period: 84 years\n";
    }
}

