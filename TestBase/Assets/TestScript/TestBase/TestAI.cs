using ClientServerCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    //public  actionType;
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
            else if (configType == typeof(ActionConfig))
            {
                return new FileLoaderFromTextAsset(TestAI.Inst.actionCfgFile);
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
    public TextAsset actionCfgFile;
    private string[] avatarNameStrs = null;
    private int[] avatarIds = null;


    ETCJoystick leftJoystick;
    ETCButton skillButton;
    void Initialize()
    {
        SysModuleManager.Instance.Initialize(this.gameObject);
        SysModuleManager.Instance.AddSysModule<ResourceManager>(true);
    }

    void Awake()
    {
        Initialize();


        GameObject touchControl = GameObject.Find("EasyTouchControlsCanvas");
        leftJoystick = touchControl.transform.Find("LeftJoyStick").GetComponent<ETCJoystick>();
        skillButton = touchControl.transform.Find("SkillButton").GetComponent<ETCButton>();

        leftJoystick.cameraLookAt = null;
        //Camera camera = Camera.main.GetComponent<Camera>();
        //camera.follow = transform;

        leftJoystick.onMove.AddListener(OnMove);
        leftJoystick.onMoveEnd.AddListener(OnMoveEnd);

        skillButton.onUp.AddListener(OnSkill);
    }


    public void OnMove(Vector2 vec)
    {

        //transform.Translate(new Vector3(vec.x, 0, vec.y));
        role.Avatar.CachedTransform.forward = (new Vector3(vec.x, 0, vec.y));

        Vector3 vec3 = new Vector3(vec.x, 0, vec.y);
        vec3.Normalize();

        Vector3 targetPosition = role.Avatar.CachedTransform.localPosition + new Vector3(vec.x * 10, 0, vec.y * 10);
        //role.Avatar.gameObject.transform.localRotation =   Quaternion.Euler(new Vector3(vec.x,0, vec.y));
        role.PlayActionByType(AvatarAction._Type.Run);
        role.MoveTo(targetPosition, moveSpeed);
    }

    public void OnMoveEnd()
    {
        Debug.Log("onMoveEnd");
        role.StopMove();
    }

    public void OnSkill()
    {
        Debug.Log("OnSkill");
    }

    // Use this for initialization
    void Start()
    {

        InitializeLoadConfig();
        InitializeAvatarNameStrs();

        LoadAvatar(avatarIds[10]);


        if (role)
        {
            //role.Avatar.PlayAnim("Run_nv");
            //actionTy
            role.PlayActionByType(AvatarAction._Type.CombatIdle);
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
