using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour
{
    public DragConnector[] Connectors;
    public AudioClip[] answerClip;
    public AudioClip[] questionClip;
    public AudioSource audioSource;
    public GameObject WinPanel;
    public void CheckWin()
    {
        int count = 0;
        for (int i = 0; i < Connectors.Length; i++)
        {
            if (Connectors[i].currentDropHandler != null)
            {
                if(Connectors[i].currentDropHandler.answer == Connectors[i].answer)
                {
                    count++; 
                }
            
            }
        }
        if(count == 6)
        {
            Debug.Log("win");
            WinPanel.gameObject.SetActive(true);

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
    public void PlaySoundQuestion(int index)
    {
        if (index >= 0 && index < questionClip.Length)
        {
            audioSource.clip = questionClip[index];
            audioSource.Play();
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
