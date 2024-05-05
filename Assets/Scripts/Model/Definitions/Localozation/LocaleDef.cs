using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Scripts.Model.Definitions.Localozation
{
    [CreateAssetMenu(menuName = "Defs/LocaleDef", fileName = "LocaleDef")]
    public class LocaleDef : ScriptableObject
    {
        // en https://docs.google.com/spreadsheets/d/e/2PACX-1vSyzUH4mcQHJnPiygb3iObEH4hBbu1IELNpJJotP2JbBx-gZ73xkzJYuhV1sz11VoBNCd6M4HFaqNmq/pub?gid=0&single=true&output=tsv
        // ru https://docs.google.com/spreadsheets/d/e/2PACX-1vSyzUH4mcQHJnPiygb3iObEH4hBbu1IELNpJJotP2JbBx-gZ73xkzJYuhV1sz11VoBNCd6M4HFaqNmq/pub?gid=2037055761&single=true&output=tsv
        // pl https://docs.google.com/spreadsheets/d/e/2PACX-1vSyzUH4mcQHJnPiygb3iObEH4hBbu1IELNpJJotP2JbBx-gZ73xkzJYuhV1sz11VoBNCd6M4HFaqNmq/pub?gid=707468474&single=true&output=tsv

        [SerializeField] private string _url;
        [SerializeField] private List<LocaleItem> _localItems;
        
        private UnityWebRequest _request;


        public Dictionary<string, string> GetData()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in _localItems)
            {
                dict.Add(item.Key, item.Value);
            }
            return dict;
        }


        [ContextMenu("Update locale")]
        public void UpdateLocale()
        {
            if (_request != null) return;

            _request = UnityWebRequest.Get(_url);
            _request.SendWebRequest().completed += OnDataLoaded;
        }

        private void OnDataLoaded(AsyncOperation operation)
        {
            if (operation.isDone)
            {
                _localItems.Clear();
                var rows = _request.downloadHandler.text.Split('\n');
                foreach (var row in rows)
                {
                    AddLocaleItem(row);       
                }
                _request = null;
            }
        }

        private void AddLocaleItem(string row)
        {
            try
            {
                var parts = row.Split('\t');
                _localItems.Add(new LocaleItem {Key = parts[0], Value = parts[1]});
            }
            catch (Exception e)
            {
                Debug.Log($"Can't parce row: {row}. \n {e}");
            }
        }
    }


    [Serializable]
    public class LocaleItem
    {
        public string Key;
        public string Value;
    }
}