using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NeptuneScript : MonoBehaviour
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
        Position = GameObject.Find("Neptune").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Neptune").transform); 


    } 
    private string SendText(){
        return "Neptune\n" +
                                "• Type: Ice giant\n" +
                                "• Diameter: ~49,244 km\n" +
                                "• Distance from Sun: ~4.5 billion km\n" +
                                "• Surface Temperature: ~-214 °C (-353 °F)\n" +
                                "• Moons: 14 (notable: Triton)\n" +
                                "• Orbit Period: 165 years\n";
    }

    }


