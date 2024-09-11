using System.Collections;
using System.Collections.Generic;
using Es.InkPainter;
using Es.InkPainter.Sample;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class AvatarEditorMenu : MonoBehaviour
{
    
     private AudioSource _audioSource;
    private MousePainter mousePainter;
    
    private UIDocument _document;
    private Button _buttonAnimationControl;
    private Button _buttonColorPicker;
    private Button _buttonPartCreator;
    private Button _buttonHair;
    private Button _buttonAccessories;
    private Button _buttonWings;
    private Button _buttonPet;
    private Button _buttonCloths;
    private Button _buttonScalepart;
    private Button _buttonBody;
    private Button _buttonColor;
    private Button _buttonTexture;
    private VisualElement _tabPartCreator;
    private VisualElement _tabAnimationControl;
    private VisualElement _tabColorPicker;
    private VisualElement _tabColor;
    private VisualElement _tabTexture;
    private VisualElement _hairPanel;
    private VisualElement _accessoriesPanel;
    private VisualElement _wingsPanel;
    private VisualElement _petPanel;
    private VisualElement _clothsPanel;
    private VisualElement _scalepartPanel;
    private VisualElement _bodyPanel;


    private VisualElement _btnSibil1;
    private VisualElement _btnSibil2;
    private VisualElement _btnSibil3;
    private VisualElement _btnabro;
    private VisualElement _btnmo1;
    private VisualElement _btnmo2;

    private VisualElement _btnCrown;
    private VisualElement _btnPoliceCap;
    private VisualElement _btnPillboxHat;
    private VisualElement _btnSantaHat;
    private VisualElement _btnCowboyHat;
    private VisualElement _btnMinerHat;
    private VisualElement _btnVikingHelmet;
    private VisualElement _btnShowerCap;
    private VisualElement _btnPajamaHat;
    private VisualElement _btnMagicianHat;
    private VisualElement _btnglass1;
    private VisualElement _btnglass2;
    private VisualElement _btnasa;


    private VisualElement _btnwings1;
    private VisualElement _btnwings2;

    private VisualElement _btnshirt1;
    private VisualElement _btnshirt2;
    private VisualElement _btnpant;
    private VisualElement _btnshoes;
    private VisualElement _btnshort;
    private VisualElement _btnsnow;
    


    // mahta: bara har game obj yedune is ina ezafe kon
    //Hair
    public GameObject sibil1;
    public GameObject sibil2;
    public GameObject sibil3;
    public GameObject abro;
    public GameObject mo1;
    public GameObject mo2;

    //tab accessorries
    public GameObject taj;
    public GameObject kolahpolice;
    public GameObject kolahpalangi;
    public GameObject kolahsanta;
    public GameObject kolahcow;
    public GameObject kolahminer;
    public GameObject kolahviking;
    public GameObject kolahshower;
    public GameObject kolahkhab;
    public GameObject kolahmagic;
    public GameObject eynak1;
    public GameObject eynak2;

    public GameObject abnabat;

    //wings
    public GameObject par1;

    public GameObject par2;

    //clothes
    public GameObject tshirt1;
    public GameObject tshirt2;
    public GameObject shalvar1;
    public GameObject shalvar2;
    public GameObject kafsh1;
    public GameObject barf;


    private Button _btnDefaultColor;
    private Button _btnLightColor;
    private Button _btnDarkColor;

    private string _selectedColor = null;

    private VisualElement _headColor;
    private VisualElement _leftHanColor;
    private VisualElement _rightHandColor;
    private VisualElement _bodyColor;
    private VisualElement _leftFootColor;
    private VisualElement _rightFootColor;
    
    
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject Hands;
    [SerializeField] public GameObject Body;
    [SerializeField] public GameObject Feet;

    
    
    
    private Animator animator;
    
    
    
    private InkCanvas inkCanvasHead;
    private InkCanvas inkCanvasBody;
    private InkCanvas inkCanvasFeet;
    private InkCanvas inkCanvasHands;



    private Toggle toggleColor;
    private Toggle toggleErase;

    public ColorPicker colorPicker;
    

    public List<GameObject> GetAllGameObjects()
    {
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.Add(sibil1);
        gameObjects.Add(sibil2);
        gameObjects.Add(sibil3);
        gameObjects.Add(mo1);
        gameObjects.Add(mo2);
        gameObjects.Add(taj);
        gameObjects.Add(kolahpolice);
        gameObjects.Add(kolahpalangi);
        gameObjects.Add(kolahsanta);
        gameObjects.Add(kolahcow);
        gameObjects.Add(kolahminer);
        gameObjects.Add(kolahviking);
        gameObjects.Add(kolahshower);
        gameObjects.Add(kolahkhab);
        gameObjects.Add(kolahmagic);
        gameObjects.Add(eynak1);
        gameObjects.Add(eynak2);
        gameObjects.Add(abnabat);
        gameObjects.Add(par1);
        gameObjects.Add(par2);
        gameObjects.Add(tshirt1);
        gameObjects.Add(tshirt2);
        gameObjects.Add(shalvar1);
        gameObjects.Add(shalvar2);
        gameObjects.Add(kafsh1);
        gameObjects.Add(barf);
        gameObjects.Add(abro);

        return gameObjects;
    }
    private List<Button> _menuButtons;

    private void Awake()
    {
        
        #region findings
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _buttonPartCreator = _document.rootVisualElement.Q<Button>("PartCreator_Btn")as Button;
        _buttonAnimationControl = _document.rootVisualElement.Q<Button>("AnimationControl_Btn")as Button;
        _buttonColorPicker = _document.rootVisualElement.Q<Button>("ColorPicker_Btn")as Button;


        // PartCreator_Btn
        _buttonHair = _document.rootVisualElement.Q<Button>("Hair_Btn")as Button;
        _buttonAccessories = _document.rootVisualElement.Q<Button>("Accessories_Btn")as Button;
        _buttonWings = _document.rootVisualElement.Q<Button>("Wings_Btn")as Button;
        _buttonPet = _document.rootVisualElement.Q<Button>("Pet_Btn")as Button;
        _buttonCloths = _document.rootVisualElement.Q<Button>("Cloths_Btn")as Button;


        // AnimationControl_Btn
        _buttonScalepart = _document.rootVisualElement.Q<Button>("Scalepart_Btn")as Button;
        _buttonBody = _document.rootVisualElement.Q<Button>("Body_Btn")as Button;


        // ColorPicker_Btn
        _tabColorPicker = _document.rootVisualElement.Q<VisualElement>("ColorPicker_tab");
        _tabColor = _document.rootVisualElement.Q<VisualElement>("Color_tab");
        _tabTexture = _document.rootVisualElement.Q<VisualElement>("Texture_tab");
        _buttonColor = _document.rootVisualElement.Q<Button>("Color_Btn")as Button;
        _buttonTexture = _document.rootVisualElement.Q<Button>("Texture_Btn");
        


        _tabPartCreator = _document.rootVisualElement.Q<VisualElement>("PartCreator_tab");
        _tabAnimationControl = _document.rootVisualElement.Q<VisualElement>("AnimationControl_tab");


        _hairPanel = _document.rootVisualElement.Q<VisualElement>("Hair_tab");
        _accessoriesPanel = _document.rootVisualElement.Q<VisualElement>("Accessories_tab");
        _wingsPanel = _document.rootVisualElement.Q<VisualElement>("Wings_tab");
        _petPanel = _document.rootVisualElement.Q<VisualElement>("Pet_tab");
        _clothsPanel = _document.rootVisualElement.Q<VisualElement>("Cloths_tab");


        _scalepartPanel = _document.rootVisualElement.Q<VisualElement>("Scalepart_tab");
        _bodyPanel = _document.rootVisualElement.Q<VisualElement>("Body_tab");
        
        

        // mahta: bara har kodum yedune is ina ezafe kon
        _btnSibil1 = _document.rootVisualElement.Q<VisualElement>("btnSibil1");
        _btnSibil2 = _document.rootVisualElement.Q<VisualElement>("btnSibil2");
        _btnSibil3 = _document.rootVisualElement.Q<VisualElement>("btnSibil3");
        _btnabro = _document.rootVisualElement.Q<VisualElement>("btnabro");
        _btnmo1 = _document.rootVisualElement.Q<VisualElement>("btnmo1");
        _btnmo2 = _document.rootVisualElement.Q<VisualElement>("btnmo2");
        // accesories
        _btnCrown = _document.rootVisualElement.Q<VisualElement>("btnCrown");
        _btnPoliceCap = _document.rootVisualElement.Q<VisualElement>("btnPoliceCap");
        _btnPillboxHat = _document.rootVisualElement.Q<VisualElement>("btnPillboxHat");
        _btnSantaHat = _document.rootVisualElement.Q<VisualElement>("btnSantaHat");
        _btnCowboyHat = _document.rootVisualElement.Q<VisualElement>("btnCowboyHat");
        _btnPajamaHat = _document.rootVisualElement.Q<VisualElement>("btnPajamaHat");
        _btnMinerHat = _document.rootVisualElement.Q<VisualElement>("btnMinerHat");
        _btnMagicianHat = _document.rootVisualElement.Q<VisualElement>("btnMagicianHat");
        _btnVikingHelmet = _document.rootVisualElement.Q<VisualElement>("btnVikingHelmet");
        _btnShowerCap = _document.rootVisualElement.Q<VisualElement>("btnShowerCap");
        _btnglass1 = _document.rootVisualElement.Q<VisualElement>("btnglass1");
        _btnglass2 = _document.rootVisualElement.Q<VisualElement>("btnglass2");
        _btnasa = _document.rootVisualElement.Q<VisualElement>("btnasa");
        //wings
        _btnwings1 = _document.rootVisualElement.Q<VisualElement>("btnwings1");
        _btnwings2 = _document.rootVisualElement.Q<VisualElement>("btnwings2");
        //clothes
        _btnshirt1 = _document.rootVisualElement.Q<VisualElement>("btnshirt1");
        _btnshirt2 = _document.rootVisualElement.Q<VisualElement>("btnshirt2");
        _btnpant = _document.rootVisualElement.Q<VisualElement>("btnpant");
        _btnshort = _document.rootVisualElement.Q<VisualElement>("btnshort");
        _btnshoes = _document.rootVisualElement.Q<VisualElement>("btnshoes");
        _btnsnow = _document.rootVisualElement.Q<VisualElement>("btnsnow");

        
        
        animator = GetComponent<Animator>();
        
        
        
        #endregion


        #region Callbacks

        // Register callbacks for each button
        _buttonAnimationControl.RegisterCallback<ClickEvent>(AnimationControlClick);
        _buttonColorPicker.RegisterCallback<ClickEvent>(ColorPickerClick);
        _buttonPartCreator.RegisterCallback<ClickEvent>(PartCreatorClick);
        _buttonHair.RegisterCallback<ClickEvent>(HairClick);
        _buttonAccessories.RegisterCallback<ClickEvent>(AccessoriesClick);
        _buttonWings.RegisterCallback<ClickEvent>(WingsClick);
        _buttonPet.RegisterCallback<ClickEvent>(PetClick);
        _buttonCloths.RegisterCallback<ClickEvent>(ClothsClick);
        _buttonScalepart.RegisterCallback<ClickEvent>(ScalepartClick);
        _buttonBody.RegisterCallback<ClickEvent>(BodyClick);
        _buttonColor.RegisterCallback<ClickEvent>(TabColorClick);
        _buttonTexture.RegisterCallback<ClickEvent>(TabTextureClick);


        // mahta: bara har kodum yedune is ina ezafe kon
        _btnSibil1.RegisterCallback<ClickEvent>(OnbtnSibil1Click);
        _btnSibil2.RegisterCallback<ClickEvent>(OnbtnSibil2Click);

        _btnSibil3.RegisterCallback<ClickEvent>(OnbtnSibil3Click);
        _btnabro.RegisterCallback<ClickEvent>(OnbtnabroClick);

        _btnmo1.RegisterCallback<ClickEvent>(Onbtnmo1Click);
        _btnmo2.RegisterCallback<ClickEvent>(Onbtnmo2Click);

        _btnCrown.RegisterCallback<ClickEvent>(OnbtnCrownClick);
        _btnPoliceCap.RegisterCallback<ClickEvent>(OnbtnPoliceCapClick);
        _btnPillboxHat.RegisterCallback<ClickEvent>(OnbtnPillboxHatClick);
        _btnSantaHat.RegisterCallback<ClickEvent>(OnbtnSantaHatClick);
        _btnCowboyHat.RegisterCallback<ClickEvent>(OnbtnCowboyHatClick);
        _btnPajamaHat.RegisterCallback<ClickEvent>(OnbtnPajamaHatClick);
        _btnMinerHat.RegisterCallback<ClickEvent>(OnbtnMinerHatClick);
        _btnMagicianHat.RegisterCallback<ClickEvent>(OnbtnMagicianHatClick);
        _btnVikingHelmet.RegisterCallback<ClickEvent>(OnbtnVikingHelmetClick);
        _btnShowerCap.RegisterCallback<ClickEvent>(OnbtnShowerCapClick);
        _btnglass1.RegisterCallback<ClickEvent>(Onbtnglass1Click);
        _btnglass2.RegisterCallback<ClickEvent>(Onbtnglass2Click);
        _btnasa.RegisterCallback<ClickEvent>(OnbtnasaClick);

        _btnwings1.RegisterCallback<ClickEvent>(Onbtnwings1Click);
        _btnwings2.RegisterCallback<ClickEvent>(Onbtnwings2Click);

        _btnshirt1.RegisterCallback<ClickEvent>(Onbtnshirt1Click);
        _btnshirt2.RegisterCallback<ClickEvent>(Onbtnshirt2Click);
        _btnpant.RegisterCallback<ClickEvent>(OnbtnpantClick);
        _btnshort.RegisterCallback<ClickEvent>(OnbtnshortClick);

        _btnshort.RegisterCallback<ClickEvent>(OnbtnshortClick);

        _btnshoes.RegisterCallback<ClickEvent>(OnbtnshoesClick);
        _btnsnow.RegisterCallback<ClickEvent>(OnbtnsnowClick);

        #endregion


        _btnDefaultColor = _document.rootVisualElement.Q<Button>("btnDefaultColor")as Button;
        _btnLightColor = _document.rootVisualElement.Q<Button>("btnLightColor")as Button;
        _btnDarkColor = _document.rootVisualElement.Q<Button>("btnDarkColor")as Button;

        _btnDefaultColor.RegisterCallback((ClickEvent evt) => { _selectedColor = null; });
        _btnLightColor.RegisterCallback((ClickEvent evt) => { _selectedColor = "7D5237"; });
        _btnDarkColor.RegisterCallback((ClickEvent evt) => { _selectedColor = "351908"; });


        _headColor = _document.rootVisualElement.Q<VisualElement>("HeadColor");
        _leftHanColor = _document.rootVisualElement.Q<VisualElement>("LeftHandColor");
        _rightHandColor = _document.rootVisualElement.Q<VisualElement>("RightHandColor");
        _bodyColor = _document.rootVisualElement.Q<VisualElement>("BodyColor");
        _leftFootColor = _document.rootVisualElement.Q<VisualElement>("LeftFootColor");
        _rightFootColor = _document.rootVisualElement.Q<VisualElement>("RightFootColor");
        
        _headColor.RegisterCallback<ClickEvent>(ev => changeColor(Head, _selectedColor));
        _leftHanColor.RegisterCallback<ClickEvent>(ev => changeColor(Hands, _selectedColor));
        _rightHandColor.RegisterCallback<ClickEvent>(ev => changeColor(Hands, _selectedColor));
        _bodyColor.RegisterCallback<ClickEvent>(ev => changeColor(Body, _selectedColor));
        _leftFootColor.RegisterCallback<ClickEvent>(ev => changeColor(Feet, _selectedColor));
        _rightFootColor.RegisterCallback<ClickEvent>(ev => changeColor(Feet, _selectedColor));
        
        
        inkCanvasHead = Head.GetComponent<InkCanvas>();
        inkCanvasBody = Body.GetComponent<InkCanvas>();
        inkCanvasFeet = Feet.GetComponent<InkCanvas>();
        inkCanvasHands = Hands.GetComponent<InkCanvas>();
        
        
        
        mousePainter = Camera.main.GetComponent<MousePainter>();
        
        toggleErase = _document.rootVisualElement.Q<Toggle>("toggleErase");
        toggleColor = _document.rootVisualElement.Q<Toggle>("toggleColor");
        
        colorPicker = GetComponent<ColorPicker>();
        
        colorPicker.OnColorChanged += HandleColorChanged;
        
        toggleColor.RegisterValueChangedCallback(evt =>
        {
            if (toggleColor.value)
            {
                mousePainter.TogglePainting(true);
                toggleErase.value = false;
            }
            else
            {
                mousePainter.TogglePainting(false);
            }
        });
        
        toggleErase.RegisterValueChangedCallback(evt =>
        {
            if (toggleErase.value)
            {
                mousePainter.ToggleErasing(true);
                toggleColor.value = false;
            }
            else
            {
                mousePainter.ToggleErasing(false);
            }
        });
        
        
        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
         }

        
        
    }
    
    private void HandleColorChanged(Color newColor)
    {
        // Update the brush color in MousePainter when color changes
        if (mousePainter != null)
        {
            mousePainter.SetBrushColor(newColor);
        }
    }
    
    private void changeColor(GameObject targetObject, string hexColor)
    {
        if (hexColor == null)
        {
            var renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.white;
            } 
        }
        else
        {
            if (ColorUtility.TryParseHtmlString($"#{hexColor}", out Color newColor))
            {
                var renderer = targetObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = newColor;
                }
                else
                {
                    Debug.LogWarning("The target object does not have a Renderer component.");
                }
            }
            else
            {
                Debug.LogWarning("Invalid color code.");
            }
        }
        
    }

    public void ResetAvatar()
    {
        sibil1.SetActive(false);
        sibil2.SetActive(false);
        sibil3.SetActive(false);
        mo1.SetActive(false);
        mo2.SetActive(false);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
        eynak1.SetActive(false);
        eynak2.SetActive(false);
        abnabat.SetActive(false);
        par1.SetActive(false);
        par2.SetActive(false);
        tshirt1.SetActive(false);
        tshirt2.SetActive(false);
        shalvar1.SetActive(false);
        shalvar2.SetActive(false);
        kafsh1.SetActive(false);
        barf.SetActive(false);
        abro.SetActive(false);


        changeColor(Head, null);
        changeColor(Body, null);
        changeColor(Feet, null);
        changeColor(Hands, null);
        
        inkCanvasHead.ResetPaint();
        inkCanvasBody.ResetPaint();
        inkCanvasFeet.ResetPaint();
        inkCanvasHands.ResetPaint();

    }

    // hair
    //mahta: bara har kodum yedune is ina ezafe kon
    public void OnbtnSibil1Click(ClickEvent evt)
    {
        // mahta: esmashono taghieer bede
        PlayButtonSound();
        sibil2.SetActive(!sibil2.activeSelf);
        sibil1.SetActive(false);
        sibil3.SetActive(false);
    }

    public void OnbtnSibil2Click(ClickEvent evt)
    {
        PlayButtonSound();
        sibil1.SetActive(!sibil1.activeSelf);
        sibil2.SetActive(false);
        sibil3.SetActive(false);
    }
    public void OnbtnSibil3Click(ClickEvent evt)
    {
        PlayButtonSound();
        sibil3.SetActive(!sibil3.activeSelf);
        sibil2.SetActive(false);
        sibil1.SetActive(false);
    }
    public void OnbtnabroClick(ClickEvent evt)
        {
            PlayButtonSound();
            abro.SetActive(!abro.activeSelf);
         
        }
    public void Onbtnmo1Click(ClickEvent evt)
    {
        PlayButtonSound();
        mo1.SetActive(!mo1.activeSelf);
        mo2.SetActive(false);
    }

    public void Onbtnmo2Click(ClickEvent evt)
    {
        PlayButtonSound();
        mo2.SetActive(!mo2.activeSelf);
        mo1.SetActive(false);
    }

    //accsseoties
    public void OnbtnCrownClick(ClickEvent evt)
    {
        PlayButtonSound();
        taj.SetActive(!taj.activeSelf);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnPoliceCapClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahpolice.SetActive(!kolahpolice.activeSelf);
        taj.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnPillboxHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahpalangi.SetActive(!kolahpalangi.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnSantaHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahsanta.SetActive(!kolahsanta.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnCowboyHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahcow.SetActive(!kolahcow.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnPajamaHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahkhab.SetActive(!kolahkhab.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnMinerHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahminer.SetActive(!kolahminer.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnMagicianHatClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahmagic.SetActive(!kolahmagic.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahviking.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnVikingHelmetClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahviking.SetActive(!kolahviking.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahshower.SetActive(false);
    }

    public void OnbtnShowerCapClick(ClickEvent evt)
    {
        PlayButtonSound();
        kolahshower.SetActive(!kolahshower.activeSelf);
        taj.SetActive(false);
        kolahpolice.SetActive(false);
        kolahpalangi.SetActive(false);
        kolahsanta.SetActive(false);
        kolahcow.SetActive(false);
        kolahkhab.SetActive(false);
        kolahminer.SetActive(false);
        kolahmagic.SetActive(false);
        kolahviking.SetActive(false);
    }

    public void Onbtnglass1Click(ClickEvent evt)
    {
        PlayButtonSound();
        eynak1.SetActive(!eynak1.activeSelf);
        eynak2.SetActive(false);
    }

    public void Onbtnglass2Click(ClickEvent evt)
    {
        PlayButtonSound();
        eynak2.SetActive(!eynak2.activeSelf);
        eynak1.SetActive(false);
    }

    public void OnbtnasaClick(ClickEvent evt)
    {
        PlayButtonSound();
        abnabat.SetActive(!abnabat.activeSelf);
    }

    //wings
    public void Onbtnwings1Click(ClickEvent evt)
    {
        PlayButtonSound();
        par1.SetActive(!par1.activeSelf);
        par2.SetActive(false);
    }

    public void Onbtnwings2Click(ClickEvent evt)
    {
        PlayButtonSound();
        par2.SetActive(!par2.activeSelf);
        par1.SetActive(false);
    }

    //clothes
    public void Onbtnshirt1Click(ClickEvent evt)
    {
        PlayButtonSound();
        tshirt1.SetActive(!tshirt1.activeSelf);
        tshirt2.SetActive(false);
    }

    public void Onbtnshirt2Click(ClickEvent evt)
    {
        PlayButtonSound();
        tshirt2.SetActive(!tshirt2.activeSelf);
        tshirt1.SetActive(false);
    }

    public void OnbtnpantClick(ClickEvent evt)
    {
        PlayButtonSound();
        shalvar1.SetActive(!shalvar1.activeSelf);
        shalvar2.SetActive(false);
    }
     public void OnbtnshortClick(ClickEvent evt)
    {
        PlayButtonSound();
        shalvar2.SetActive(!shalvar2.activeSelf);
        shalvar1.SetActive(false);
    }

    public void OnbtnshoesClick(ClickEvent evt)
    {
        PlayButtonSound();
        kafsh1.SetActive(!kafsh1.activeSelf);
    }

    public void OnbtnsnowClick(ClickEvent evt)
    {
        PlayButtonSound();
        barf.SetActive(!barf.activeSelf);
    }


    private void AnimationControlClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Animation Control button clicked");
        // Display Animation Control tab and hide others
        if (_tabAnimationControl.style.display == DisplayStyle.Flex)
        {
            _tabAnimationControl.style.display = DisplayStyle.None;
        }
        else
        {
            _tabAnimationControl.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void ColorPickerClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Color Picker button clicked");
        // Display Color Picker tab and hide others
        if (_tabColorPicker.style.display == DisplayStyle.Flex)
        {
            _tabColorPicker.style.display = DisplayStyle.None;
        }
        else
        {
            _tabColorPicker.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabPartCreator.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void PartCreatorClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Part Creator button clicked");
        // Display Part Creator tab and hide others
        if (_tabPartCreator.style.display == DisplayStyle.Flex)
        {
            _tabPartCreator.style.display = DisplayStyle.None;
        }
        else
        {
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void HairClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Hair button clicked");
        // Display Hair tab and hide others
        if (_hairPanel.style.display == DisplayStyle.Flex)
        {
            _hairPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _hairPanel.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void AccessoriesClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Accessories button clicked");
        // Display Accessories tab and hide others
        if (_accessoriesPanel.style.display == DisplayStyle.Flex)
        {
            _accessoriesPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _accessoriesPanel.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void WingsClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Wings button clicked");
        // Display Wings tab and hide others
        if (_wingsPanel.style.display == DisplayStyle.Flex)
        {
            _wingsPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _wingsPanel.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void PetClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Pet button clicked");
        // Display Pet tab and hide others
        if (_petPanel.style.display == DisplayStyle.Flex)
        {
            _petPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _petPanel.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void ClothsClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Cloths button clicked");
        // Display Cloths tab and hide others
        if (_clothsPanel.style.display == DisplayStyle.Flex)
        {
            _clothsPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _clothsPanel.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void ScalepartClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Scalepart button clicked");
        // Display Scalepart tab and hide others
        if (_scalepartPanel.style.display == DisplayStyle.Flex)
        {
            _scalepartPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _scalepartPanel.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void BodyClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("Body button clicked");
        // Display Body tab and hide others
        if (_bodyPanel.style.display == DisplayStyle.Flex)
        {
            _bodyPanel.style.display = DisplayStyle.None;
        }
        else
        {
            _bodyPanel.style.display = DisplayStyle.Flex;
            _tabAnimationControl.style.display = DisplayStyle.Flex;
            _tabPartCreator.style.display = DisplayStyle.None;
            _tabColorPicker.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _tabColor.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void TabTextureClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("color button clicked");
        // Display Body tab and hide others
        if (_tabTexture.style.display == DisplayStyle.Flex)
        {
            _tabTexture.style.display = DisplayStyle.None;
        }
        else
        {
            
            _tabColorPicker.style.display = DisplayStyle.Flex;
            _tabTexture.style.display = DisplayStyle.Flex;
            _tabColor.style.display = DisplayStyle.None;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabPartCreator.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
        }
    }
    
    private void TabColorClick(ClickEvent evt)
    {
        PlayButtonSound();
        Debug.Log("color button clicked");
        // Display Body tab and hide others
        if (_tabColor.style.display == DisplayStyle.Flex)
        {
            _tabColor.style.display = DisplayStyle.None;
        }
        else
        {
            _tabColorPicker.style.display = DisplayStyle.Flex;
            _tabColor.style.display = DisplayStyle.Flex;
            _bodyPanel.style.display = DisplayStyle.None;
            _tabAnimationControl.style.display = DisplayStyle.None;
            _tabPartCreator.style.display = DisplayStyle.None;
            _hairPanel.style.display = DisplayStyle.None;
            _accessoriesPanel.style.display = DisplayStyle.None;
            _wingsPanel.style.display = DisplayStyle.None;
            _petPanel.style.display = DisplayStyle.None;
            _clothsPanel.style.display = DisplayStyle.None;
            _scalepartPanel.style.display = DisplayStyle.None;
            _tabTexture.style.display = DisplayStyle.None;
        }
    }

    private void OnDisable()
    {
        // Unregister callbacks for each button
        _buttonAnimationControl.UnregisterCallback<ClickEvent>(AnimationControlClick);
        _buttonColorPicker.UnregisterCallback<ClickEvent>(ColorPickerClick);
        _buttonPartCreator.UnregisterCallback<ClickEvent>(PartCreatorClick);
        _buttonHair.UnregisterCallback<ClickEvent>(HairClick);
        _buttonAccessories.UnregisterCallback<ClickEvent>(AccessoriesClick);
        _buttonWings.UnregisterCallback<ClickEvent>(WingsClick);
        _buttonPet.UnregisterCallback<ClickEvent>(PetClick);
        _buttonCloths.UnregisterCallback<ClickEvent>(ClothsClick);
        _buttonScalepart.UnregisterCallback<ClickEvent>(ScalepartClick);
        _buttonBody.UnregisterCallback<ClickEvent>(BodyClick);
         for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
        
        if (colorPicker != null)
        {
            colorPicker.OnColorChanged -= HandleColorChanged;
        }
        
        
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        PlayButtonSound();  // Play sound when any other button is clicked
    }

    private void PlayButtonSound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();  // Play the attached audio source
        }
    }
}