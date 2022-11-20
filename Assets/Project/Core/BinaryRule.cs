using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace AMGOLCore
{
    public class BinaryRule : ARule
    {

        private List<int> _survive_rules;

        private bool[] _survive_mask;

        private int _survive_max;

        private List<int> _born_rules;

        private bool[] _born_mask;

        private int _born_max;

        public BinaryRule(List<int> survive_rules, List<int> born_rules)
        {
            _survive_rules = survive_rules;
            _survive_max = _survive_rules.Max();
            _survive_mask = new bool[_survive_max+1];
            foreach (int i in _survive_rules)
            {
                _survive_mask[i] = true;
            }

            _born_rules = born_rules;
            _born_max = _born_rules.Max();
            _born_mask = new bool[_born_max+1];
            foreach (int i in _born_rules)
            {
                _born_mask[i] = true;   
            }
        }

        public void PrintRule()
        {
            string s = "RULE: \n";
            s += EnumrableUtils.ToString<bool>(_survive_mask) + "\n";
            s += EnumrableUtils.ToString<bool>(_born_mask) + "\n";
            Debug.Log(s);
        }

        public override bool WillSurvive(ATile tile)
        {
            throw new System.NotImplementedException();
        }
    }
}