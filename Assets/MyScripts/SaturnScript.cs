using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaturnScript : MonoBehaviour
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
        Position = GameObject.Find("Saturn").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Saturn").transform); 


    }
    private string SendText(){
        return "Saturn\n" +
                                "• Type: Gas giant\n" +
                                "• Diameter: ~116,460 km\n" +
                                "• Distance from Sun: ~1.43 billion km\n" +
                                "• Surface Temperature: ~-178 °C (-288 °F)\n" +
                                "• Moons: 83 (notable: Titan)\n" +
                                "• Orbit Period: 29.46 years\n";
    }


    }


