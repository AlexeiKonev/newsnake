using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
     //check is is firs element or not 
    private bool _isLast = false;
    public bool IsLast
    {
        get { return _isLast; }
        set { _isLast = value; }
    }

    private bool _deathTimerOn=true;
    public bool DeathTimerOn 
   {
        get { return _deathTimerOn; }
        set { _deathTimerOn = value; }
    }

    private    float _timeLife = 15f;
    public   float TimeLife
    {
        get { return _timeLife; } 
    }

    private  BodyGenerator _bodyGen;




    private void Awake()
    {
        _bodyGen = FindObjectOfType<BodyGenerator>();
    }

    private void FixedUpdate()
    {
      DeathTimer();
    }
    
    
  public void TimerOff()
    {
        if ( DeathTimerOn)
        {
           DeathTimerOn = false;
           _timeLife =  15f;
        }
    }
  private void DeathTimer()
    {
        if (DeathTimerOn && _isLast && _timeLife > 1)
        {
           
            _timeLife -= 0.1f;
        }
        if (_timeLife < 1)
        {
            _bodyGen.DeleteObj();
        }

    }
   public void SetLasted()
    {
        _isLast = true;
    }
    public void SetFirsted()
    {
        _isLast = false;
    }

}
