using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class A2DInfiniteAirplaneEditor : EditorWindow
{
    private string[] m_tabs = { "Game Manager", "Shop Manager", "Item Generator", "Enemy Generator", "Background", "UI Manager", "Audio Manager", "Character Controller", "Contact" };
    private int m_tabsSelected = -1;
    Vector2 scrollPos, scrollPos2, scrollPos3, scrollPos4, scrollPos5, scrollPos6, scrollPos7;

    public string[] options = new string[] { "Game", "Pause", "GameOver", "Main Menu","Shop","Loading" };
    public int index = 0;


    private static A2DInfiniteAirplaneEditor window;

    A2DGuiManager GameUI ;
    A2DGameManager GameM ;
    A2DPlayerController GameP;
    A2DBackgroundGenerator GameB;
    A2DGeneratorItems GameG;
    A2DSoundManager GameS;
    A2DShopItemsManager GameUIShop;
    A2DGameUI GameUI2;
    A2DPauseUI GameUIPause;
    A2DGameOverUI GameUIGameover;
    A2DMainMenu GameUIMainMenu;
    A2DLoadingUI GameUILoading;
    SerializedObject GameMusiSE, GameUIShopSE, GameMSE, GamePSE, GameBSE, GameGSE;



    [MenuItem("Denvzla Estudio/Infinite Airplane Shooter Engine/ 2D Airplane Engine Editor")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        window = (A2DInfiniteAirplaneEditor)EditorWindow.GetWindow(typeof(A2DInfiniteAirplaneEditor)); ;
        window.Show();
    }

    [MenuItem("Denvzla Estudio/Infinite Airplane Shooter Engine/Online Manual")]
    public static void OnlineManual()
    {
        Application.OpenURL("https://denvzla-estudio.gitbook.io/infinite-airplane-shooter-engine-2d/");
    }

    [MenuItem("Denvzla Estudio/Official Website")]
    public static void OfficialWebsite()
    {
        Application.OpenURL("https://denvzlaestudio.proboards.com/");
    }

    [MenuItem("Denvzla Estudio/Forum Oficial")]
    public static void OfficialForum()
    {
        Application.OpenURL("https://denvzlaestudio.proboards.com/");
    }

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(A2DInfiniteAirplaneEditor));

    }
    // Update is called once per frame
    void OnGUI()
    {
        Texture2D m_Logo = (Texture2D)Resources.Load("Img/IconAir", typeof(Texture2D));
        GUILayout.Label(m_Logo, GUILayout.ExpandWidth(true), GUILayout.Height(220));
        GUILayout.Space(10f);

        FindElements();
        if (GameM)
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            m_tabsSelected = GUILayout.SelectionGrid(m_tabsSelected, m_tabs, 2);
            EditorGUILayout.EndVertical();
            if (m_tabsSelected >= 0 && m_tabsSelected < m_tabs.Length)
            {
                switch (m_tabs[m_tabsSelected])
                {
                    case "Game Manager":
                        GameManager();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "Item Generator":
                        GeneratorItems();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "Enemy Generator":
                        EnemyGenerator();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "Shop Manager":
                        ShopManager();
                        break;
                    case "Background":
                        Background();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "UI Manager":
                        UIManager();
                        break;
                    case "Audio Manager":
                        SoundManager();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "Character Controller":
                        CharacterController();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                    case "Contact":
                        Contact();
                        if (GameM)
                        {
                            GameUI.GameGUI.SetActive(false);
                            GameUI.PauseGUI.SetActive(false);
                            GameUI.GameOverGUI.SetActive(false);
                            GameUI.MainMenu.SetActive(true);
                            GameUI.ShopGui.SetActive(false);
                            GameUI.LoadingGui.SetActive(false);
                        }
                        break;
                }

            }
        }
        else
        {

            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));
           
            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();
           
           

        }
    }

    void FindElements()
    {
        GameM = FindObjectOfType<A2DGameManager>();
       
        if (GameM)
        {
            GameUI = FindObjectOfType<A2DGuiManager>();
            GameP = FindObjectOfType<A2DPlayerController>();
            GameB = FindObjectOfType<A2DBackgroundGenerator>();
            GameG = FindObjectOfType<A2DGeneratorItems>();
            GameS = FindObjectOfType<A2DSoundManager>();
            if (GameG)
            {
                GameGSE = new SerializedObject(GameG);
            }
            if (GameB)
            {
                GameBSE = new SerializedObject(GameB);
            }
            if (GameP)
            {
                GamePSE = new SerializedObject(GameP);
            }
            if (GameM)
            {
                GameMSE = new SerializedObject(GameM);
            }
            if (GameS)
            {

                GameMusiSE = new SerializedObject(GameS);
            } 
        }
    }

    void ShopManager()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos2 = EditorGUILayout.BeginScrollView(scrollPos2, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);

            GUILayout.Label("Shop Manager", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameUI.GameGUI.SetActive(false);
            GameUI.PauseGUI.SetActive(false);
            GameUI.GameOverGUI.SetActive(false);
            GameUI.MainMenu.SetActive(false);
            GameUI.ShopGui.SetActive(true);
            GameUI.LoadingGui.SetActive(false);

            GameUIShop = FindObjectOfType<A2DShopItemsManager>();
            GameUIShopSE = new SerializedObject(GameUIShop);

            GameUIShopSE.Update();
            SerializedProperty stringsProperty = GameUIShopSE.FindProperty("Items");
            EditorGUILayout.PropertyField(stringsProperty, true);
            GameUIShopSE.ApplyModifiedProperties();
            GUILayout.Space(10f);




            GUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();

    }

    void UIManager()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos7 = EditorGUILayout.BeginScrollView(scrollPos7, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);

            GUILayout.Label("UI Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            index = EditorGUILayout.Popup(index, options);
            GUILayout.Space(10f);
            switch (index)
            {
                case 0:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("Game UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    GameUI.GameGUI.SetActive(true);
                    GameUI.PauseGUI.SetActive(false);
                    GameUI.GameOverGUI.SetActive(false);
                    GameUI.MainMenu.SetActive(false);
                    GameUI.ShopGui.SetActive(false);
                    GameUI.LoadingGui.SetActive(false);

                    GameUI2 = FindObjectOfType<A2DGameUI>();

                    GameUI2.BtnPause = EditorGUILayout.ObjectField("Btn Pause: ", GameUI2.BtnPause, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUI2.ImgCoin = EditorGUILayout.ObjectField("Img Coin: ", GameUI2.ImgCoin, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUI2.ImgLife = EditorGUILayout.ObjectField("Img Life: ", GameUI2.ImgLife, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUI2.BtnWeapon1 = EditorGUILayout.ObjectField("Btn Weapon 1: ", GameUI2.BtnWeapon1, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUI2.BtnWeapon2 = EditorGUILayout.ObjectField("Btn Weapon 2: ", GameUI2.BtnWeapon2, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUI2.BtnWeapon3 = EditorGUILayout.ObjectField("Btn Weapon 3: ", GameUI2.BtnWeapon3, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUI2.InfoWeapon1 = EditorGUILayout.ObjectField("Info Weapon 1: ", GameUI2.InfoWeapon1, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUI2.InfoWeapon2 = EditorGUILayout.ObjectField("InfoWeapon2: ", GameUI2.InfoWeapon2, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUI2.InfoWeapon3 = EditorGUILayout.ObjectField("Info Weapon 3: ", GameUI2.InfoWeapon3, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUI2.InfoShield = EditorGUILayout.ObjectField("Info Shield: ", GameUI2.InfoShield, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);


                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                case 1:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("Pause UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    
                    GameUI.GameGUI.SetActive(false);
                    GameUI.PauseGUI.SetActive(true);
                    GameUI.GameOverGUI.SetActive(false);
                    GameUI.MainMenu.SetActive(false);
                    GameUI.ShopGui.SetActive(false);
                    GameUI.LoadingGui.SetActive(false);

                    GameUIPause = FindObjectOfType<A2DPauseUI>();

                    GameUIPause.BtnContinue = EditorGUILayout.ObjectField("Btn Continue: ", GameUIPause.BtnContinue, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIPause.BtnExit = EditorGUILayout.ObjectField("Btn Exit: ", GameUIPause.BtnExit, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIPause.TextPause = EditorGUILayout.ObjectField("Text Pause: ", GameUIPause.TextPause, typeof(Text), true) as Text;
                    GUILayout.Space(10f);


                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                case 2:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("GameOver UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    GameUI.GameGUI.SetActive(false);
                    GameUI.PauseGUI.SetActive(false);
                    GameUI.GameOverGUI.SetActive(true);
                    GameUI.MainMenu.SetActive(false);
                    GameUI.ShopGui.SetActive(false);
                    GameUI.LoadingGui.SetActive(false);

                    GameUIGameover = FindObjectOfType<A2DGameOverUI>();

                    GameUIGameover.BtnRetry = EditorGUILayout.ObjectField("Btn Retry: ", GameUIGameover.BtnRetry, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIGameover.BtnExit = EditorGUILayout.ObjectField("Btn Exit: ", GameUIGameover.BtnExit, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIGameover.TextGameover = EditorGUILayout.ObjectField("Text GameOver: ", GameUIGameover.TextGameover, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIGameover.TextCoin = EditorGUILayout.ObjectField("Text Coin: ", GameUIGameover.TextCoin, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIGameover.ImgCoin = EditorGUILayout.ObjectField("Img Coin: ", GameUIGameover.ImgCoin, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUIGameover.TextTotalCoin = EditorGUILayout.ObjectField("Text Total Coin: ", GameUIGameover.TextTotalCoin, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIGameover.ImgTotalCoin = EditorGUILayout.ObjectField("Img Total Coin: ", GameUIGameover.ImgTotalCoin, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);



                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                case 3:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("MainMenu UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    GameUI.GameGUI.SetActive(false);
                    GameUI.PauseGUI.SetActive(false);
                    GameUI.GameOverGUI.SetActive(false);
                    GameUI.MainMenu.SetActive(true);
                    GameUI.ShopGui.SetActive(false);
                    GameUI.LoadingGui.SetActive(false);

                    GameUIMainMenu = FindObjectOfType<A2DMainMenu>();

                    GameUIMainMenu.BtnPlay = EditorGUILayout.ObjectField("Btn Play: ", GameUIMainMenu.BtnPlay, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIMainMenu.BtnShop = EditorGUILayout.ObjectField("BtnShop: ", GameUIMainMenu.BtnShop, typeof(Button), true) as Button;
                    GUILayout.Space(10f);

                    GameUIMainMenu.TextCoin = EditorGUILayout.ObjectField("Text Coin: ", GameUIMainMenu.TextCoin, typeof(GameObject), true) as GameObject;
                    GUILayout.Space(10f);

                    GameUIMainMenu.Logo = EditorGUILayout.ObjectField("Logo: ", GameUIMainMenu.Logo, typeof(Image), true) as Image;
                    GUILayout.Space(10f);



                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                case 4:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("Shop UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    GameUI.GameGUI.SetActive(false);
                    GameUI.PauseGUI.SetActive(false);
                    GameUI.GameOverGUI.SetActive(false);
                    GameUI.MainMenu.SetActive(false);
                    GameUI.ShopGui.SetActive(true);
                    GameUI.LoadingGui.SetActive(false);

                    GameUIShop = FindObjectOfType<A2DShopItemsManager>();
                    GameUIShopSE = new SerializedObject(GameUIShop);


                    GameUIShop.TextPriceItem = EditorGUILayout.ObjectField("Text Price Item: ", GameUIShop.TextPriceItem, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIShop.TextNameItem = EditorGUILayout.ObjectField("Text Name Item: ", GameUIShop.TextNameItem, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIShop.TextCoinAvailable = EditorGUILayout.ObjectField("Text Coin Available: ", GameUIShop.TextCoinAvailable, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUIShop.Img = EditorGUILayout.ObjectField("Img: ", GameUIShop.Img, typeof(Image), true) as Image;
                    GUILayout.Space(10f);

                    GameUIShopSE.Update();

                    SerializedProperty stringsProperty2 = GameUIShopSE.FindProperty("btnBuy");
                    EditorGUILayout.PropertyField(stringsProperty2, true);
                    GUILayout.Space(10f);

                    SerializedProperty stringsProperty3 = GameUIShopSE.FindProperty("btnSelect");
                    EditorGUILayout.PropertyField(stringsProperty3, true);
                    GUILayout.Space(10f);

                    SerializedProperty stringsProperty4 = GameUIShopSE.FindProperty("btnExit");
                    EditorGUILayout.PropertyField(stringsProperty4, true);
                    GUILayout.Space(10f);

                    SerializedProperty stringsProperty5 = GameUIShopSE.FindProperty("btnRight");
                    EditorGUILayout.PropertyField(stringsProperty5, true);
                    GUILayout.Space(10f);

                    SerializedProperty stringsProperty6 = GameUIShopSE.FindProperty("btnLeft");
                    EditorGUILayout.PropertyField(stringsProperty6, true);
                    GUILayout.Space(10f);

                    GameUIShopSE.ApplyModifiedProperties();

                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                case 5:
                    GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
                    GUILayout.Label("Loading UI", EditorStyles.boldLabel);
                    GUILayout.Space(10f);
                    GameUI.GameGUI.SetActive(false);
                    GameUI.PauseGUI.SetActive(false);
                    GameUI.GameOverGUI.SetActive(false);
                    GameUI.MainMenu.SetActive(false);
                    GameUI.ShopGui.SetActive(false);
                    GameUI.LoadingGui.SetActive(true);

                    GameUILoading = FindObjectOfType<A2DLoadingUI>();

                    GameUILoading.LoadingText = EditorGUILayout.ObjectField("Loading Text: ", GameUILoading.LoadingText, typeof(Text), true) as Text;
                    GUILayout.Space(10f);

                    GameUILoading.ScrollBar = EditorGUILayout.ObjectField("ScrollBar: ", GameUILoading.ScrollBar, typeof(Scrollbar), true) as Scrollbar;
                    GUILayout.Space(10f);


                    GUILayout.Space(10f);
                    GUILayout.EndVertical();
                    break;
                default:
                    Debug.LogError("Unrecognized Option");
                    break;
            }
            GUILayout.Space(10f);


            GUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();



    }

    void CharacterController()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
           

            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Player Settings", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameM.NumLife = EditorGUILayout.IntField("Num Life: ", GameM.NumLife);
            GUILayout.Space(10f);

            GameM.SpeedPlayer = EditorGUILayout.FloatField("Speed Player: ", GameM.SpeedPlayer);
            GUILayout.Space(10f);

            GameMSE.Update();
            SerializedProperty stringsProperty = GameMSE.FindProperty("PlayerSprite");
            EditorGUILayout.PropertyField(stringsProperty, true);
            GUILayout.Space(10f);

            EditorGUILayout.TextArea("screen movement limits", GUI.skin.GetStyle("HelpBox"));

            SerializedProperty stringsProperty2 = GameMSE.FindProperty("limits");
            EditorGUILayout.PropertyField(stringsProperty2, true);

            GameMSE.ApplyModifiedProperties();

            GUILayout.Space(10f);

            GameP.ShotOrigin = EditorGUILayout.ObjectField("Shot Origin 1: ", GameP.ShotOrigin, typeof(Transform), true) as Transform;
            GUILayout.Space(10f);

            GameP.ShotOrigin2 = EditorGUILayout.ObjectField("Shot Origin 2: ", GameP.ShotOrigin2, typeof(Transform), true) as Transform;
            GUILayout.Space(10f);

            GameP.ShotOrigin3 = EditorGUILayout.ObjectField("Shot Origin 3: ", GameP.ShotOrigin3, typeof(Transform), true) as Transform;
            GUILayout.Space(10f);

            GameP.Shield = EditorGUILayout.ObjectField("Shield: ", GameP.Shield, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);


            EditorGUILayout.TextArea("Used for shield de-dusting animations", GUI.skin.GetStyle("HelpBox"));
            GamePSE.Update();
            SerializedProperty stringsProperty3 = GamePSE.FindProperty("SpriteShields");
            EditorGUILayout.PropertyField(stringsProperty3, true);
            GamePSE.ApplyModifiedProperties();
            GUILayout.Space(10f);



            GUILayout.EndVertical();


            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();

    }

    void Background()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos2 = EditorGUILayout.BeginScrollView(scrollPos2, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);

            GUILayout.Label("System", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            EditorGUILayout.TextArea("You can Create New Funds and Assign them here, 1 is activated randomly, in this way every time you start a new game the world will be different.", GUI.skin.GetStyle("HelpBox"));
            GameBSE.Update();
            SerializedProperty stringsProperty6 = GameBSE.FindProperty("Level");
            EditorGUILayout.PropertyField(stringsProperty6, true);
            GameBSE.ApplyModifiedProperties();

            GUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();


    }

    void GameManager()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos3 = EditorGUILayout.BeginScrollView(scrollPos3, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
           
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("System", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameM.NameSceneLoad = EditorGUILayout.TextField("Name Scene To Load : ", GameM.NameSceneLoad);
            GUILayout.Space(10f);

            GameM.TextCoin = EditorGUILayout.ObjectField("Text Coin: ", GameM.TextCoin, typeof(Text), true) as Text;
            GUILayout.Space(10f);

            GameM.TextLife = EditorGUILayout.ObjectField("Text Life: ", GameM.TextLife, typeof(Text), true) as Text;
            GUILayout.Space(10f);


            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Weapon 1 Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);


            GameM.ShotDelay = EditorGUILayout.FloatField("Shot Delay Weapon 1: ", GameM.ShotDelay);
            GUILayout.Space(10f);

            GameM.LimitAmmoWeapon1 = EditorGUILayout.IntField("Limit Ammo Weapon 1: ", GameM.LimitAmmoWeapon1);
            GUILayout.Space(10f);

            GameM.AmmoWeapon1 = EditorGUILayout.IntField("Ammo Initial Weapon 1: ", GameM.AmmoWeapon1);
            GUILayout.Space(10f);

            GameM.TextWeapon1 = EditorGUILayout.ObjectField("Text Weapon 1: ", GameM.TextWeapon1, typeof(Text), true) as Text;
            GUILayout.Space(10f);

            GameM.InfoWeaponActive1 = EditorGUILayout.ObjectField("Info Weapon Active 1: ", GameM.InfoWeaponActive1, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ShotWeapon1 = EditorGUILayout.ObjectField("VFX Shot Weapon 1: ", GameM.VFX_ShotWeapon1, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_MoreWeapon1 = EditorGUILayout.ObjectField("VFX More Weapon 1: ", GameM.VFX_MoreWeapon1, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);


            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Weapon 2 Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);


            GameM.ShotDelay2 = EditorGUILayout.FloatField("Shot Delay Weapon 2: ", GameM.ShotDelay2);
            GUILayout.Space(10f);

            GameM.LimitAmmoWeapon2 = EditorGUILayout.IntField("Limit Ammo Weapon 2: ", GameM.LimitAmmoWeapon2);
            GUILayout.Space(10f);

            GameM.AmmoWeapon2 = EditorGUILayout.IntField("Ammo Initial Weapon 2: ", GameM.AmmoWeapon2);
            GUILayout.Space(10f);

            GameM.TextWeapon2 = EditorGUILayout.ObjectField("Text Weapon 2: ", GameM.TextWeapon2, typeof(Text), true) as Text;
            GUILayout.Space(10f);

            GameM.InfoWeaponActive2 = EditorGUILayout.ObjectField("Info Weapon Active 2: ", GameM.InfoWeaponActive2, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ShotWeapon2 = EditorGUILayout.ObjectField("VFX Shot Weapon 2: ", GameM.VFX_ShotWeapon2, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_MoreWeapon2 = EditorGUILayout.ObjectField("VFX More Weapon 2: ", GameM.VFX_MoreWeapon2, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);


            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Weapon 3 Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);


            GameM.ShotDelay3 = EditorGUILayout.FloatField("Shot Delay Weapon 3: ", GameM.ShotDelay3);
            GUILayout.Space(10f);

            GameM.LimitAmmoWeapon3 = EditorGUILayout.IntField("Limit Ammo Weapon 3: ", GameM.LimitAmmoWeapon3);
            GUILayout.Space(10f);

            GameM.AmmoWeapon3 = EditorGUILayout.IntField("Ammo Initial Weapon 3: ", GameM.AmmoWeapon3);
            GUILayout.Space(10f);

            GameM.TextWeapon3 = EditorGUILayout.ObjectField("Text Weapon 3: ", GameM.TextWeapon3, typeof(Text), true) as Text;
            GUILayout.Space(10f);

            GameM.InfoWeaponActive3 = EditorGUILayout.ObjectField("Info Weapon Active 3: ", GameM.InfoWeaponActive3, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ShotWeapon3 = EditorGUILayout.ObjectField("VFX Shot Weapon 3: ", GameM.VFX_ShotWeapon3, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_MoreWeapon3 = EditorGUILayout.ObjectField("VFX More Weapon 3: ", GameM.VFX_MoreWeapon3, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GUILayout.EndVertical();

            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Shield Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameM.DurationShield = EditorGUILayout.IntField("Duration Shield: ", GameM.DurationShield);
            GUILayout.Space(10f);

            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Effects", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameM.VFX_Less1Life = EditorGUILayout.ObjectField("VFX Less 1 Life: ", GameM.VFX_Less1Life, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_More1Life = EditorGUILayout.ObjectField("VFX More 1 Life: ", GameM.VFX_More1Life, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_1Coin = EditorGUILayout.ObjectField("VFX 1 Coin: ", GameM.VFX_1Coin, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_2Coin = EditorGUILayout.ObjectField("VFX 2 Coin: ", GameM.VFX_2Coin, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_5Coin = EditorGUILayout.ObjectField("VFX 5 Coin: ", GameM.VFX_5Coin, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_NoneShot = EditorGUILayout.ObjectField("VFX None Shot: ", GameM.VFX_NoneShot, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ExplosionEnemies = EditorGUILayout.ObjectField("VFX Explosion Enemies: ", GameM.VFX_ExplosionEnemies, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ExplosionPlayer = EditorGUILayout.ObjectField("VFX Explosion Player: ", GameM.VFX_ExplosionPlayer, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ShotBoos = EditorGUILayout.ObjectField("VFX Shot Boos: ", GameM.VFX_ShotBoos, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.VFX_ShotBoos = EditorGUILayout.ObjectField("VFX Shot Boos: ", GameM.VFX_ShotBoos, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.Info_NewLevel = EditorGUILayout.ObjectField("Info New Level: ", GameM.Info_NewLevel, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.Info_Empty = EditorGUILayout.ObjectField("Info Empty: ", GameM.Info_Empty, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.Info_Start = EditorGUILayout.ObjectField("Info Start: ", GameM.Info_Start, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.Info_Start = EditorGUILayout.ObjectField("Info Start: ", GameM.Info_Start, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            


            GUILayout.EndVertical();



            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();

    }

    void GeneratorItems()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos4 = EditorGUILayout.BeginScrollView(scrollPos4, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Space(5f);

            GUILayout.Label("Create New Item", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            if (GUILayout.Button("Create New Item: Coin"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemCoin")) as GameObject;
                //rename it
                ASS.name = "ItemCoin";

                Debug.Log("ItemCoin Prefabs Created!");
            }
            GUILayout.Space(10f);

            if (GUILayout.Button("Create New Item: Life"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemLife")) as GameObject;
                //rename it
                ASS.name = "ItemLife";

                Debug.Log("ItemLife Prefabs Created!");
            }
            GUILayout.Space(10f);
            if (GUILayout.Button("Create New Item: Weapon 1"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemWeapon1")) as GameObject;
                //rename it
                ASS.name = "ItemWeapon1";

                Debug.Log("ItemWeapon1 Prefabs Created!");
            }
            GUILayout.Space(10f);
            if (GUILayout.Button("Create New Item: Weapon 2"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemWeapon2")) as GameObject;
                //rename it
                ASS.name = "ItemWeapon2";

                Debug.Log("ItemWeapon2 Prefabs Created!");
            }
            GUILayout.Space(10f);
            if (GUILayout.Button("Create New Item: Weapon 3"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemWeapon3")) as GameObject;
                //rename it
                ASS.name = "ItemWeapon3";

                Debug.Log("ItemWeapon3 Prefabs Created!");
            }
            GUILayout.Space(10f);
            if (GUILayout.Button("Create New Item: Shield"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/ItemShield")) as GameObject;
                //rename it
                ASS.name = "ItemShield";

                Debug.Log("ItemShield Prefabs Created!");
            }
            GUILayout.Space(10f);



            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Items Config", EditorStyles.boldLabel);
            GUILayout.Space(10f);


            GameM.ItemCoin = EditorGUILayout.ObjectField("Item Coin: ", GameM.ItemCoin, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.ItemLife = EditorGUILayout.ObjectField("Item Life: ", GameM.ItemLife, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.ItemWeapon1 = EditorGUILayout.ObjectField("Item Weapon 1: ", GameM.ItemWeapon1, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.ItemWeapon2 = EditorGUILayout.ObjectField("Item Weapon 2: ", GameM.ItemWeapon2, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.ItemWeapon3 = EditorGUILayout.ObjectField("Item Weapon 3: ", GameM.ItemWeapon3, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GameM.ItemShield = EditorGUILayout.ObjectField("Item Shield: ", GameM.ItemShield, typeof(GameObject), true) as GameObject;
            GUILayout.Space(10f);

            GUILayout.EndVertical();



            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Item Generator", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            EditorGUILayout.TextArea("List of items to Generate", GUI.skin.GetStyle("HelpBox"));

            GameGSE.Update();
            SerializedProperty stringsProperty3 = GameGSE.FindProperty("Items");
            EditorGUILayout.PropertyField(stringsProperty3, true);
            GameGSE.ApplyModifiedProperties();

            GUILayout.EndVertical();



            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();

    }

    void EnemyGenerator()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos5 = EditorGUILayout.BeginScrollView(scrollPos5, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);

            GUILayout.Label("Create New Enemy", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            if (GUILayout.Button("Create New Enemy"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/Enemy")) as GameObject;
                //rename it
                ASS.name = "Enemy";

                Debug.Log("Enemy Prefabs Created!");
            }
            GUILayout.Space(10f);

            if (GUILayout.Button("Create New Boos"))
            {
                //instantiate ui canvas
                GameObject ASS = Instantiate(Resources.Load("Game/BoosEnemy")) as GameObject;
                //rename it
                ASS.name = "BoosEnemy";

                Debug.Log("BoosEnemy Prefabs Created!");
            }
            GUILayout.Space(10f);

            GUILayout.EndVertical();


            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
            GUILayout.Label("Enemy Generator", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            EditorGUILayout.TextArea("List of Enemy to Generate", GUI.skin.GetStyle("HelpBox"));

            GameGSE.Update();
            SerializedProperty stringsProperty4 = GameGSE.FindProperty("NPC");
            EditorGUILayout.PropertyField(stringsProperty4, true);
            GameGSE.ApplyModifiedProperties();


            GUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to  the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();


    }

    void SoundManager()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
        if (GameM)
        {
            scrollPos6 = EditorGUILayout.BeginScrollView(scrollPos6, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);

            GUILayout.Label("Audio Manager", EditorStyles.boldLabel);
            GUILayout.Space(10f);

            GameMusiSE.Update();
            SerializedProperty stringsProperty = GameMusiSE.FindProperty("GameMusic");
            EditorGUILayout.PropertyField(stringsProperty, true);
            GameMusiSE.ApplyModifiedProperties();

            GUILayout.Space(10f);

            GameS.Button = EditorGUILayout.ObjectField("Button: ", GameS.Button, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.Shot_Enemy = EditorGUILayout.ObjectField("Shot_Enemy: ", GameS.Shot_Enemy, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.Sound_Items = EditorGUILayout.ObjectField("Sound_Items: ", GameS.Sound_Items, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.laserPlayer = EditorGUILayout.ObjectField("laserPlayer: ", GameS.laserPlayer, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.laserEnemy = EditorGUILayout.ObjectField("laserEnemy: ", GameS.laserEnemy, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.Explosion_Enemy = EditorGUILayout.ObjectField("Explosion Enemy: ", GameS.Explosion_Enemy, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.Explosion_Player = EditorGUILayout.ObjectField("Explosion Player: ", GameS.Explosion_Player, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.Explosion_Asteroid = EditorGUILayout.ObjectField("Explosion Asteroid: ", GameS.Explosion_Asteroid, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);

            GameS.SoundBoos = EditorGUILayout.ObjectField("Sound Boos: ", GameS.SoundBoos, typeof(AudioClip), true) as AudioClip;
            GUILayout.Space(10f);


            GUILayout.EndVertical();
            EditorGUILayout.EndScrollView();

        }
        else
        {
            EditorGUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));
            GUILayout.Space(10f);
            EditorGUILayout.TextArea("ATTENTION: No 2D Airplane Engine Detected", GUI.skin.GetStyle("HelpBox"));

            GUILayout.Space(10f);

            EditorGUILayout.TextArea("ATTENTION: For Better Performance go to the folder ´Infinite Airplane Shooter Engine 2D / Resources / Scene /´ Duplicate the Game scene and edit it.", GUI.skin.GetStyle("HelpBox"));
            FindElements();

            EditorGUILayout.EndVertical();

        }
        GUILayout.Space(10f);
        GUILayout.EndVertical();

    }

    void Contact()
    {
        GUILayout.BeginVertical("GroupBox", GUILayout.ExpandWidth(true));


        EditorGUILayout.TextArea("Thanks For Choosing 3D Infinite Runner Engine, Currently Still In Development We do not stop until we create a quality product, if you have problems write to us at denvzla@gmail.com", GUI.skin.GetStyle("HelpBox"));

        GUILayout.EndVertical();


    }


}
