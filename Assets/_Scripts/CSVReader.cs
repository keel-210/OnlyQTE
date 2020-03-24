using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
public class CSVReader
{
    public List<Note> ReadScore(string path)
    {
        List<Note> notes = new List<Note>();
        TextAsset csv = Resources.Load(path) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            if (line.Contains(","))//先頭無視
            {
                 var s = line.Split(',');
                Note n = new Note();
                n.Time = int.Parse(s[0]);
                n.NoteType = (NoteEnum)System.Enum.Parse(typeof(NoteEnum), s[1]);
                notes.Add(n);
            }
        }
        return notes;
    }
}
