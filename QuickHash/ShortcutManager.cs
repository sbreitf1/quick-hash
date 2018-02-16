using IWshRuntimeLibrary;
using System;
using System.IO;
using File = System.IO.File;

namespace QuickHash
{
    static class ShortcutManager
    {
        public static string GetLinkPath(Environment.SpecialFolder folder, string path, string name)
        {
            return Path.Combine(Path.Combine(Environment.GetFolderPath(folder), path), name + ".lnk");
        }

        public static bool ShortcutExists(Environment.SpecialFolder folder, string path, string name)
        {
            return File.Exists(GetLinkPath(folder, path, name));
        }

        public static void CreateShortcut(Environment.SpecialFolder folder, string path, string name, string target)
        {
            string linkPath = GetLinkPath(folder, path, name);

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(linkPath);
            shortcut.Description = name;
            shortcut.TargetPath = target;
            shortcut.Save();
        }

        public static void DeleteShortcut(Environment.SpecialFolder folder, string path, string name)
        {
            File.Delete(GetLinkPath(folder, path, name));
        }
    }
}
