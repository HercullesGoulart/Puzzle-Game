using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardLevel : MonoBehaviour
{
    DailyReward reward;

    private void Start()
    {
        reward = FindObjectOfType<DailyReward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colliderwithplayerbonusreward");
            //BonusEnabled();
        }
        
    }

    void BonusEnabled()
    {
        //player
        //reward.LevelReward();
        //reward.rewardClicked();
        //GameManager.instance.BonusLevel();
        Debug.Log("bonus enabled");
        //reward.StartCoroutine("CheckTime");
        



    }
}
