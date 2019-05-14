using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This class handles incoming audio events
/// </summary>
public class AudioManager : MonoBehaviour
{
   public AudioSource _audioSource;

   /// <summary>
   /// This function plays an audio file with the chosen volume
   /// </summary>
   /// <param name="audioClip"></param>
   /// <param name="volume"></param>
   public void PlayAudio(AudioClip audioClip, float volume)
   {
      _audioSource.clip = audioClip;
      _audioSource.PlayOneShot(audioClip, volume);
   }
}
