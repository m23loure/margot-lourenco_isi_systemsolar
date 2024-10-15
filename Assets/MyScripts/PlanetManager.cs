using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
  [SerializeField  ]
  private UDateTime date;
  public UDateTime Date
  { get => date;
  set{
    date=value;
    TimeChanged(value);
  }

  }
  public event Action<DateTime> OnTimeChange;
  public static PlanetManager current;
  private SolarSystemController solarSystemController;
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

}
