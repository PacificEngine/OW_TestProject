using OWML.Common;
using OWML.Common.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
{
    public class MockModHelper : IModHelper
    {
        public IModLogger Logger => null;

        public IModConsole Console => new MockModConsole();

        public IModEvents Events => null;

        public IHarmonyHelper HarmonyHelper => null;

        public IModAssets Assets => null;

        public IModStorage Storage => null;

        public IModMenus Menus => null;

        public IModManifest Manifest => null;

        public IModConfig Config => null;

        public IOwmlConfig OwmlConfig => null;

        public IModInteraction Interaction => null;
    }

    public class MockModConsole : IModConsole
    {
        public void WriteLine(params object[] objects)
        {
        }

        public void WriteLine(string line)
        {
        }

        public void WriteLine(string line, MessageType type)
        {
        }

        public void WriteLine(string line, MessageType type, string senderType)
        {
        }
    }
}
