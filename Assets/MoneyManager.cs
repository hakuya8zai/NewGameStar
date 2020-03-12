using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    public static int Money; 
    private int MoneyForNow;
    public Text ShowMoney;
    public Text Dialogue;
    public GameObject GM;
    public GameObject firstButtons;
    public GameObject secondButtons;
    public static bool buy;
    public int percent;
    public GameObject InputBox;
    public bool[] Buyed = new bool[5];
    public bool[] Killed = new bool[5];

    
    // Start is called before the first frame update
    void Start()
    {
        buy = false;
        Money = 200;
        Dialogue.text = ("");
        Dialogue.DOText(("目標：成為村莊內最有錢的人！"),1.0f);
        InvokeRepeating(("EndCheck"),20.0f,2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        print(percent);
        if(Input.GetKeyDown(KeyCode.A))
        {
            Money = Money+1000;
        }
        if(MoneyForNow!= Money)
        {
            MoneyForNow = Money;
            MoneyChange();
        }

        
        
    }
    public void Back()
    {
        buy = false;
        firstButtons.SetActive(true);
        secondButtons.SetActive(false);
        InputBox.SetActive(false);
        Dialogue.text = ("");
        Dialogue.DOText(("目標：成為村莊內最有錢的人！"),1.0f);
    }
    public void Reset()
    {
        Money = 0;
        SceneManager.LoadScene(0);
    }

    public void MoneyChange()
    {
        ShowMoney.DOText(Money.ToString(),0.5f);
    }

    public void Abutton()
    {
        if(Buyed[0]==true)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("暴民老闆：暴動!革命!"),0.5f);
            Invoke(("Back"),1.0f);
        }
        else if(Buyed[0]!=true)
        {
            if(Killed[0]==true)
            {
                Dialogue.text = ("");
                Dialogue.DOText (("焦急的婦人：老闆怎麼還不開門...我的老公受了重傷需要藥水阿..."),1.0f);
                Invoke(("Back"),1.2f);
            }
            else if(Killed[0]!= true)
            {
                firstButtons.SetActive(false);
                Dialogue.text = ("");
                Dialogue.DOText(("道具店老闆：歡迎光臨!上好的治癒藥...怎麼是個窮鬼"),1.0f);
                GM.tag = ("Business");
                secondButtons.SetActive(true);
            }
        }
    }
    public void Bbutton()
    {
        if(Buyed[1]==true)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("貴族：國家的力量來自於人民!"),0.5f);
            Invoke(("Back"),1.0f);
        }
        else if(Buyed[1]!=true)
        {
            if(Killed[1]==true)
            {
                Dialogue.text = ("");
                Dialogue.DOText(("貴族小孩：爸爸跟媽媽都不見了!我也沒有地方住了!嗚哇阿阿阿阿!"),0.5f);
                Invoke(("Back"),1.0f);
            }
            else
            {
                firstButtons.SetActive(false);
                Dialogue.text = ("");
                Dialogue.DOText(("貴族：哼!賤民踏入我們家的地板要做什麼!"),0.5f);
                GM.tag = ("Majesty");
                secondButtons.SetActive(true);
            }
        }
    }
    public void Cbutton()
    {
        if(Buyed[2]==true)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("村民：打土豪!分田地!"),0.5f);
            Invoke(("Back"),1.0f);
        }
        else if(Buyed[2]!=true)
        {
            if(Killed[2] == true)
            {
                Dialogue.text = ("");
                Dialogue.DOText(("......"),0.5f);
                Invoke(("Back"),1.0f);
            }
            else
            {
                firstButtons.SetActive(false);
                Dialogue.text = ("");
                Dialogue.DOText(("村民：聽說貴族家的警衛因為過勞住院而被解雇了"),1.0f);
                GM.tag = ("PeopleA");
                secondButtons.SetActive(true);
            }
        }
    }
    public void Dbutton()
    {   
        if(Buyed[3]==true)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("村民：我要發大財!!"),0.5f);
            Invoke(("Back"),1.0f);
        }
        else if(Buyed[3]!=true)
        {
            if(Killed[3] == true)
            {
                Dialogue.text = ("");
                Dialogue.DOText(("......"),0.5f);
                Invoke(("Back"),1.0f);
            }
            else
            {
                firstButtons.SetActive(false);
                Dialogue.text = ("");
                Dialogue.DOText(("村民：只要付我錢，要我做什麼都行。"),0.5f);
                GM.tag = ("PeopleB");
                secondButtons.SetActive(true);
            }
        }
    }
    public void Ebutton()
    {
        if(Buyed[4]==true)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("無產老闆：無產階級下的大民主萬歲!"),0.5f);
            Invoke(("Back"),1.0f);
        }
        else if(Buyed[4]!=true)
        {
            if(Killed[4]==true)
            {
            Dialogue.text = ("");
            Dialogue.DOText(("手足無措的冒險者：沒有武器我們怎麼打倒魔物！！"),1.0f);
            Invoke(("Back"),1.0f);
            }
            else
            {
                firstButtons.SetActive(false);
                Dialogue.text = ("");
                Dialogue.DOText(("武器店大叔：上好的大寶劍！不只販劍，我們也製杖喔！"),1.0f);
                GM.tag = ("Bank");
                secondButtons.SetActive(true);
            }
        }
    }


    public void Kill()
    {
        for(int s = 0;s<=4;s++)
        {
            if(Buyed[s] == true)
            {

        if(GM.CompareTag("Business"))
        {
            InputBox.SetActive(true);
            InputBox.transform.GetComponent<InputField>().text =("0");
        }
        else if(GM.CompareTag("Majesty"))
        {
            InputBox.SetActive(true);
            InputBox.transform.GetComponent<InputField>().text =("0");
        }
        else if(GM.CompareTag("PeopleA"))
        {
            InputBox.SetActive(true);
            Dialogue.text = ("");
            Dialogue.DOText(("此人並非商人，不建議暗殺他"),0.5f);
            InputBox.transform.GetComponent<InputField>().text =("0");
        }
        else if(GM.CompareTag("PeopleB"))
        {
            InputBox.SetActive(true);
            Dialogue.text = ("");
            Dialogue.DOText(("此人並非商人，不建議暗殺他"),0.5f);
            InputBox.transform.GetComponent<InputField>().text =("0");
        }
        else if(GM.CompareTag("Bank"))
        {
            InputBox.SetActive(true);
            InputBox.transform.GetComponent<InputField>().text =("0");
        }
        buy = false;
        secondButtons.SetActive(false);
        break;
            }
            else
            {
            if(s==4)
            {
                Dialogue.text = ("");
                Dialogue.DOText(("需要有支持者才能暗殺"),0.5f);
            }

            }
        }
    }
    public void Buy()
    {
        if(GM.CompareTag("Business"))
        {
            if(Money >1000)
            {
                InputBox.SetActive(true);
                InputBox.transform.GetComponent<InputField>().text =("0");

            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("老闆：沒錢就沒得談!滾出去!"),0.5f);
                Invoke(("Back"),1.0f);
            }
        }
        else if(GM.CompareTag("Majesty"))
        {
            if(Money >1000)
            {
                InputBox.SetActive(true);
                InputBox.transform.GetComponent<InputField>().text =("0");

            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("貴族管家：窮光蛋想做什麼!滾出去!"),0.5f);
                Invoke(("Back"),1.0f);
            }
        }
        else if(GM.CompareTag("PeopleA"))
        {
            if(Money >=50)
            {
                InputBox.SetActive(true);
                InputBox.transform.GetComponent<InputField>().text =("0");

            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("村民：比我還窮想做什麼!給我重新開始!"),0.5f);
                Invoke(("Back"),1.0f);
            }
        }
        else if(GM.CompareTag("PeopleB"))
        {
            if(Money >= 50)
            {
                InputBox.SetActive(true);
                InputBox.transform.GetComponent<InputField>().text =("0");

            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("村民：比我還窮想做什麼!給我重新開始!"),0.5f);
                Invoke(("Back"),1.0f);
            }
            
        }
        else if(GM.CompareTag("Bank"))
        {
            if(Money >1000)
            {
                InputBox.SetActive(true);
                InputBox.transform.GetComponent<InputField>().text =("0");
            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("老闆：窮光蛋想做什麼!滾出去!"),0.5f);
                Invoke(("Back"),1.0f);
            }
        }
        buy = true;        
        secondButtons.SetActive(false);

    }
    public void Inputing()
    {
        int Put =int.Parse(InputBox.transform.GetComponent<InputField>().text);
        if(Put >Money)
        {
            InputBox.transform.GetComponent<InputField>().text = (Money.ToString());
        }


        if((double)Put/(Money+1) >=0.8f)
        {
            percent =50;
        }
        else if((double)Put/(Money+1) >=0.6f&&Put/(Money+1) <0.8f)
        {
            percent =40;
        }
        else if((double)Put/(Money+1) >=0.4f&&Put/(Money+1) <0.6f)
        {
            percent =30;
        }
        else if((double)Put/(Money+1) >=0.1f&&Put/(Money+1) <0.4f)
        {
            percent =20;
        }
        else if((double)Put/(Money+1) >=0.0f&&Put/(Money+1) <0.1f)
        {
            percent =0;
        }
        WinningPercent();

    }
    public void InputEvent()
    {
        int Pay =int.Parse(InputBox.transform.GetComponent<InputField>().text);
        Money = Money-Pay;
        InputBox.SetActive(false);

        if(buy == true)
        {
            Buyover();
        }
        else
        {

            Killover();
            

        }
    }
    public void WinningPercent()
    {
        if(buy == true)
        {
        if(GM.CompareTag("Business"))
        {
            percent = percent + 0;
        }
        else if(GM.CompareTag("Majesty"))
        {
            percent = percent +0;
        }
        else if(GM.CompareTag("PeopleA"))
        {
            percent = percent +60;
            
        }
        else if(GM.CompareTag("PeopleB"))
        {
            percent = percent +60;
        }
        else if(GM.CompareTag("Bank"))
        {
            percent = percent +0;
        }
        }
        else
        {
            for(int i =0; i<=4;i++)
            {
                if(Buyed[i]==true)
                {
                    percent= percent+20;
                }
            }
        }

        if(percent>=90)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("成功率極高"),0.1f);
        }
        else if (percent <90&& percent >=70)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("成功率高"),0.1f);
        }
        else if (percent <70 && percent >=50)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("成功率中等"),0.1f);
        }
        else if (percent <50 && percent>=20)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("成功率低"),0.1f);
        }
        else if (percent <20)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("成功率極低"),0.1f);
        }

    }
    public void Buyover()
    {
        int a = Random.Range(0,100);
        if(a >= percent)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("買通失敗"),0.5f);
        }
        else
        {
            if(GM.CompareTag("Business"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("買通成功，你得到一名支持者"),0.5f);
                Buyed[0] = true;
            }
            else if(GM.CompareTag("Majesty"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("買通成功，你得到一名支持者"),0.5f);
                Buyed[1] = true;
            }
            else if(GM.CompareTag("PeopleA"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("買通成功，你得到一名支持者"),0.5f);
                Buyed[2] = true;
            }
            else if(GM.CompareTag("PeopleB"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("買通成功，你得到一名支持者"),0.5f);
                Buyed[3] = true;
            }
            else if(GM.CompareTag("Bank"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("買通成功，你得到一名支持者"),0.5f);
                Buyed[4] = true;
            }
            Invoke(("EndCheck"),1.1f);
            Invoke(("Back"),1.0f);

        }
    }
    public void Killover()
    {
        int a = Random.Range(0,100);
        if(a >= percent)
        {
            Dialogue.text = ("");
            Dialogue.DOText(("暗殺失敗"),0.5f);
        }
        else
        {
            if(GM.CompareTag("Business"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("暗殺成功，你奪取了商人的家產2000元"),0.5f);
                Money=Money+2000;
                Killed[0] = true;
            }
            else if(GM.CompareTag("Majesty"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("暗殺成功，你奪取了貴族的家產1200元"),0.5f);
                Money=Money+1200;
                Killed[1] = true;
            }
            else if(GM.CompareTag("PeopleA"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("暗殺成功，你奪取了村民的家產50元"),0.5f);
                Money = Money+50;
                Killed[2] = true;
            }
            else if(GM.CompareTag("PeopleB"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("暗殺成功，你奪取了村民的家產50元"),0.5f);
                Money = Money+50;
                Killed[3] = true;
            }
            else if(GM.CompareTag("Bank"))
            {
                Dialogue.text = ("");
                Dialogue.DOText(("暗殺成功，你奪取了商人的家產1500元"),0.5f);
                Money=Money+1500;
                Killed[4] = true;
            }
            Invoke(("BuyPolice"),1.0f);

        }

    }
    public void BuyPolice()
    {
            Money = Money-500;
            if(Money<0)
            {
                Dialogue.text = ("");
                Dialogue.DOText(("你沒有錢買通指警察，因此被就地槍決了"),0.5f);
                Invoke(("Reset"),1.0f);;
            }
            else
            {
                Dialogue.text = ("");
                Dialogue.DOText(("你花500元買通了警察"),0.5f);
                Invoke(("EndCheck"),2.0f);
            }
            Invoke(("Back"),1.0f);

    }

    public void EndCheck()
    {
        for(int c = 0;c<=4;c++)
        {
            if(Buyed[c]!=true&&Killed[c]!=true)
            {
                break;
            }
            if(c==4)
            {
                Dialogue.text = ("");
                Dialogue.text = ("村民們發起革民，成功推翻了領主，你被定位為「革命領導的發起人」，得到後人景仰。");
            }
        }
    }


}
