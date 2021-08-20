using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public int indexProject;
    public AudioClip audioClp;
    public AudioSource audioSrc;

    public void ChangeSound(int index)
    {
        switch (indexProject)
        {
            // wira
            case 0:
                audioClp = Resources.Load<AudioClip>($"Wira Dubbing/dubbing ({index})");
                break;

            // xime
            case 1:

                break;
        }
    }

    public void StopSound()
    {
        audioSrc.Stop();
    }

    public void PlaySound()
    {
        audioSrc.PlayOneShot(audioClp);
    }
}
