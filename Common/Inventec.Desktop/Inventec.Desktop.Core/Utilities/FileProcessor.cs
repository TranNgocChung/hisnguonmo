#region License

// Created by phuongdt

#endregion

using System;
using System.IO;

namespace Inventec.Desktop.Core.Utilities
{
    /// <summary>
    /// A helper class providing methods for processing files.
    /// </summary>
    public class FileProcessor
    {
        /// <summary>
        /// Delegate for use by the <see cref="FileProcessor.Process(string,string,ProcessFile,bool)"/> method.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        public delegate void ProcessFile(string filePath);

        /// <summary>
        /// Delegate for use by the <see cref="FileProcessor.Process(string,string,ProcessFileCancellable,bool)"/> method.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        /// <param name="cancel">Gets whether or not the entire processing operation should be cancelled.</param>
        public delegate void ProcessFileCancellable(string filePath, out bool cancel);

        /// <summary>
        /// Processes all files on the given <paramref name="path"/> matching the specified <paramref name="searchPattern"/>.
        /// </summary>
        /// <remarks>
        /// The input <paramref name="path"/> can be a file or a directory.
        /// </remarks>
        /// <param name="path">The root path to the file(s) to be processed.</param>
        /// <param name="searchPattern">The search pattern to be used.  A value of <b>null</b> or <b>""</b> indicates that all files are a match.</param>
        /// <param name="proc">The method to call for each matching file.</param>
        /// <param name="recursive">Whether or not the <paramref name="path"/> should be searched recursively.</param>
        public static void Process(string path, string searchPattern, ProcessFile proc, bool recursive)
        {
            Process(path, searchPattern,
                delegate(string filePath, out bool cancel)
                {
                    cancel = false;
                    proc(filePath);
                },
                recursive);
        }

        public static string RemovePrePluginName(string p)
        {
            int lastIndexOfdll = p.LastIndexOf(".dll");
            int lastIndexOfGachGach = p.LastIndexOf("\\");
            string pname = p.Substring(lastIndexOfGachGach + 1, (lastIndexOfdll - lastIndexOfGachGach - 1)).ToLower();

            return pname;
        }

        /// <summary>
        /// Processes all files on the given <paramref name="path"/> matching the specified <paramref name="searchPattern"/>.
        /// </summary>
        /// <remarks>
        /// The input <paramref name="path"/> can be a file or a directory.
        /// </remarks>
        /// <param name="path">The root path to the file(s) to be processed.</param>
        /// <param name="searchPattern">The search pattern to be used.  A value of <b>null</b> or <b>""</b> indicates that all files are a match.</param>
        /// <param name="proc">The method to call for each matching file.</param>
        /// <param name="recursive">Whether or not the <paramref name="path"/> should be searched recursively.</param>
        /// <returns>True if the process was cancelled; False otherwise</returns>
        public static bool Process(string path, string searchPattern, ProcessFileCancellable proc, bool recursive)
        {
            Platform.CheckForNullReference(path, "path");
            Platform.CheckForEmptyString(path, "path");
            Platform.CheckForNullReference(proc, "proc");

            bool cancel;

            // If the path is a directory, process its contents
            if (Directory.Exists(path))
            {
                ProcessDirectory(path, searchPattern, proc, recursive, out cancel);
            }
            // If the path is a file, just process the file
            else if (File.Exists(path))
            {
                proc(path, out cancel);
            }
            else
            {
                throw new FileNotFoundException(String.Format(SR.ExceptionPathDoesNotExist, path));
            }

            // TODO: from API perspective, more intuitive if this returns false when cancelled. Leave it as is for now.
            return cancel;
        }

        private static void ProcessDirectory(string path, string searchPattern, ProcessFileCancellable proc, bool recursive, out bool cancel)
        {
            cancel = false;

            // Process files in this directory
            string[] fileList;
            GetFiles(path, searchPattern, out fileList);

            if (fileList != null)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    proc(fileList[i], out cancel);
                    if (cancel)
                        return;
                    fileList[i] = null;
                }
            }

            if (!recursive) return;

            // If recursive, then descend into lower directories and process those as well
            TraverseDirectories(path, searchPattern, proc, out cancel);
        }

        private static void GetFiles(string path, string searchPattern, out string[] fileList)
        {
            fileList = null;

            try
            {
                fileList = string.IsNullOrEmpty(searchPattern)
                    ? Directory.GetFiles(path)
                    : Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                Platform.Log(LogLevel.Warn, e);
                throw;
            }
        }

        private static void TraverseDirectories(string path, string searchPattern, ProcessFileCancellable proc, out bool cancel)
        {
            string[] dirList;

            cancel = false;

            try
            {
                dirList = Directory.GetDirectories(path);
            }
            catch (Exception e)
            {
                Platform.Log(LogLevel.Warn, e);
                throw;
            }

            for (int i = 0; i < dirList.Length; i++)
            {
                ProcessDirectory(dirList[i], searchPattern, proc, true, out cancel);
                if (cancel)
                    break;
                dirList[i] = null;
            }


        }
    }
}
