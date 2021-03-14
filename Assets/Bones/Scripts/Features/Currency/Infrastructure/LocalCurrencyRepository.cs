﻿using System.Collections.Generic;
using System.Linq;
using Bones.Scripts.Features.Currency.Services;
using JetBrains.Annotations;
using UnityEngine;

namespace Bones.Scripts.Features.Currency.Infrastructure
{
    [UsedImplicitly]
    public class LocalCurrencyRepository : CurrencyRepository
    {
        private const string CurrenciesRepoKey = "__currencies__repo";
        public Dictionary<string, int> currencies = new Dictionary<string, int>();
        
        public int this[string key]
        {
            get => currencies.TryGetValue(key, out var value)?value:0;
            set
            {
                currencies[key] = value;
                Save();
            }
        }

        public LocalCurrencyRepository()
        {
            Load();
        }
        
        public void Load()
        {
            var json = PlayerPrefs.GetString(CurrenciesRepoKey,string.Empty);
            if (string.IsNullOrEmpty(json))
            {
                return;   
            }
            var dto = JsonUtility.FromJson<CurrenciesDTO>(json);
            currencies = dto.currencies.ToDictionary(sc => sc.label, sc => sc.count);
        }

        public void Save()
        {
            var currenciesList = currencies.Select(pair => new CurrencyDTO {count = pair.Value, label = pair.Key}).ToList();
            var dto = new CurrenciesDTO
            {
                currencies = currenciesList
            };
            var json = JsonUtility.ToJson(dto);
            PlayerPrefs.SetString(CurrenciesRepoKey, json);
            PlayerPrefs.Save();
        }

    }
}