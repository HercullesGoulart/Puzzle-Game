using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Puzzle puzzlePrefab;

    private List<Puzzle> puzzleList = new List<Puzzle>();

    private Vector2 startPosition = new Vector2(-1.43f, 1.73f);
    private Vector2 offset = new Vector2(1.1f, 1.1f);

	// Use this for initialization
	void Start () {
        SpawnPuzzle(16);
        SetStartPosition();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SpawnPuzzle(int number)
    {
        for(int i=0; i<number; i++)
        {
            puzzleList.Add(Instantiate(puzzlePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as Puzzle);
        }
    }
    void SetStartPosition()
    {
        //line 1
        puzzleList[0].transform.position = new Vector3(startPosition.x, startPosition.y, 0.0f);
        puzzleList[1].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y, 0.0f);
        puzzleList[2].transform.position = new Vector3(startPosition.x + (2*offset.x), startPosition.y, 0.0f);
        puzzleList[3].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y, 0.0f);
        //line 2
        puzzleList[4].transform.position = new Vector3(startPosition.x, startPosition.y - offset.y, 0.0f);
        puzzleList[5].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - offset.y, 0.0f);
        puzzleList[6].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - offset.y, 0.0f);
        puzzleList[7].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - offset.y, 0.0f);
        //line 3
        puzzleList[8].transform.position = new Vector3(startPosition.x, startPosition.y - (2*offset.y), 0.0f);
        puzzleList[9].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (2 * offset.y), 0.0f);
        puzzleList[10].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        puzzleList[11].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        //line 4
        puzzleList[12].transform.position = new Vector3(startPosition.x, startPosition.y - (3 * offset.y), 0.0f);
        puzzleList[13].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (3 * offset.y), 0.0f);
        puzzleList[14].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (3 * offset.y), 0.0f);
        puzzleList[15].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (3 * offset.y), 0.0f);

    }
}
