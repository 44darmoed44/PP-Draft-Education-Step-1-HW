using System;
using Scripts.Model.Data;
using Scripts.Model.Definitions;
using Scripts.Model.Definitions.Localozation;
using Scripts.UI.HUD.Dialog;
using UnityEngine;

namespace Scripts.Components.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogData _bound;
        [SerializeField] private DialogDef _external;

        [SerializeField] private string _key;
        
        private DialogBoxController _dialogBox;

        private void Start()
        {
            LocalisationManager.I.OnLocaleChanged += OnLocaleChanged;
            OnLocaleChanged();
        }

        private void OnLocaleChanged()
        {
            var sents = LocalisationManager.I.Locolize(_key).Split('&');
            _external.Data.ChangeSentences(sents);
        }

        public void Show()
        {
            if (_dialogBox == null) _dialogBox = FindObjectOfType<DialogBoxController>();
            _dialogBox.ShowDialog(Data);
        }

        public void Show(DialogDef def)
        {
            _external = def;
            OnLocaleChanged();
            Show();
        }

        public void SetKey(string key)
        {
            _key = key;
        }

        public void OnDestroy()
        {
            LocalisationManager.I.OnLocaleChanged -= OnLocaleChanged;
        }

        public DialogData Data
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Bound:
                        return _bound;
                    case Mode.External:
                        return _external.Data;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public enum Mode
        {
            Bound,
            External
        }
    }
}