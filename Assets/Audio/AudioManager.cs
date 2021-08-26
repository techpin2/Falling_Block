using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip myclip;

    public AudioItem[] songItem;

    public static AudioManager manager;

    private void Awake()
    {
        if(manager==null)
        {
             manager = this;
            print("Onject Initializing");
        }
        if (manager == this)
        {
            DontDestroyOnLoad(gameObject);
            print("Don't Destroy on load");
        }
        else
        {
            Destroy(gameObject);
            print("Already object Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //  source.clip = myclip;
            //source.Play();

            Play("Fire1");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("New");
        }
    }

    public void Play(string songName)
    {
        AudioItem item = System.Array.Find(songItem, s => s.name == songName);
        if (item != null)
        {
            source.Stop();
            source.clip = item.myclip;
            source.Play();
        }
        else
        {
            print("Eneter Valid Audio Name");
        }
    }
}
[System.Serializable]
public class AudioItem
{
    public string name;
    public AudioClip myclip;
}
