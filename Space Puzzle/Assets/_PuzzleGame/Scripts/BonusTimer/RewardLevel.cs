using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardLevel : MonoBehaviour
{
    DailyReward reward;
    public PlayerBehavior player;

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
        GameManager.instance.toBonus = true;
        reward.rewardClicked();
        GameManager.instance.BonusLevel();
        Debug.Log("bonus enabled");
        reward.StartCoroutine("CheckTime");
        



    }
}
