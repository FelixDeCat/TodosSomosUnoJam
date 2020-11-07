using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(UI_Anim_Code))] 
public abstract class UI_Base : MonoBehaviour
{
    [Header("UI_Base")]
    [System.NonSerialized] bool isActive;
    public bool IsActive { get { return isActive; } }

    UI_Anim_Code anim;
    [SerializeField] protected GameObject parent;
    void Awake()
    {
        OnAwake();
    }
    void Start() 
    {
        anim = GetComponent<UI_Anim_Code>();
        if (anim == null) throw new System.Exception("No contiene un UI_AnimBase");
        else anim.AddCallbacks(OnEndOpenAnimation, EndCloseAnimation);
        OnStart(); parent.SetActive(false); }
    void EndCloseAnimation() => OnEndCloseAnimation();
    void Update() { OnUpdate(); }
    protected abstract void OnAwake();
    protected abstract void OnStart();
    protected abstract void OnEndOpenAnimation();
    protected abstract void OnEndCloseAnimation();
    protected abstract void OnUpdate();
    public abstract void Refresh();

    public virtual void Open()
    {
        if(!isActive) anim.Open();
        parent.SetActive(true);
        Refresh();
        isActive = true;
    }
    public virtual void Close(bool buttonDeselect = false)
    {
        if (isActive)
        {
            anim.Close();
            parent.SetActive(false);
            isActive = false;
        }
    }
}
