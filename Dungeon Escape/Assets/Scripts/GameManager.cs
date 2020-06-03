using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance {
        get {
            if(_Instance == null) {
                Debug.LogError("GameManager is null!");
            }
            return _Instance;
        }
    }
    
    public bool HasKeyToCastle { get; set; }

    private void Awake() {
        _Instance = this;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public Player player { get; private set; }


}
