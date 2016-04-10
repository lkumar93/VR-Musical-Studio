using UnityEngine;
using System.Collections;
using System.IO.Ports;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class FloorTom : MonoBehaviour
{

    public GameObject myo = null;
  AudioSource a;
    private int player = 0;

    private Pose _lastPose = Pose.Unknown;

    ThalmicMyo thalmicMyo;

    // Use this for initialization
    public string flag = "0";

    SerialPort sp = new SerialPort("COM6", 9600);
    SerialPort sp2 = new SerialPort("COM7", 9600);
    void Start()
    {
        print("Started");
        sp.ReadTimeout = 1;
        sp.Open();
        sp2.ReadTimeout = 1;
        sp2.Open();
        a = GetComponent<AudioSource>();
        thalmicMyo = myo.GetComponent<ThalmicMyo>();

    }


    //sp.Write("1");
    void Update()
    {
        

        if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;

            if (thalmicMyo.pose == Pose.DoubleTap)
            {

                if (a.isPlaying)
                {
                    a.Stop();
                }

                else
                {
                    a.Play();
                }

              

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
            }


        }


            if (flag == "1")
            sp.Write(flag);
        else if (flag == "2")
            sp2.Write(flag);
        else
        {
            sp.Write("0");
            sp2.Write("0");
        }
    }

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }



}

