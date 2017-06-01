using ClientServerCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    static class ConfigDelayLoader
    {
        public static IFileLoader DelayLoadConfig(System.Type configType, out string fileName, out int fileFormat)
        {
            fileName = "";
            fileFormat = Configuration._FileFormat.Xml;

            if (configType == typeof(AvatarConfig))
            {
                return new FileLoaderFromTextAsset(TestAI.Inst.avatarCfgFile);
            }
            else if (configType == typeof(AnimationConfig))
            {
                return new FileLoaderFromTextAsset(TestAI.Inst.animationCfgFile);

            }
            else if (configType == typeof(AssetDescConfig))
            {
                return new FileLoaderFromTextAsset(TestAI.Inst.assetdescCfgFile);

            }
            else if (configType == typeof(AvatarAssetConfig))
            {
                return new FileLoaderFromTextAsset(TestAI.Inst.avatarAssetCfgFile);
            }

            else
                return null;
        }
    }

    private void InitializeLoadConfig()
    {
        // Load config
        ConfigDatabase.Initialize(new MathParserFactory(), false, false);
        ConfigDatabase.DelayLoadFileDel = TestAI.ConfigDelayLoader.DelayLoadConfig;
    }
    private GameObject gameObj;

    public TextAsset avatarCfgFile;
    public TextAsset assetdescCfgFile;
    public TextAsset animationCfgFile;
    public TextAsset avatarAssetCfgFile;
    private string[] avatarNameStrs = null;
    private int[] avatarIds = null;

    void Initialize()
    {
        SysModuleManager.Instance.Initialize(this.gameObject);
        SysModuleManager.Instance.AddSysModule<ResourceManager>(true);

    }

    void Awake()
    {
        Initialize();
    }
    // Use this for initialization
    void Start()
    {

        InitializeLoadConfig();
        InitializeAvatarNameStrs();

        LoadAvatar(avatarIds[10]);


        if (role)
        {
            role.Avatar.PlayAnim("Run_nv");
        }
    }

    private void InitializeAvatarNameStrs()
    {
        //ConfigDatabase.DelayLoadFileDelegate delayLoadFileDel = ConfigDelayLoader.DelayLoadConfig;
        //string str = "";
        //int fileFormat = 0;
        //IFileLoader fileLoader = delayLoadFileDel(typeof(AvatarConfig), out str, out fileFormat);
        //AvatarConfig config1 = ConfigDatabase.LoadConfig<AvatarConfig>(ConfigDatabase.DefaultCfg, fileLoader, fileFormat, str);
        //config1.GetType();


        AvatarConfig aconfig = ConfigDatabase.DefaultCfg.AvatarConfig;
        avatarNameStrs = new string[ConfigDatabase.DefaultCfg.AvatarConfig.avatars.Count];
        avatarIds = new int[ConfigDatabase.DefaultCfg.AvatarConfig.avatars.Count];
        for (int i = 0; i < ConfigDatabase.DefaultCfg.AvatarConfig.avatars.Count; i++)
        {
            AvatarConfig.Avatar avatarCfg = ConfigDatabase.DefaultCfg.AvatarConfig.avatars[i];

            string name = ItemInfoUtility.GetAssetName(avatarCfg.id);
            avatarIds[i] = avatarCfg.id;
            avatarNameStrs[i] = name;
        }
    }
    private BattleRole role = null;
    void LoadAvatar(int avatarResourceId)
    {
        if (role != null)
            MonoBehaviour.Destroy(role.gameObject);

        AvatarConfig.Avatar avatarCfg = ConfigDatabase.DefaultCfg.AvatarConfig.GetAvatarById(avatarResourceId);
        if (avatarCfg == null)
            Debug.LogError(string.Format("Miss Avatar Setting : Id({0:X})", avatarResourceId));

        Avatar avatar = Avatar.CreateAvatar(0x00000000);

        role = avatar.gameObject.AddComponent<BattleRole>();
        WeihuaGames.ClientClass.CombatAvatarData avatarData = new WeihuaGames.ClientClass.CombatAvatarData();
        avatarData.ResourceId = avatarResourceId;

        role.AvatarData = avatarData;
        role.Awake();
        role.AvatarAssetId = avatarCfg.breakThroughs[0].assetId;
        role.Avatar.Load(avatarCfg.breakThroughs[0].assetId, true, false);

        role.UseDefaultWeapons();
    }



    static TestAI inst;
    public static TestAI Inst
    {
        get
        {
            if (inst == null)
                //Unity4.1.2不支持该泛型函数，美工取项目时无法编译
                //inst = GameObject.FindObjectOfType<AvatarViewer>();
                inst = GameObject.FindObjectOfType(typeof(TestAI)) as TestAI;
            return inst;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
