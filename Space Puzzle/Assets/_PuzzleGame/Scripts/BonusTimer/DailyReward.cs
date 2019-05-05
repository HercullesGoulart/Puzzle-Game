using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class DailyReward : MonoBehaviour
{
    //UI
    public Text timeLabel; //only use if your timer uses a label
    public Button buttonTimer; //used to disable button when needed
    public Image _progress;
    //TIME ELEMENTS
    public int hours; //to set the hours
    public int minutes; //to set the minutes
    public int seconds; //to set the seconds
    private bool _timerComplete = false;
    private bool _timerIsReady;
    private TimeSpan _startTime;
    private TimeSpan _endTime;
    private TimeSpan _remainingTime;
    //progress filler
    private float _value = 1f;
    //reward to claim
    public int RewardToEarn;

    public GameObject BonusUI;




    //startup
    void Start()
    {

        if (PlayerPrefs.GetString("_time") == "")
        {
            Debug.Log("==> Enableing button");
            enableButton();
        }
        else
        {
            disableButton();
            StartCoroutine("CheckTime");
        }

        if (PlayerPrefs.HasKey("UIBonus"))
        {
            // Not the first start because pref exists
            // Don't show help
            BonusUI.SetActive(true);
        }
        else
        {
            BonusUI.SetActive(false);
        }
        if (GameManager.instance.onFire == true)
        {
            BonusUI.SetActive(false);
        }

    }

    //update the time information with what we got some the internet
    private void updateTime()
    {
        if (PlayerPrefs.GetString("_time") == "Standby")
        {
            PlayerPrefs.SetString("_time", TimeManager.sharedInstance.getCurrentTimeNow());
            PlayerPrefs.SetInt("_date", TimeManager.sharedInstance.getCurrentDateNow());
        }
        else if (PlayerPrefs.GetString("_time") != "" && PlayerPrefs.GetString("_time") != "Standby")
        {
            int _old = PlayerPrefs.GetInt("_date");
            int _now = TimeManager.sharedInstance.getCurrentDateNow();


            //check if a day as passed
            if (_now > _old)
            {//day as passed
                Debug.Log("Day has passed");
                enableButton();
                return;
            }
            else if (_now == _old)
            {//same day
                Debug.Log("Same Day - configuring now");
                _configTimerSettings();
                return;
            }
            else
            {
                Debug.Log("error with date");
                return;
            }
        }
        Debug.Log("Day had passed - configuring now");
        _configTimerSettings();
    }

    //setting up and configureing the values
    //update the time information with what we got some the internet
    private void _configTimerSettings()
    {
        _startTime = TimeSpan.Parse(PlayerPrefs.GetString("_time"));
        _endTime = TimeSpan.Parse(hours + ":" + minutes + ":" + seconds);
        TimeSpan temp = TimeSpan.Parse(TimeManager.sharedInstance.getCurrentTimeNow());
        TimeSpan diff = temp.Subtract(_startTime);
        _remainingTime = _endTime.Subtract(diff);
        //start timmer where we left off
        setProgressWhereWeLeftOff();

        if (diff >= _endTime)
        {
            _timerComplete = true;
            enableButton();
        }
        else
        {
            _timerComplete = false;
            disableButton();
            _timerIsReady = true;
        }
    }

    //initializing the value of the timer
    private void setProgressWhereWeLeftOff()
    {
        float ah = 1f / (float)_endTime.TotalSeconds;
        float bh = 1f / (float)_remainingTime.TotalSeconds;
        _value = ah / bh;
        _progress.fillAmount = _value;
    }



    //enable button function
    private void enableButton()
    {
        buttonTimer.interactable = true;

        timeLabel.text = "CLAIM REWARD";

    }



    //disable button function
    private void disableButton()
    {
        buttonTimer.interactable = false;
        timeLabel.text = "Wait "+_remainingTime.ToString();

    }


    //use to check the current time before completely any task. use this to validate
    private IEnumerator CheckTime()
    {
        disableButton();
        timeLabel.text = "Checking the time";
        Debug.Log("==> Checking for new time");
        yield return StartCoroutine(
            TimeManager.sharedInstance.getTime()
        );
        updateTime();
        Debug.Log("==> Time check complete!");

    }


    //trggered on button click
    public void rewardClicked()
    {
        Debug.Log("==> Claim Button Clicked");
        claimReward(RewardToEarn);
        PlayerPrefs.SetString("_time", "Standby");
        StartCoroutine("CheckTime");
    }



    //update method to make the progress tick
    void Update()
    {
        if (_timerIsReady)
        {
            if (!_timerComplete && PlayerPrefs.GetString("_timer") != "")
            {
                _value -= Time.deltaTime * 1f / (float)_endTime.TotalSeconds;
                _progress.fillAmount = _value;

                //this is called once only
                if (_value <= 0 && !_timerComplete)
                {
                    //when the timer hits 0, let do a quick validation to make sure no speed hacks.
                    validateTime();
                    _timerComplete = true;
                }
            }
            
        }


    }



    //validator
    private void validateTime()
    {
        Debug.Log("==> Validating time to make sure no speed hack!");
        StartCoroutine("CheckTime");
        
    }


    private void claimReward(int x)
    {
        Debug.Log("YOU EARN " + x + " REWARDS");
    }

}