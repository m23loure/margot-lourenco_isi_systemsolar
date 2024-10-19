using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SolarSystemController : MonoBehaviour
{
   private bool ShowPosition = true; 
   private LineRenderer lineRendererMars; 
   private LineRenderer lineRendererVenus; 
   private LineRenderer lineRendererEarth; 
   private LineRenderer lineRendererMercury; 
   private LineRenderer lineRendererJupiter; 
   private LineRenderer lineRendererSaturne; 
   private LineRenderer lineRendererUranus;
   private LineRenderer lineRendererNeptune; 
   private bool isTimeRunning=false; 
    // Start is called before the first frame update
    void Start()
    {   PlanetManager.current.Date= new DateTime(2002, 01, 20);
       // PlanetManager.current.OnTimeChange += UpdatePosition;
       PlanetManager.current.OnTimeChange += PlanetManager.current.DateIntoSlider;
       
        this.PreparePositions();
        PlanetManager.current.RotationSpeed = 1; 
        this.UpdatePosition(PlanetManager.current.Date);
    }

    // Update is called once per frame
    void Update()
    { this.ChangeTime();
     if(Input.GetKeyDown(KeyCode.UpArrow)){
        GameObject.Find("Main Camera").transform.position += new Vector3(0,0,4); 
     }
     if(Input.GetKeyDown(KeyCode.DownArrow)){
        GameObject.Find("Main Camera").transform.position += new Vector3(0,0,-4);
     }
     if(Input.GetKeyDown(KeyCode.LeftArrow)){
        GameObject.Find("Main Camera").transform.position += new Vector3(-4,0,0);

     }
     if(Input.GetKeyDown(KeyCode.RightArrow)){
        GameObject.Find("Main Camera").transform.position += new Vector3(4,0,0);
     }
      
    PlanetManager.current.OnTimeChange += UpdatePosition;
    
        
        
    }
    void ChangeTime(){
      
        if(isTimeRunning){
   
    PlanetManager.current.Date =  ((DateTime) PlanetManager.current.Date).AddDays(PlanetManager.current.RotationSpeed);}

    }
    public void StartSimulation(){
    
    isTimeRunning=true; 
   
    
    }
    public void StopSimulation(){
     
    isTimeRunning=false; 
   
    }
    public void UpdatePosition(System.DateTime t){
        GameObject.Find("Earth").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Earth,t);
        
        GameObject.Find("Jupiter").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Jupiter,t);

        GameObject.Find("Mars").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Mars,t);
        GameObject.Find("Mercury").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Mercury,t);
        GameObject.Find("Venus").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Venus,t);
        GameObject.Find("Saturn").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Saturn,t);
        GameObject.Find("Uranus").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Uranus,t);
        GameObject.Find("Neptune").transform.position= PlanetData.GetPlanetPosition(PlanetData.Planet.Neptune,t);
    }
    public void PreparePositions(){
    //Debug.Log("Preparing trajectories");

    // Earth (step: 1 day)
    DateTime ti = new DateTime(2002, 01, 20);
    DateTime tf = new DateTime(2003, 01, 20);
    TimeSpan spanEarth = tf - ti;
    lineRendererEarth = GameObject.Find("Earth").AddComponent<LineRenderer>();
    lineRendererEarth.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererEarth.widthMultiplier = 0.05f;
    lineRendererEarth.positionCount = (int)spanEarth.TotalDays; // Total days between start and end dates
    int i = 0;
    while (DateTime.Compare(ti, tf) < 0) {
        Vector3 position = PlanetData.GetPlanetPosition(PlanetData.Planet.Earth, ti);
        lineRendererEarth.SetPosition(i, position);
        i++;
        ti = ti.AddDays(1);
    }

    // Mercury (step: 1 day)
    DateTime tim = new DateTime(2002, 01, 20);
    DateTime tfm = new DateTime(2002, 04, 20);
    TimeSpan spanMercury = tfm - tim;
    lineRendererMercury = GameObject.Find("Mercury").AddComponent<LineRenderer>();
    lineRendererMercury.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererMercury.widthMultiplier = 0.05f;
    lineRendererMercury.positionCount = (int)spanMercury.TotalDays;
    int j = 0;
    while (DateTime.Compare(tim, tfm) < 0) {
        Vector3 positionm = PlanetData.GetPlanetPosition(PlanetData.Planet.Mercury, tim);
        lineRendererMercury.SetPosition(j, positionm);
        j++;
        tim = tim.AddDays(1);
    }

    // Venus (step: 1 day)
    DateTime tiv = new DateTime(2002, 01, 20);
    DateTime tfv = new DateTime(2003, 01, 20);
    TimeSpan spanVenus = tfv - tiv;
    lineRendererVenus = GameObject.Find("Venus").AddComponent<LineRenderer>();
    lineRendererVenus.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererVenus.widthMultiplier = 0.05f;
    lineRendererVenus.positionCount = (int)spanVenus.TotalDays;
    int k = 0;
    while (DateTime.Compare(tiv, tfv) < 0) {
        Vector3 positionv = PlanetData.GetPlanetPosition(PlanetData.Planet.Venus, tiv);
        lineRendererVenus.SetPosition(k, positionv);
        k++;
        tiv = tiv.AddDays(1);
    }

    // Mars (step: 1 day)
    DateTime tima = new DateTime(2002, 01, 20);
    DateTime tfma = new DateTime(2005, 01, 20);
    TimeSpan spanMars = tfma - tima;
    lineRendererMars = GameObject.Find("Mars").AddComponent<LineRenderer>();
    lineRendererMars.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererMars.widthMultiplier = 0.05f;
    lineRendererMars.positionCount = (int)spanMars.TotalDays;
    int l = 0;
    while (DateTime.Compare(tima, tfma) < 0) {
        Vector3 positionma = PlanetData.GetPlanetPosition(PlanetData.Planet.Mars, tima);
        lineRendererMars.SetPosition(l, positionma);
        l++;
        tima = tima.AddDays(1);
    }

    // Jupiter (step: 4 days)
    DateTime tiju = new DateTime(2002, 01, 20);
    DateTime tfju = new DateTime(2014, 01, 20);
    TimeSpan spanJupiter = tfju - tiju;
    int stepJupiter = 4;
    lineRendererJupiter = GameObject.Find("Jupiter").AddComponent<LineRenderer>();
    lineRendererJupiter.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererJupiter.widthMultiplier = 0.05f;
    lineRendererJupiter.positionCount = (int)((spanJupiter.TotalDays / stepJupiter)+1);
    int m = 0;
    while (DateTime.Compare(tiju, tfju) < 0) {
        Vector3 positionju = PlanetData.GetPlanetPosition(PlanetData.Planet.Jupiter, tiju);
        lineRendererJupiter.SetPosition(m, positionju);
        m++;
        tiju = tiju.AddDays(stepJupiter);
    }

    // Saturn (step: 10 days)
    DateTime tisa = new DateTime(2002, 01, 20);
    DateTime tfsa = new DateTime(2032, 01, 20);
    TimeSpan spanSaturn = tfsa - tisa;
    int stepSaturn = 10;
    lineRendererSaturne = GameObject.Find("Saturn").AddComponent<LineRenderer>();
    lineRendererSaturne.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererSaturne.widthMultiplier = 0.05f;
    lineRendererSaturne.positionCount = (int)((spanSaturn.TotalDays / stepSaturn)+1);
    int n = 0;
    while (DateTime.Compare(tisa, tfsa) < 0) {
        Vector3 positionsa = PlanetData.GetPlanetPosition(PlanetData.Planet.Saturn, tisa);
        lineRendererSaturne.SetPosition(n, positionsa);
        n++;
        tisa = tisa.AddDays(stepSaturn);
    }

    // Uranus (step: 10 days)
    DateTime tiu = new DateTime(2002, 01, 20);
    DateTime tfu = new DateTime(2086, 01, 20);
    TimeSpan spanUranus = tfu - tiu;
    int stepUranus = 10;
    lineRendererUranus = GameObject.Find("Uranus").AddComponent<LineRenderer>();
    lineRendererUranus.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererUranus.widthMultiplier = 0.05f;
    lineRendererUranus.positionCount = (int)((spanUranus.TotalDays / stepUranus)+1);
    int o = 0;
    while (DateTime.Compare(tiu, tfu) < 0) {
        Vector3 positionu = PlanetData.GetPlanetPosition(PlanetData.Planet.Uranus, tiu);
        lineRendererUranus.SetPosition(o, positionu);
        o++;
        tiu = tiu.AddDays(stepUranus);
    }

    // Neptune (step: 10 days)
    DateTime tin = new DateTime(2002, 01, 20);
    DateTime tfn = new DateTime(2167, 01, 20);
    TimeSpan spanNeptune = tfn - tin;
    int stepNeptune = 10;
    lineRendererNeptune = GameObject.Find("Neptune").AddComponent<LineRenderer>();
    lineRendererNeptune.material = new Material(Shader.Find("Sprites/Default"));
    lineRendererNeptune.widthMultiplier = 0.05f;
    lineRendererNeptune.positionCount = (int)((spanNeptune.TotalDays / stepNeptune)+1);
    int p = 0;
    while (DateTime.Compare(tin, tfn) < 0) {
        Vector3 positionn = PlanetData.GetPlanetPosition(PlanetData.Planet.Neptune, tin);
        lineRendererNeptune.SetPosition(p, positionn);
        p++;
        tin = tin.AddDays(stepNeptune);
    }

    // Disabling the renderers initially (if needed)
    lineRendererEarth.enabled = false;
    lineRendererMercury.enabled = false;
    lineRendererVenus.enabled = false;
    lineRendererMars.enabled = false;
    lineRendererJupiter.enabled = false;
    lineRendererSaturne.enabled = false;
    lineRendererUranus.enabled = false;
    lineRendererNeptune.enabled = false;
}

    public void ShowPositions(){
       
       
       
       if(ShowPosition){
        lineRendererEarth.enabled=true;
        lineRendererJupiter.enabled= true; 
        lineRendererMars.enabled= true; 
        lineRendererMercury.enabled = true; 
        lineRendererNeptune.enabled= true; 
        lineRendererSaturne.enabled = true; 
        lineRendererUranus.enabled = true; 
        lineRendererVenus.enabled = true; 
        ShowPosition= false;
       }
       else{
        lineRendererEarth.enabled=false; 
         lineRendererJupiter.enabled= false; 
        lineRendererMars.enabled= false; 
        lineRendererMercury.enabled = false; 
        lineRendererNeptune.enabled= false; 
        lineRendererSaturne.enabled = false; 
        lineRendererUranus.enabled = false; 
        lineRendererVenus.enabled = false; 
        ShowPosition= true;
       }

    
      

       
           
    
    }

}
