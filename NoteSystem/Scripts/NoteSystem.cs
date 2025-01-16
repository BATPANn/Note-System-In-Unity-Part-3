using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteSystem : MonoBehaviour
{


    public GameObject NoteItself; // the note on the wall

    public GameObject Note_GameObejct; // The Whole Note image

    public Text NoteText; // the text to change here

    public AudioSource Source; // to play audios

    public AudioClip PaperSound;
    public AudioClip SH2Soundeffect;


    public FirstPersonController Fpscontroller;

    public Text InteractionText;

    bool caninteract = true;

    // added Part 2 

    public AudioClip[] NextPageSounds;

    // Page texts

    int PageNumber = 1;

    string ParentString; // Where we put the actual thing we want to write

    string Page1String;
    string Page2String;
    string Page3String;


    // Page texts


    // added Part 2 


    // added Part 3 

    public GameObject[] ReadPanelParts;

    public Text ReadPanelText;



    // added Part 3 

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        


        // give pages values


        Page1String = "This is the First Page, I hope You guys Are enjoying this video [ Page 1 ]";
        Page2String = "If you enjoyed the video, a Like and Sub would be Fantastic [ Page 2 ]";
        Page3String = "YOU can Tell me any opinions or anything you want to tell me in the comment section [ Page 3 ]";


        // give pages values


    }

    // Update is called once per frame
    void Update()
    {

        

        if(caninteract == true)
        {


            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit1;

            if (Physics.Raycast(ray1, out hit1, 10f))
            {


                if (hit1.collider.CompareTag("Paper"))
                {

                    InteractionText.text = "Press E to Take the Note";

                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        ParentString = Page1String;

                        ShowText();


                    }



                }


            }



        }

        





        
    }


    void ShowText()
    {


        caninteract = false;



        InteractionText.text = "";

        Note_GameObejct.SetActive(true);
        NoteText.text = ParentString;

        Source.PlayOneShot(PaperSound);

        Fpscontroller.enabled = false;

        // cursor 


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;



        // cursor



    }



    public void TakeTheNote()
    {

        NoteItself.SetActive(false);
        Note_GameObejct.SetActive(false);
        NoteText.text = "";

        Source.PlayOneShot(SH2Soundeffect);

        Fpscontroller.enabled = true;

        // cursor 


        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        // cursor 





    }

    public void NextPage()
    {



        if(PageNumber == 1)
        {

            PageNumber = 2;

            ParentString = Page2String;

            ShowText();



        }
        else if(PageNumber == 2)
        {

            PageNumber = 3;

            ParentString = Page3String;

            ShowText();

        }
        else if(PageNumber == 3)
        {

            PageNumber = 1;

            ParentString = Page1String;

            ShowText();


        }






        // Random Audio

        Source.Stop();

        int RandomNum = Random.Range(0, NextPageSounds.Length); // select a random number between 0 and 1

        Source.PlayOneShot(NextPageSounds[RandomNum]);


        // Random Audio



    }

    public void PreviousPage()
    {



        if (PageNumber == 1)
        {

            PageNumber = 3;

            ParentString = Page3String;

            ShowText();



        }
        else if (PageNumber == 2)
        {

            PageNumber = 1;

            ParentString = Page1String;

            ShowText();

        }
        else if (PageNumber == 3)
        {

            PageNumber = 2;

            ParentString = Page2String;

            ShowText();


        }




        // Random Audio

        Source.Stop();

        int RandomNum = Random.Range(0, NextPageSounds.Length); // select a random number between 0 and 1

        Source.PlayOneShot(NextPageSounds[RandomNum]);


        // Random Audio


    }


    public void ReadNoteVoid()
    {

        // active read panel parts ( actual read panel )
        ReadPanelParts[0].SetActive(true);
        ReadPanelParts[1].SetActive(true);
        ReadPanelParts[2].SetActive(true);
        // active read panel parts ( actual read panel )

        // change text

        ReadPanelText.text = ParentString;


        // change text



    }

    public void GoBackVoid()
    {



        // active read panel parts ( actual read panel )
        ReadPanelParts[0].SetActive(false);
        ReadPanelParts[1].SetActive(false);
        ReadPanelParts[2].SetActive(false);
        // active read panel parts ( actual read panel )



    }






}
