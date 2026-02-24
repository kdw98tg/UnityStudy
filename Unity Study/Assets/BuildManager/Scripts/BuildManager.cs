#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public enum BuildType
{
    Development,
    Test,
    Release
}

public class BuildManager : Editor
{
    //Player 항목에서 심볼 복사해옴
    public const string DEV_SCRIPTING_DEFINE_SYMBOLS = "PHOTON_UNITY_NETWORKING;PUN_2_0_OR_NEWER;PUN_2_OR_NEWER;PUN_2_19_OR_NEWER;DEV_VER;TEST_VER;REAL_VER";

    //실제 릴리즈 에서는 DEV_VER만 제외해서 대입하면 됨
    public const string REAL_SCRIPTING_DEFINE_SYMBOLS = "MOREMOUNTAINS_TOOLS;MOREMOUNTAINS_FEEDBACKS;MOREMOUNTAINS_INTERFACE;MOREMOUNTAINS_TOOLS_FOR_MMFEEDBACKS;MOREMOUNTAINS_TEXTMESHPRO_INSTALLED;MOREMOUNTAINS_INVENTORYENGINE;MOREMOUNTAINS_CORGIENGINE;MOREMOUNTAINS_POSTPROCESSING_INSTALLED;UNITY_POST_PROCESSING_STACK_V2;";

    private static BuildType m_BuildType = BuildType.Development;

    [MenuItem("Build/AOS/Set AOS DEV Build Settings")]
    public static void SetAOSDEVBuildSettings()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        EditorUserBuildSettings.buildAppBundle = false;
        PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Android, DEV_SCRIPTING_DEFINE_SYMBOLS);

        m_BuildType = BuildType.Development;
    }

    [MenuItem("Build/AOS/Set AOS TEST Build Settings")]
    public static void SetAOSTESTBuildSettings()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        EditorUserBuildSettings.buildAppBundle = true;
        PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Android, DEV_SCRIPTING_DEFINE_SYMBOLS);
        // PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, DEV_SCRIPTING_DEFINE_SYMBOLS);

        m_BuildType = BuildType.Test;
    }

    [MenuItem("Build/AOS/Set AOS REAL Build Settings")]
    public static void SetAOSREALBuildSettings()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        EditorUserBuildSettings.buildAppBundle = true;
        PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Android, REAL_SCRIPTING_DEFINE_SYMBOLS);
        // PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, REAL_SCRIPTING_DEFINE_SYMBOLS);

        m_BuildType = BuildType.Release;
    }

    [MenuItem("Build/Start AOS Build")]
    public static void StartAOSBuild()
    {
        PlayerSettings.Android.keystoreName = "Builds/AOS/burningcarrotstudio.keystore";
        PlayerSettings.Android.keystorePass = "comebackhome1!";
        PlayerSettings.Android.keyaliasName = "bouncecat";
        PlayerSettings.Android.keyaliasPass = "tekken1!";

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

        //빌드 할 씬을 차례로 입력
        buildPlayerOptions.scenes = new[]
        {
            "Assets/Scenes/Title.unity",
            "Assets/Scenes/Lobby.unity",
            "Assets/Scenes/InGame.unity"
        };
        buildPlayerOptions.target = BuildTarget.Android;

        string fileExtention = string.Empty;
        BuildOptions compressOption = BuildOptions.None;
        switch (m_BuildType)
        {
            case BuildType.Development:
                fileExtention = "apk";
                compressOption = BuildOptions.CompressWithLz4;
                break;
            case BuildType.Test:
            case BuildType.Release:
                fileExtention = "aab";
                compressOption = BuildOptions.CompressWithLz4HC;
                break;
            default:
                break;
        }

        //파일명 지정
        buildPlayerOptions.locationPathName = $"Builds/AOS/BounceCat_{Application.version}_{DateTime.Now.ToString("yyMMdd_HHmmss")}.{fileExtention}";
        buildPlayerOptions.options = compressOption;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build succeeded. {summary.totalSize} bytes.");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError($"Build failed");
        }
    }
}

#endif