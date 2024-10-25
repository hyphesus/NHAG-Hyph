using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextResizer : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI m_TextMeshPro;
    public TMPro.TextMeshProUGUI TextMeshPro
    {
        get
        {
            if (m_TextMeshPro == null && transform.GetComponentInChildren<TMPro.TextMeshProUGUI>())
            {
                m_TextMeshPro = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            }
            return m_TextMeshPro;
        }
    }
    RectTransform m_RectTransform;
    public RectTransform rectTransform
    {
        get
        {
            if (m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform;
        }
    }
    RectTransform m_TMPRectTransform;
    public RectTransform TMPRectTransform
    {
        get
        {
            return m_TMPRectTransform;
        }
    }
    private float m_PreferredHeight;
    public float PreferredHeight
    {
        get
        {
            return m_PreferredHeight;
        }
    }
    private float m_PreferredWidth;
    public float PreferredWidth
    {
        get
        {
            return m_PreferredWidth;
        }
    }
    void SetHeight()
    {
        if (TextMeshPro == null)
            return;
        m_PreferredHeight = GetComponentInChildren<TMPro.TextMeshProUGUI>().preferredHeight;
    }
    void SetWidth()
    {
        if (TextMeshPro == null)
            return;
        m_PreferredWidth = GetComponentInChildren<TMPro.TextMeshProUGUI>().preferredWidth;
    }
    public void SetSize()
    {
        SetHeight();
        SetWidth();
        rectTransform.sizeDelta = new Vector2(m_PreferredWidth, m_PreferredHeight);
    }
    private void OnEnable()
    {
        SetSize();
    }
    private void Start()
    {
        SetSize();
    }
    private void Update()
    {
        if (PreferredHeight != TextMeshPro.preferredHeight)
            SetHeight();
        if (PreferredWidth != TextMeshPro.preferredWidth)
            SetWidth();
    }
}
