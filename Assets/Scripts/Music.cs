using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using SimpleFileBrowser;

public class MusicController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public AudioSource audioSource;
    public Slider musicSlider;

    private List<string> playlist = new List<string>();
    private int currentSongIndex = -1;
    private Coroutine playCoroutine;
    private bool isSkipping = false;
    private bool isUserDraggingSlider = false;
    public GameObject O1;
    public GameObject O2;
    public GameObject button;
    public GameObject music;

    void Update()
    {
        if (musicSlider != null && audioSource != null && audioSource.clip != null && !isUserDraggingSlider)
        {
            if (audioSource.clip.length > 0)
            {
                musicSlider.value = audioSource.time / audioSource.clip.length;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isUserDraggingSlider = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (musicSlider != null && audioSource != null && audioSource.clip != null)
        {
            float targetTime = musicSlider.value * audioSource.clip.length;
            audioSource.time = targetTime;
        }
        isUserDraggingSlider = false;
    }

    public void OpenFilePicker()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Audio Files", ".mp3", ".wav", ".ogg"));
        FileBrowser.SetDefaultFilter(".mp3");

        FileBrowser.ShowLoadDialog(
            (paths) => 
            { 
                bool wasEmpty = playlist.Count == 0;
                foreach (string path in paths)
                {
                    playlist.Add(path);
                }

                if (wasEmpty || !audioSource.isPlaying)
                {
                    if (playCoroutine != null) StopCoroutine(playCoroutine);
                    playCoroutine = StartCoroutine(ProcessPlaylist());
                }
            },
            () => { Debug.Log("Cancelled"); },
            FileBrowser.PickMode.Files,
            true,
            null,
            null,
            "Load",
            "Select"
        );
    }

    private IEnumerator ProcessPlaylist()
    {
        while (true)
        {
            if (playlist.Count == 0) yield break;

            if (currentSongIndex < 0) currentSongIndex = 0;

            if (currentSongIndex < playlist.Count)
            {
                string nextPath = playlist[currentSongIndex];
                yield return StartCoroutine(LoadAndPlayAudio(nextPath));

                isSkipping = false;

                while ((audioSource.isPlaying || audioSource.time > 0) && !isSkipping)
                {
                    yield return null;
                }

                if (!isSkipping)
                {
                    currentSongIndex++;
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator LoadAndPlayAudio(string filePath)
    {
        string fileUrl = "file://" + filePath;
        AudioType audioType = AudioType.UNKNOWN;

        if (filePath.EndsWith(".mp3")) audioType = AudioType.MPEG;
        else if (filePath.EndsWith(".wav")) audioType = AudioType.WAV;
        else if (filePath.EndsWith(".ogg")) audioType = AudioType.OGGVORBIS;

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(fileUrl, audioType))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = clip;
                audioSource.Play();

                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                OnNewMusicStarted(fileName);
            }
        }
    }

    private void OnNewMusicStarted(string songTitle)
    {
        Debug.Log("Most induló zene: " + songTitle);
    }

    public void PlayPreviousSong()
    {
        if (playlist.Count == 0) return;

        if (audioSource.time > 3f)
        {
            audioSource.time = 0f;
            return;
        }

        if (currentSongIndex > 0)
        {
            currentSongIndex--;
            isSkipping = true;
            audioSource.Stop();
        }
        else
        {
            audioSource.time = 0f;
        }
    }

    public void PlayNextSong()
    {
        if (playlist.Count == 0) return;

        if (currentSongIndex < playlist.Count - 1)
        {
            currentSongIndex++;
            isSkipping = true;
            audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }

    public void SeekTo(float timeInSeconds)
    {
        audioSource.time = timeInSeconds;
    }

    public float GetCurrentTime()
    {
        return audioSource.time;
    }

    public float GetTotalDuration()
    {
        if (audioSource.clip != null)
            return audioSource.clip.length;
        return 0f;
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    public void StopMusic()
    {
        playlist.Clear();
        currentSongIndex = -1;
        isSkipping = true;
        if (playCoroutine != null) StopCoroutine(playCoroutine);
        audioSource.Stop();
    }
    public void Press1()
    {
        O1.SetActive(false);
        O2.SetActive(true);
    }
    public void Press2()
    {
        O1.SetActive(true);
        O2.SetActive(false);
    }
    public void Press3()
    {
        button.SetActive(false);
        music.SetActive(true);
    }
    public void Press4()
    {
        button.SetActive(true);
        music.SetActive(false);
    }
}