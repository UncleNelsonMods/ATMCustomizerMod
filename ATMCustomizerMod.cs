using MelonLoader;
using MelonLoader.Utils;
using System.IO;
using System.Text.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(ATMCustomizerMod.ATMCustomizerMod), "ATMCustomizerMod", "1.0.0", "John")]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace ATMCustomizerMod
{
    public class ATMCustomizerMod : MelonMod
    {
        private ModConfig config;
        
        public override void OnInitializeMelon()
        {
            LoadConfig();
            MelonLogger.Msg($"ATM Customizer Mod Initialized");
            MelonLogger.Msg("ATM text modification active");
            
            // Configure ATM text from config
            if (!string.IsNullOrEmpty(config.DepositText)) 
            {
                ATMModifier.SetCustomDepositText(config.DepositText);
            }
            
            if (!string.IsNullOrEmpty(config.WithdrawText))
            {
                ATMModifier.SetCustomWithdrawText(config.WithdrawText);
            }
        }

        public override void OnUpdate()
        {
            // Check for and update ATM UI every frame when mod is enabled
            if (config.IsEnabled)
            {
                ATMModifier.UpdateATMUI();
            }
        }

        private void LoadConfig()
        {
            string configPath = Path.Combine(MelonEnvironment.ModsDirectory, "ATMCustomizerMod.json");
            
            // Create default config if it doesn't exist
            if (!File.Exists(configPath))
            {
                config = new ModConfig
                {
                    IsEnabled = true,
                    DepositText = "DEPOSIT CASH",
                    WithdrawText = "WITHDRAW CASH"
                };
                SaveConfig(configPath);
            }
            else
            {
                string json = File.ReadAllText(configPath);
                config = JsonSerializer.Deserialize<ModConfig>(json);
            }
        }

        private void SaveConfig(string path)
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }

    public class ModConfig
    {
        public bool IsEnabled { get; set; }
        public string DepositText { get; set; }
        public string WithdrawText { get; set; }
    }
} 