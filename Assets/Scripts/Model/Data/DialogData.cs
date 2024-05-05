using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private string[] _sentences;
        public string[] Sentences => _sentences;

        public void ChangeSentences(string[] newSentArray)
        {
            var newSent = new List<string>();

            foreach (var sent in newSentArray)
            {
                newSent.Add(sent);
            }

            _sentences = newSent.ToArray();
        }
    }
}