using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {         PlanetManager.current.Date= new DateTime(2002, 01, 20);
        PlanetManager.current.OnTimeChange += UpdatePosition;
        
    }

    // Update is called once per frame
    void Update()
    { PlanetManager.current.Date =  ((DateTime) PlanetManager.current.Date).AddDays(1);
        Debug.Log("Update");
      
        
        
    }
    public void UpdatePosition(System.DateTime t){
        //GameObject.Find("Earth").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Earth,t);
        
        GameObject.Find("Jupiter").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Jupiter,t);

         GameObject.Find("Mars").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Mars,t);
         GameObject.Find("Mercury").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Mercury,t);
        GameObject.Find("Venus").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Venus,t);
        GameObject.Find("Saturn").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Saturn,t);
        GameObject.Find("Uranus").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Uranus,t);
        GameObject.Find("Neptune").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Neptune,t);
    }
}
