using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VenusScript : MonoBehaviour
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
        Position = GameObject.Find("Venus").transform.position; 
        GameObject.Find("Main Camera").transform.position = Position + Offset; 
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Venus").transform); 


    }
    private string SendText(){
        
     return                    "Venus\n" +
                                "• Type: Terrestrial planet\n" +
                                "• Diameter: ~12,104 km\n" +
                                "• Distance from Sun: ~108.2 million km\n" +
                                "• Surface Temperature: ~470 °C (878 °F)\n" +
                                "• Moons: 0\n" +
                                "• Orbit Period: 225 days\n"; 
    }
}
