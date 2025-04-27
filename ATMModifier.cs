using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace ATMCustomizerMod
{
    public class ATMModifier
    {
        private static string customDepositText = "DEPOSIT CASH";
        private static string customWithdrawText = "WITHDRAW CASH";
        private static bool isInitialized = false;

        // Allow modification of the custom text
        public static void SetCustomDepositText(string text)
        {
            customDepositText = text;
            MelonLogger.Msg($"ATM deposit button text set to: {customDepositText}");
        }

        public static void SetCustomWithdrawText(string text)
        {
            customWithdrawText = text;
            MelonLogger.Msg($"ATM withdraw button text set to: {customWithdrawText}");
        }

        // Main method to check for and modify ATM UI
        public static void UpdateATMUI()
        {
            if (!isInitialized)
            {
                MelonLogger.Msg("ATM modifier activated");
                isInitialized = true;
            }

            // Look for ATM canvas
            var canvases = GameObject.FindObjectsOfType<Canvas>();
            foreach (var canvas in canvases)
            {
                if (canvas.name == "Canvas" && canvas.gameObject.activeInHierarchy)
                {
                    // Look for the title text to confirm it's the ATM screen
                    bool isATMScreen = false;
                    var texts = canvas.GetComponentsInChildren<Text>(true);
                    foreach (var text in texts)
                    {
                        if (text.text == "ATM" && text.gameObject.name == "Title")
                        {
                            isATMScreen = true;
                            break;
                        }
                    }

                    if (isATMScreen)
                    {
                        ModifyATMButtons(canvas);
                    }
                }
            }
        }

        private static void ModifyATMButtons(Canvas atmCanvas)
        {
            // Find and modify the deposit button
            try
            {
                // Using the path from the UI inspector: Menu/DepositButton
                Transform depositButton = atmCanvas.transform.Find("Menu/DepositButton");
                if (depositButton != null)
                {
                    Text buttonText = depositButton.GetComponentInChildren<Text>();
                    if (buttonText != null && buttonText.text == "DEPOSIT")
                    {
                        buttonText.text = customDepositText;
                        MelonLogger.Msg($"Modified deposit button text to: {customDepositText}");
                    }
                }

                // Using the path from the UI inspector: Menu/WithdrawButton
                Transform withdrawButton = atmCanvas.transform.Find("Menu/WithdrawButton");
                if (withdrawButton != null)
                {
                    Text buttonText = withdrawButton.GetComponentInChildren<Text>();
                    if (buttonText != null && buttonText.text == "WITHDRAW")
                    {
                        buttonText.text = customWithdrawText;
                        MelonLogger.Msg($"Modified withdraw button text to: {customWithdrawText}");
                    }
                }

                // Also update the legacy text components
                Text depositLegacyText = atmCanvas.transform.Find("Menu/DepositButton/Text (Legacy)")?.GetComponent<Text>();
                if (depositLegacyText != null && depositLegacyText.text == "DEPOSIT")
                {
                    depositLegacyText.text = customDepositText;
                }

                Text withdrawLegacyText = atmCanvas.transform.Find("Menu/WithdrawButton/Text (Legacy)")?.GetComponent<Text>();
                if (withdrawLegacyText != null && withdrawLegacyText.text == "WITHDRAW")
                {
                    withdrawLegacyText.text = customWithdrawText;
                }
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error modifying ATM buttons: {ex.Message}");
            }
        }
    }
} 