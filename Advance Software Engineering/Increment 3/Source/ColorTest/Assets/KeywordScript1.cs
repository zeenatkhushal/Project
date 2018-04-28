using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordScript1 : MonoBehaviour
{
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
        mat = GetComponent<MeshRenderer>().material;
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
        ApplyColor(args.text);
    }

    public Material mat;

    void ApplyColor(String color)
    {
        if (color == "green")
        {
            mat.color = Color.green;
            GetComponent<AudioSource>().clip = audio1;
            GetComponent<AudioSource>().Play();
            
        }
        if (color == "blue")
        {
            mat.color = Color.blue;
            GetComponent<AudioSource>().clip = audio2;
            GetComponent<AudioSource>().Play();
        }

        if (color == "yellow")
        {
            mat.color = Color.yellow;
            GetComponent<AudioSource>().clip = audio3;
            GetComponent<AudioSource>().Play();
        }
        if (color == "black")
        {
            mat.color = Color.black;
            GetComponent<AudioSource>().clip = audio4;
        }
    }



}

