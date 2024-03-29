﻿using System.IO;
using UnityEngine;

namespace CAMOWA.FileImporting
{
    public class FileImporter
    {
        public static Texture2D ImportImage(string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);
            Texture2D image = new Texture2D(2, 2);
            image.LoadImage(imageBytes);
            return image;
        }

        public static AudioClip ImportWAVAudio(string filePath)
        {
            WAVImporter wav = new WAVImporter(filePath);
            AudioClip audioClip = AudioClip.Create(Path.GetFileName(filePath), wav.SampleCount, 1, wav.Frequency, false, false);
            audioClip.SetData(wav.LeftChannel, 0);
            return audioClip;
        }

        public static Mesh ImportOBJMesh(string filePath)
        {
            return ObjImporter.ImportFile(filePath);
        }
    }
}
