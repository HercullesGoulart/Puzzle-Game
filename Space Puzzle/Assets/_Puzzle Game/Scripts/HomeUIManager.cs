﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour {

	// Start Level 1
	public void StartGame () {

        SceneManager.LoadScene("Level1");
	}
}
