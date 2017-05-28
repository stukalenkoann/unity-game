using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Subtitles : MonoBehaviour {
    AudioSource audio;
    public static Subtitles instance;
    long index = 0;
    bool isDialogStarted = false;
    TimeStampCall[] timeStamps;

    void Start()
    {
        if (instance == null)
            instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void StartDialog(string chapter, TimeStampCall[] ts) {
        Debug.Log("StartDialog(string chapter, TimeStampCall[] ts)");
        InOutText.iotext.StartDialog(chapter);
        timeStamps = ts;
        isDialogStarted = true;
        index = 0;
    }

    void FixedUpdate()
    {
        if (timeStamps.Length != 0 && isDialogStarted && !audio.isPlaying && index < timeStamps.Length){
            TimeStampCall t = timeStamps[index];
            //audio.clip = t.audioClip;
            //audio.Play();
            for (int j = 0; j < InOutText.iotext.charactes.Count; j++)
            {
                if (InOutText.iotext.charactes[j].Name.Equals(t.CharacterName))
                {
                    string text = InOutText.iotext.charactes[j].getSentence(index);
                    if (!text.Equals("Повторите непонятно")) {
                        InOutText.iotext.output.text = text;
                    }
                }
            }
            index++;
        } else {
            isDialogStarted = false;
        }
    }
}
