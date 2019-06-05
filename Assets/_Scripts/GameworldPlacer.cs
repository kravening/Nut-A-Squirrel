using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class GameworldPlacer : MonoBehaviour
{
    private Vector3 maxScale;

    // Start is called before the first frame update
    void Start()
    {
        //maxScale = transform.localScale;
        //transform.localScale = Vector3.zero;

        GameTimeManager.instance.GameStartedEvent += PlaceWorld;
    }

    private void OnDestroy()
    {
        GameTimeManager.instance.GameStartedEvent -= PlaceWorld;
    }

    public void PlaceWorld()
    {
        //transform.localScale = maxScale;
    }
}
