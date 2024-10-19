using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetManager : MonoBehaviour
{
  public TextMeshProUGUI infoText; 
  [SerializeField  ]
  private UDateTime date;
  public UDateTime Date 
  { get => date;
  set{
   
    date=value;
    TimeChanged(value);
  }
 

  }
  private DateTime firstDateSlider =new DateTime(2002,01,20);
  private DateTime lastDateSlider = new DateTime(2100,01,20);
  
  public event Action<DateTime> OnTimeChange;
  public static PlanetManager current;
  public bool changeSelected= true;
  private SolarSystemController solarSystemController;
  private String dateText; 
  private int SpeedMin= 1; 
  private int SpeedMax=100; 
  public int RotationSpeed; 
  public void TimeChanged(DateTime newTime)
    {OnTimeChange?.Invoke(newTime);
    }
  void Update()
    {
       
     
}
private void Awake()
{
if (current == null)
{
current = this;
}
else
{
Destroy(obj: this);
}

}

public void ChangeSize(){
  //Debug.Log(changeSelected);
  
  //Debug.Log("début fonction ");
  if(changeSelected){
  
        Debug.Log("version réaliste ");
        GameObject.Find("Mercury").transform.localScale = new Vector3(0.00002f,0.00002f,0.00002f);
        GameObject.Find("Sun").transform.localScale = new Vector3(0.005f,0.005f,0.005f);
        GameObject.Find("Venus").transform.localScale = new Vector3(0.00004f,0.00004f,0.00004f);
        GameObject.Find("Earth").transform.localScale = new Vector3(0.000043f,0.000043f,0.000043f);
        GameObject.Find("Mars").transform.localScale = new Vector3(0.000022f,0.000022f,0.000022f);
        GameObject.Find("Jupiter").transform.localScale = new Vector3(0.000467f,0.000467f,0.000467f);
        GameObject.Find("Saturn").transform.localScale = new Vector3(0.000389f,0.000389f,0.000389f);
        GameObject.Find("Uranus").transform.localScale = new Vector3(0.000169f,0.000169f,0.000169f);
        GameObject.Find("Neptune").transform.localScale = new Vector3(0.000164f,0.000164f,0.000164f);
        changeSelected=false;}
  else{
        changeSelected=true;
        Debug.Log("version lisible ");
        GameObject.Find("Mercury").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Venus").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Earth").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Mars").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Jupiter").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Saturn").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Uranus").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Neptune").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        GameObject.Find("Sun").transform.localScale = new Vector3(0.25f,0.25f,0.25f);
        
        }

}
public void GetDate(){
  try{
float DateSliderGet = GameObject.Find ("DateSlider").GetComponent <Slider> ().value;
    

    TimeSpan timeSpan = lastDateSlider - firstDateSlider;
    DateTime selectedDate = firstDateSlider.AddDays(DateSliderGet * timeSpan.TotalDays);
    UDateTime currentdate= selectedDate;
    this.Date= currentdate; 
   

        // Display the date in the Text UI element
         dateText = selectedDate.ToString("yyyy-MM-dd"); // Display in the format YYYY-MM-DD
         DisplayDate.currentd.Update();
         }
      catch(Exception e){

      }
         
}

public void DateIntoSlider(System.DateTime t){
        TimeSpan timeSpan = lastDateSlider - firstDateSlider;
        TimeSpan elapsedDuration = t - firstDateSlider;

        // Calculate a value between 0 and 1 for Slider
        float fraction = (float)elapsedDuration.TotalDays / (float)timeSpan.TotalDays;
        float result=  Mathf.Clamp01(fraction);
        GameObject.Find ("DateSlider").GetComponent <Slider> ().value=result;  

}
public String DateForText(){
  return dateText; 
}

public void SliderIntoSpeed(){
  float SpeedSliderGet = GameObject.Find ("SliderSpeed").GetComponent <Slider> ().value;
  int speedrange = SpeedMax-SpeedMin; 
  float selectedspeed = SpeedMin + (SpeedSliderGet*speedrange );
  RotationSpeed = Mathf.RoundToInt(selectedspeed);
  //Debug.Log(RotationSpeed); 

}
public void ZoomManager(){
  if(GameObject.Find("Main Camera").transform.position.z <-4){
  GameObject.Find("Main Camera").transform.position +=new Vector3(0,0,4);
   
  }
}
public void DezoomManager(){

  GameObject.Find("Main Camera").transform.position +=new Vector3(0,0,-4);
   
  
}


public void CameraRotation(){
  String myText = GameObject.Find("RotationInputField").GetComponent<TMP_InputField>().text; 
  float inputValue; 
  if (float.TryParse(myText, out inputValue)){
    GameObject.Find("Main Camera").transform.eulerAngles = new (0,inputValue,0); 

  }
  else{
    Debug.Log("set a valid number ! "); 
  }
}

public void ResetCamera(){
  GameObject.Find("Main Camera").transform.position = new Vector3(0,1,-40);
  GameObject.Find("Main Camera").transform.eulerAngles= new Vector3(0,0,0);
}

public void InformationText(string infos){
  infoText.text= infos; 
}







}
