using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainGameMusic;
    public MusicPlaylist musicPlaylist;
    public int SongIndex = 0;
    private int SongTime;
    private void Start()
    {
        RandomSong();
    }
    private void Update()
    {
        if (!mainGameMusic.isPlaying && Application.isFocused)
        {
            NextSong();
        }
    }
    public void NextSong()
    {
        SongIndex++;
        if (SongIndex > (musicPlaylist.SongList.Count - 1))
        {
            SongIndex = 0;
        }
        SetMusic();
    }
    public void PreviousSong()
    {
        SongIndex--;
        if (SongIndex < 0)
        {
            SongIndex = musicPlaylist.SongList.Count - 1;
        }
        SetMusic();
    }
    public void SetMusic()
    {
        mainGameMusic.clip = musicPlaylist.SongList[SongIndex];
        float songPitch;
        if (Random.Range(0,1) == 0)
        {
            songPitch = musicPlaylist.SongPitchList[SongIndex].x;
        }
        else
        {
            songPitch = musicPlaylist.SongPitchList[SongIndex].y;
        }
        mainGameMusic.pitch = songPitch;
        PlayMusic();
    }
    public void PlayMusic()
    {
        mainGameMusic.Play();
    }
    public void PasueMusic()
    {
        mainGameMusic.Pause();
    }

    public void RandomSong()
    {
        SongIndex = Random.Range(0, musicPlaylist.SongList.Count - 1);
        Debug.Log(SongIndex);
        SetMusic();
    }
    
}
