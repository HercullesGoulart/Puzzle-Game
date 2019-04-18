using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardLevel : MonoBehaviour
{
    DailyReward reward;

    private void Start()
    {
        reward = GetComponent<DailyReward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            BonusEnabled();
        }
        
    }

    void BonusEnabled()
    {
        reward.rewardClicked();
        Debug.Log("bonus enabled");
        reward.StartCoroutine("CheckTime");
    }
}
