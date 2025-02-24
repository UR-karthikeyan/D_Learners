using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public Sprite[] allSprites;
    public DropZone[] dropZones;


    public AudioClip[] answerClip;
    public AudioSource audioSource;

    public void CheckWin()
    {
        int count = 0;
        for (int i = 0; i < dropZones.Length; i++)
        {
            if(dropZones[i].winCount == dropZones[i].count)
            {
                count++;
            }
        }
        if(count == 3)
        {
            Debug.Log("win");
            PlaySoundAnswer(0);
            PlaySoundAnswer(2);
        }
    }
    public void ButtonCheck()
    {
        int count = 0;
        for (int i = 0; i < dropZones.Length; i++)
        {
            if (dropZones[i].winCount == dropZones[i].count)
            {
                count++;
            }
        }
        if (count == 3)
        {
            PlaySoundAnswer(0);
            PlaySoundAnswer(2);
        }
        else
        {
            PlaySoundAnswer(1);
        }
    }
    public void PlaySoundAnswer(int index)
    {
        if (index >= 0 && index < answerClip.Length)
        {
            audioSource.clip = answerClip[index];
            audioSource.Play();
        }
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
