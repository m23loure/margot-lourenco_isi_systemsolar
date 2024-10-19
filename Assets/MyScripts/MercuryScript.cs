using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MercuryScript : MonoBehaviour
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
        Position = GameObject.Find("Mercury").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Mercury").transform); 


    }
    private string SendText(){
        return "Mercury\n" +
                                "• Type: Terrestrial planet\n" +
                                "• Diameter: ~4,880 km\n" +
                                "• Distance from Sun: ~57.91 million km\n" +
                                "• Surface Temperature: ~430 °C (800 °F) (day), -180 °C (-290 °F) (night)\n" +
                                "• Moons: 0\n" +
                                "• Orbit Period: 88 days\n" ;
    }
}

