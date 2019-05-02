using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockedUI : MonoBehaviour
{
    public GameObject bonusUi;

    private void Start()
    {
        FindBonus();
    }
    void FindBonus()
    {
        if (PlayerPrefs.HasKey("UIBonus"))
        {
            // Not the first start because pref exists
            // Don't show help
            bonusUi.SetActive(false);
        }
        else
        {

            bonusUi.SetActive(true);


        }
    }
    public void UIBonus()
    {
        if (PlayerPrefs.HasKey("UIBonus"))
        {
            // Not the first start because pref exists
            // Don't show help
            Debug.Log("ja tem uibonus");

        }
        else
        {
            // First start because pref does not exist
            // Create pref
            PlayerPrefs.SetInt("UIBonus", 0);
            PlayerPrefs.Save();

            // Show help
        }
    }
    public void BonusScene()
    {
        SceneManager.LoadScene("Bonus");
    }


}
