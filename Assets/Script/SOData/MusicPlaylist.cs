using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMusicPlaylist", menuName = "Data/MusicPlaylist")]
public class MusicPlaylist : ScriptableObject
{
    // Get Music Here https://pixabay.com/music/search/genre/synth%20pop/
    public List<Vector2> SongPitchList = new List<Vector2>();
    public List<AudioClip> SongList = new List<AudioClip>();
}
