using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldEnabler : DefaultTrackableEventHandler
{
    public GameObject gameWorld;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        gameWorld.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        gameWorld.SetActive(false);
    }
}
