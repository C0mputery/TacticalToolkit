using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TacticalToolkit
{
    public static class TacticalToolkitUI
    {
        internal static readonly AssetBundle assetBundle = TacticalToolkitAssetBundle.LoadFromAssembly(TacticalToolkitAssembly.ActiveTacticalToolkitAssembly, "TacticalToolkit.Resources.Internal.UI.TT-lowerleftbuttons-button.asset");

        /// <summary>
        /// This is a method that does adds a button to the main menu.
        /// </summary>
        /// <param name="Text">Text on the button.</param>
        /// <param name="orderInList">Location on the list. This will be reworked at some point</param>
        /// <returns>Returns a Button. will also be reworked to return a more usefull class with more things</returns>
        public static Button AddLowerUIButton(string Text, int orderInList)
        {
            return AddLowerUIButton(TacticalToolkitAssembly.ActiveTacticalToolkitAssembly, "TacticalToolkit.Resources.Internal.UI.TT-ButtonIcon.png", Text, orderInList);
        }

        /// <summary>
        /// This is a method that does adds a button to the main menu.
        /// </summary>
        /// <param name="PNGIconFileAssembly">An assembly that contains an emmbed png to load as a icon</param>
        /// <param name="PNGIconFilePath">The path within the assembly to the png</param>
        /// <param name="Text">Text on the button.</param>
        /// <param name="orderInList">Location on the list. This will be reworked at some point</param>
        /// <returns>Returns a Button. will also be reworked to return a more usefull class with more things</returns>
        public static Button AddLowerUIButton(Assembly PNGIconFileAssembly, string PNGIconFilePath, string Text, int orderInList)
        {
            GameObject gameObject = assetBundle.LoadAsset<GameObject>("tt-lowerleftbuttons button");
            gameObject.GetComponentInChildren<TMP_Text>().text = Text;
            bool flag = Enumerable.Contains<string>(PNGIconFileAssembly.GetManifestResourceNames(), PNGIconFilePath);
            if (flag)
            {
                using (Stream manifestResourceStream = PNGIconFileAssembly.GetManifestResourceStream(PNGIconFilePath))
                {
                    using (MemoryStream memoryStream = new MemoryStream((int)manifestResourceStream.Length))
                    {
                        manifestResourceStream.CopyTo(memoryStream);
                        Texture2D texture2D = new Texture2D(2, 2);
                        texture2D.LoadImage(memoryStream.ToArray());
                        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f), 100f);
                    }
                }
            }
            GameObject gameObject2 = GameObject.Find("/MainMenuCamPivot/MainMenuCam/UICAM/Canvas/MainScreen/LowerLeftButtons");
            RectTransform component = gameObject2.GetComponent<RectTransform>();
            component.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y + 60f);
            GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameObject, gameObject2.transform);
            gameObject3.transform.SetSiblingIndex(orderInList);
            return gameObject.GetComponent<Button>();
        }

        /// <summary>
        /// Adds a blank space to the main menu.
        /// </summary>
        /// <param name="orderInList">Location on the list. This will be reworked at some point</param>
        public static void AddLowerUISpace(int orderInList)
        {
            GameObject gameObject = new GameObject("space");
            GameObject gameObject2 = GameObject.Find("/MainMenuCamPivot/MainMenuCam/UICAM/Canvas/MainScreen/LowerLeftButtons");
            RectTransform component = gameObject2.GetComponent<RectTransform>();
            component.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y + 60f);
            gameObject.transform.parent = gameObject2.transform;
            gameObject.AddComponent<RectTransform>();
            gameObject.transform.SetSiblingIndex(orderInList);
        }

        internal static void FixOptionsTabs()
        {
            GameObject gameObject = GameObject.Find("/MainMenuCamPivot/MainMenuCam/UICAM/Canvas/OptionsMenu/TABS");
            GridLayoutGroup gridLayoutGroup = gameObject.AddComponent<GridLayoutGroup>();
            gridLayoutGroup.cellSize = new Vector2(250f, 50f);
            gridLayoutGroup.spacing = new Vector2(25f, 0f);
            RectTransform component = gameObject.GetComponent<RectTransform>();
            component.offsetMin = new Vector2(440f, 850f);
            component.offsetMax = new Vector2(0f, -175f);
        }
    }
}
