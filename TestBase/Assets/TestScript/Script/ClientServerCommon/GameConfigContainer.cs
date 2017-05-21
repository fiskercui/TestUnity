namespace ClientServerCommon
{
    using System;
    using System.Collections.Generic;

    public class GameConfigContainer
    {
        private static GameConfigContainer gameConfigContainer = new GameConfigContainer();
        private Dictionary<string, string> gameConfigs = new Dictionary<string, string>();

        private GameConfigContainer()
        {
        }

        public void Add(string fileName, string fileContent)
        {
            this.gameConfigs[fileName] = fileContent;
        }

        public void Clear()
        {
            this.gameConfigs.Clear();
        }

        public bool Contains(string filePath)
        {
            return this.gameConfigs.ContainsKey(filePath);
        }

        public string GetContent(string fileName)
        {
            return this.gameConfigs[fileName];
        }

        public static GameConfigContainer Instance()
        {
            return gameConfigContainer;
        }
    }
}

