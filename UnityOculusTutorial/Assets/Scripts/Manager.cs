using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public float spawnScale;
    public GameObject boardPrefab;
    public GameObject ballPrefab;

    private GameObject board = null;
    private GameObject ball = null;

    public void SpawnGame(GameObject hand, Vector3 position) {

        // Delete board and ball if they exist.
        if (board != null)
            Destroy(board);
        if (ball != null)
            Destroy(ball);

        // Spawn the board
        board = Instantiate(boardPrefab, position, Quaternion.identity);
        board.transform.localScale = Vector3.one * spawnScale;

        // Spawn the ball
        ball = Instantiate(ballPrefab, board.transform.Find("SpawnPoint").transform.position, Quaternion.identity);
        ball.transform.localScale = Vector3.one * spawnScale;

        // Parent the board under the hand.
        board.transform.parent = hand.transform;
    }
}
