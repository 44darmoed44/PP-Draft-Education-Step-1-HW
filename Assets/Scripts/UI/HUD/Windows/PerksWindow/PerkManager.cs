using System;
using System.Collections.Generic;
using Scripts.Model;
using Scripts.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.UI.HUD.Windows.PerksWindow
{    
    public class PerkManager : MonoBehaviour
    {
        [SerializeField] private GameObject _perkPrefab;
        [SerializeField] private InfoWidget _infoWidget;
        [SerializeField] private Transform[] _rows;
        [SerializeField] private Button[] _buttons;

        private List<PerkWidget> _perks = new List<PerkWidget>();
        private string _section = "movement";

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            UpdatePerksTree();
        }

        public void UpdatePerksTree()
        {
            // clear perks tree
            _perks.Clear();
            foreach (var row in _rows)
            {
                for (var i = 0; i < row.childCount; i++)
                {
                    Destroy(row.GetChild(i).gameObject);
                }
            }

            // update perks tree
            var perksDef = DefsFacade.I.Perks.PerksList;
            foreach (var perk in perksDef)
            {
                if (perk.PerkItem.Section == _section)
                {
                    var row = _rows[perk.PerkItem.Row-1];
                    var perkInst = Instantiate(_perkPrefab, row.position, Quaternion.identity, row);

                    var perkWidget = perkInst.GetComponent<PerkWidget>();
                    perkWidget.UpdateWidget(
                        perk.PerkItem.Id, perk.Icon, 
                        !_session.Data.Perks.Contains(perk.PerkItem.Id)
                    );

                    _perks.Add(perkWidget);
                }
            }

            // update section buttons
            foreach (var btn in _buttons)
            {
                btn.interactable = !btn.gameObject.name.Contains(_section);
            }
        }

        public void UpdatePerkSelected(string selectedId)
        {
            foreach (var perk in _perks)
            {
                if (perk.Id == selectedId)
                {
                    perk.IsSelected.SetActive(true);

                    var perkData = DefsFacade.I.Perks.GetPerkDataFromPerksList(perk.Id);
                    _infoWidget.SetInfoProperty(
                        id: perk.Id,
                        infoKey: perkData.InfoKey, 
                        priceValue: perkData.PerkItem.Price,
                        isLocked: !_session.Data.Perks.Contains(perk.Id)
                    );
                }
                else
                {
                    perk.IsSelected.SetActive(false);
                }
            }
        }
        
        public void SetSection(string newSection)
        {
            _section = newSection;
        }

        public void OnButtonUpdatePerkList()
        {
            UpdatePerksTree();
            _infoWidget.SetInfoProperty(
                id: null,
                infoKey: "default_perk_info", 
                priceValue: 0,
                isLocked: false
            );
        }
    }
}