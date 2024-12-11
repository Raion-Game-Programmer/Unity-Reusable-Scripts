using UnityEditor;
using UnityEngine;
public class DefineSymbolManager
{
    [MenuItem("Tools/PreProcessors/Debug/Enable Debug")]
    [System.Obsolete]
    public static void AddEnableDebugSymbol()
    {
        // Get current symbols for the standalone build group
        string currentSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

        // Define the new symbol
        string newSymbol = "ENABLE_DEBUG";

        // Check if it already exists
        if (!currentSymbols.Contains(newSymbol))
        {
            // Add the new symbol
            string updatedSymbols = string.IsNullOrEmpty(currentSymbols) ? newSymbol : $"{currentSymbols};{newSymbol}";
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, updatedSymbols);

            Debug.Log($"Added ENABLE_DEBUG symbol. Updated symbols: {updatedSymbols}");
        }
        else
        {
            Debug.Log("ENABLE_DEBUG symbol already exists.");
        }
    }

    [MenuItem("Tools/PreProcessors/Debug/Disable Debug")]
    [System.Obsolete]
    public static void RemoveEnableDebugSymbol()
    {
        // Get current symbols for the standalone build group
        string currentSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

        // Define the symbol to remove
        string symbolToRemove = "ENABLE_DEBUG";

        // Remove the symbol if it exists
        if (currentSymbols.Contains(symbolToRemove))
        {
            string updatedSymbols = currentSymbols.Replace(symbolToRemove, "").Replace(";;", ";").Trim(';');
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, updatedSymbols);

            Debug.Log($"Removed ENABLE_DEBUG symbol. Updated symbols: {updatedSymbols}");
        }
        else
        {
            Debug.Log("ENABLE_DEBUG symbol does not exist.");
        }
    }
}