using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager:MonoBehaviour
{
    public int m_NumRoundsToWin = 5;
    public float m_StartDelay = 5f;
    public float m_EndDelay = 3f;
    public CameraControl m_CameraControl;
    public Text m_MessageText;
    public GameObject m_TankPrefab;
    public TankManager[] m_Tanks;

    private int m_RoundNumber;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    private TankManager m_RoundWinner;
    private TankManager m_GameWinner;


    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        SpawnAllTanks();
        //SetCameraTargets();
        //StartCoroutine(GameLoop());
    }

    private void SpawnAllTanks()
    {

    }





}
