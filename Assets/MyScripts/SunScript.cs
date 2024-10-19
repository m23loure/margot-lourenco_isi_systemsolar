using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SunScript : MonoBehaviour
{
    private Vector3 Position; 
    private Vector3 Offset= new Vector3(0,2,2); 
    // Start is called before the first frame update
    void Start()
    {//Debug.Log("Line 1: Coucou je suis un script \n" +"Line : qui fonctionne ! "); 
        
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
        Position = GameObject.Find("Sun").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Sun").transform); 


    }
    private string SendText(){
        return "Sun \n"+"•	Type: Star (G-type main-sequence) \n" +"•   Diameter: ~1.39 million km \n" +"•	Distance from Earth: ~149.6 million km (1 AU) \n"+"•	Surface Temperature: ~5,500 °C (9,932 °F) \n"+"•	Core Temperature: ~15 million °C (27 million °F)\n"+"•	Mass: ~1.989 × 10^30 kg (about 99.86% of the Solar System's mass)\n"; 


    }

}
