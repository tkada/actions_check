using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Builder
{
    public static void Build()
    {
        var message = "";
        var args = System.Environment.GetCommandLineArgs();
        for(var i=0;i<args.Length;i++)
        {
            if (args[i] == "-message")
            {
                message = args[i + 1];
            }
        }

        if(!string.IsNullOrEmpty(message))
        {
            Debug.Log("Message---->"+message);

            using(var writer = new System.IO.StreamWriter(Application.streamingAssetsPath+ "/message.txt"))
            {
                writer.Write(message);
            }
        }

        var option = new BuildPlayerOptions();
        option.target = BuildTarget.StandaloneWindows64;
        //�r���h�V�[���̃p�X��z��Ŏw��
        option.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        //�r���h�v���b�g�t�H�[�����̃t�H���_�ɓ���Ȃ��Ə�肭�����Ȃ�
        option.locationPathName = "build/StandaloneWindows64/Sample.exe";
        var result = BuildPipeline.BuildPlayer(option);
        if (result.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("BUILD SUCCEED");
            Debug.Log(result.summary.outputPath);
            Debug.Log($"{result.summary.totalSize:N}bytes");
            Debug.Log($"{result.summary.totalTime.TotalSeconds}seconds");
        }
        else
        {
            Debug.LogError("BUILD FAILED");
        }

        EditorApplication.Exit(result.summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}
