using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace DefaultNamespace.Editor
{
    public class BuildAndReplaceHotkey : MonoBehaviour
    {
        [MenuItem("Utilities/Build and Run Two Copies ^b")]
        private static void BuildAndRun()
        {
            Debug.Log("Building and running!");
            
            var originalPath = Application.dataPath + "/../Builds/test.app";
            var copyPath = Application.dataPath + "/../Builds/test1.app";
            
            // remove existing
            Directory.Delete(originalPath, true);
            Directory.Delete(copyPath, true);
            
            // do a build
            BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                locationPathName = originalPath,
                target = BuildTarget.StandaloneOSX
            });
            
            // copy the build
            CopyDirectory(originalPath, copyPath, true);
            
            // run both copies
            Process.Start(originalPath);
            Process.Start(copyPath);
        }

        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            var dirs = dir.GetDirectories();

            Directory.CreateDirectory(destinationDir);

            foreach (var file in dir.GetFiles())
            {
                var targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (!recursive) return;
            
            foreach (var subDir in dirs)
            {
                var newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir, true);
            }
        }
    }
}