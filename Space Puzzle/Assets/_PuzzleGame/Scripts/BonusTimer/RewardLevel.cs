using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardLevel : MonoBehaviour
{
    public DailyReward reward;

    private void OnTriggerEnter(Collider other)
    {
        BonusEnabled();
    }

    void BonusEnabled()
    {
        reward.enableButton();
        Debug.Log("bonus enabled");
    }
}
