using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parser : MonoBehaviour
{
    public Dialog[] Parse(string csvfile)
    {
        List<Dialog> list = new List<Dialog>();
        TextAsset csvData = Resources.Load<TextAsset>(csvfile);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 0; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialog dialog = new Dialog();

            dialog.original = row[1];
            dialog.read = row[2];
            dialog.korean = row[3];


            list.Add(dialog);

            if (++i < data.Length)
            {
                ;
            }
        }
        return list.ToArray();
    }
}
