using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

  public GameObject playerPrefab;
  // Start is called before the first frame update
  void Start() {
    GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    player.name = "mainCharacter";

  }
}
