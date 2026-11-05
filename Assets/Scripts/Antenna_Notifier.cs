using UnityEngine;

public class Antenna_Notifier : MonoBehaviour
{
    public delegate void LookAntennaHandler();
    public event LookAntennaHandler OnFollowPlayer;

    public delegate void StopLookingAntennaHandler();
    public event StopLookingAntennaHandler OnStopFollowingPlayer;

    public void OnPointerEnter()
    {
        OnFollowPlayer();
    }

    public void OnPointerExit()
    {
        OnStopFollowingPlayer();
    }
}
