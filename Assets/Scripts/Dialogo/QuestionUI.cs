using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private GameObject questionBox;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_InputField questionInput;
    QuestionObject copyO;
    GameObject[] copyThing;

    Shader shader1;

    public InventoryObject inventory;


    bool end = false;
    int instance;

    public bool IsOpen { get; private set; }
    private TypeWriterEffect typewriterEffect;
    private QuestionActivator questionActivator;
    void Start()
    {
        typewriterEffect = GetComponent<TypeWriterEffect>();
        //questionActivator = GetComponent<QuestionActivator>();
        shader1 = Shader.Find("Shader Graphs/Dissolve");
        CloseQuestionBox();
    }


    public void ShowQuestion(QuestionObject questionObject)
    {
        IsOpen = true;
        questionBox.SetActive(true);
        ControlGlobal.ButtonsEnabled = false;
        StartCoroutine(StepThroughtDialogue(questionObject));
    }

    private IEnumerator StepThroughtDialogue(QuestionObject questionObject)
    {
        //foreach (string question in questionObject.Pregunta)
        //{
        //yield return typewriterEffect.Run(dialogue, dialogueText);
        yield return RunTypingEffect(questionObject.Pregunta);
        questionText.text = questionObject.Pregunta;
        yield return null;
        yield return new WaitUntil(() => Input.GetButtonDown("Action") || Input.GetMouseButtonDown(0));
        //StartCoroutine(StepThroughtDialogue(questionObject));
        //}
    }

    private IEnumerator RunTypingEffect(string question)
    {
        typewriterEffect.Run(question, questionText);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetButtonDown("Action"))
            {
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseQuestionBox()
    {
        IsOpen = false;
        questionBox.SetActive(false);
        questionText.text = string.Empty;
        questionInput.text = string.Empty;
        ControlGlobal.ButtonsEnabled = true;
    }

    public void CopyObject(QuestionObject questionObject, bool isEndQuestion, GameObject[] copyT)
    {
        copyO = questionObject;
        end = isEndQuestion;
        copyThing = CopyArray(copyT);
    }

    public GameObject[] CopyArray(GameObject[] copyT)
    {
        GameObject[] cpy = new GameObject[copyT.Length + 1];
        for (int i = 0; i < copyT.Length; i++)//each (GameObject obj in copyT) //
        {
            cpy[i] = copyT[i];
        }
        return cpy;
    }

    public void getComponentofObject(QuestionActivator qa)
    {
        questionActivator = qa;
    }



    public void ButtonPressed()
    {
        if (questionInput.text == copyO.Respuesta)
        {
            if (end)
                EndLevel();
            else
                QuestionCorrect();
        }
        questionInput.text = string.Empty;
    }

    public void QuestionCorrect()
    {


        if (copyThing.Length != 0)
        {
            for (int i = 0; i < copyThing.Length - 1; i++)
            {
                Debug.Log(copyThing[i] + "------------");
                if (copyThing[i].activeSelf)
                {
                    Renderer renderer1 = copyThing[i].GetComponent<Renderer>();
                    var rend = renderer1;

                    rend.material.SetFloat("_FadeStartTime", -float.MaxValue);
                    rend.material.shader = shader1;
                    rend.material.SetFloat("_FadeStartTime", Time.time);
                    StartCoroutine(RetrasoShader(copyThing[i]));
                }
                else
                    copyThing[i].SetActive(true);
            }

            IEnumerator RetrasoShader(GameObject obj)
            {
                //if (rend == null) rend = other.GetComponentsInChildren<Renderer>();


                yield return new WaitForSeconds(1f);
                Destroy(obj);
            }
        }
        ControlGlobal.pausaAbierto = false;
        var sphere = questionActivator.gameObject.GetComponent<SphereCollider>();
        sphere.enabled = false;
        CloseQuestionBox();
    }




    public void EndLevel()
    {
        CloseQuestionBox();
        ControlGlobal.pausaAbierto = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        inventory.Container.Clear();
        SceneManager.LoadScene(nextSceneIndex);

        if (nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneIndex);
                }
    }
}
