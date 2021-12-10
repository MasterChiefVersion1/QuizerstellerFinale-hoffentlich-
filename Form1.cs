using MaterialSkin.Controls;
using quizersteller2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Quizersteller
{
    public partial class Form1 : MaterialForm
    {
        // MaterialSkin einführen (readonly?)
        MaterialSkin.MaterialSkinManager materialSkinManager;
        public Form1()
        {
            // Material
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            //Farbschema hinzufügen
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Red400, MaterialSkin.Primary.Red800, 
            MaterialSkin.Primary.Red200, MaterialSkin.Accent.Red100, MaterialSkin.TextShade.WHITE);

        }

        FrageKlasse Quiz = new FrageKlasse();



        //der Fragezähler hält fest, ob die vor und zurück button geklickt wurden, muss irgendwo anders stehen
        public int Fragezähler = 0;
        //ein String der das Quiz in ordentlicher Ausgabeform enthalten soll
        public string OA = "";

       
        


        // material Checkboxen
        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialCheckbox7_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //material Buttons 10 Stück

        //fügt dem Quiz eine neue Frage hinzu
        private void materialButton1_Click(object sender, EventArgs e)
        {
            //  kontrolle ob Häkchen gesetzt wurden
            if (materialCheckbox1.Checked == false && materialCheckbox2.Checked == false && materialCheckbox3.Checked == false && materialCheckbox4.Checked == false && materialCheckbox5.Checked == false && materialCheckbox6.Checked == false && materialCheckbox7.Checked == false)
            {
                txtspeicher.Text = "Es wurde noch keine Antwort als richtig markiert";
            }
            else
            {
                FrageKlasse.Frageblock Frageblock1 = new FrageKlasse.Frageblock();

                string A = txt1.Text;
                string B = txt2.Text;
                string C = txt3.Text;
                string D = txt4.Text;
                string E = txt5.Text;
                string F = txt6.Text;
                string G = txt7.Text;
                string Frage = txtfrage.Text;


                //die Checkboxen werden kontrolliert
                if (materialCheckbox1.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox2.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox3.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox4.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox5.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox6.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox7.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }

                //die Question und die Labels müssen instanziiert werden
                Question question = new Question(1, Frage);
                Frageblock1.question.Add(question);

                Choicelabel labelA = new Choicelabel("A", A);
                Choicelabel labelB = new Choicelabel("B", B);
                Choicelabel labelC = new Choicelabel("C", C);
                Choicelabel labelD = new Choicelabel("D", D);
                Choicelabel labelE = new Choicelabel("E", E);
                Choicelabel labelF = new Choicelabel("F", F);
                Choicelabel labelG = new Choicelabel("G", G);

                Frageblock1.choices.Add(labelA);
                Frageblock1.choices.Add(labelB);
                Frageblock1.choices.Add(labelC);
                Frageblock1.choices.Add(labelD);
                if (E != "") { Frageblock1.choices.Add(labelE); }
                if (F != "") { Frageblock1.choices.Add(labelF); }
                if (G != "") { Frageblock1.choices.Add(labelG); }

                if (G == "") { Frageblock1.answer.RemoveAt(6); }
                if (F == "") { Frageblock1.answer.RemoveAt(5); }
                if (E == "") { Frageblock1.answer.RemoveAt(4); }
                //Kontrolliert ob wenigsten 4 choicemöglichkeiten gegeben sind
                if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "" || txt4.Text == "") { txtspeicher.Text = "Die ersten 4 Felder müssen ausgefüllt sein"; }

                else
                {
                    Quiz.test.Add(Frageblock1);
                    //zeigt die oderntliche Vorschau
                    materialButton2.PerformClick();
                    //leert die Forlage
                    materialButton4.PerformClick();
                    //aktiviert die Möglichkeit zu speichern und zu bearbeiten
                    materialButton6.Enabled = true; materialButton8.Enabled = true;
                }
            }

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            //die Textbox wird geleert damit keine Dopplungen entstehen oder ähnliche blöde Sachen
            txtausgabe.Text = "";
            //es wird über die Anzahl von Frageblöcken geloopt und der Text aus denen raus geschrieben
            for (int z = 0; z < Quiz.test.Count; z++)
            {
                FrageKlasse.Frageblock frageblock2 = Quiz.test.ElementAt(z);

                int i = frageblock2.choices.Count;
                //die choicelabel objekte müssen instanziiert werden
                Question question2 = frageblock2.question.ElementAt(0); txtausgabe.Text += "\n" + question2.text;
                Choicelabel choicelabelA2 = frageblock2.choices.ElementAt(0); txtausgabe.Text += "\n" + choicelabelA2.text;
                Choicelabel choicelabelB2 = frageblock2.choices.ElementAt(1); txtausgabe.Text += "\n" + choicelabelB2.text;
                Choicelabel choicelabelC2 = frageblock2.choices.ElementAt(2); txtausgabe.Text += "\n" + choicelabelC2.text;
                Choicelabel choicelabelD2 = frageblock2.choices.ElementAt(3); txtausgabe.Text += "\n" + choicelabelD2.text;
                if (i > 4) { Choicelabel choicelabelE2 = frageblock2.choices.ElementAt(4); txtausgabe.Text += "\n" + choicelabelE2.text; }
                if (i > 5) { Choicelabel choicelabelF2 = frageblock2.choices.ElementAt(5); txtausgabe.Text += "\n" + choicelabelF2.text; }
                if (i > 6) { Choicelabel choicelabelG2 = frageblock2.choices.ElementAt(6); txtausgabe.Text += "\n" + choicelabelG2.text; }
                //die Textboxen werden wiederhergestellt
                // if formulierungen, da nicht alle fragen 7 antworten haben

                // ob die Antworten richtig oder falsch waren wird als Textzeile geschrieben
                if (frageblock2.answer.ElementAt(0) == true) { txtausgabe.Text += "\n" + true + ", "; } else { txtausgabe.Text += "\n" + false + ", "; }
                if (frageblock2.answer.ElementAt(1) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; }
                if (frageblock2.answer.ElementAt(2) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; }
                if (frageblock2.answer.ElementAt(3) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; }
                if (i > 4) { if (frageblock2.answer.ElementAt(4) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; } }
                if (i > 5) { if (frageblock2.answer.ElementAt(5) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; } }
                if (i > 6) { if (frageblock2.answer.ElementAt(6) == true) { txtausgabe.Text += true + ", "; } else { txtausgabe.Text += false + ", "; } }
                txtausgabe.Text += "\n" + "\n";
            }
        }

        // liest ein JSON Quiz ein, kopiert die Fragen in das derzeitige Quiz, zeigt die Vorschau
        private void materialButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string J = File.ReadAllText(openFileDialog.FileName);

                FrageKlasse Q = new FrageKlasse();
                Q = JsonConvert.DeserializeObject<FrageKlasse>(J);

                Quiz.test.AddRange(Q.test);

                //zeigt eine ordentliche Vorschau
                materialButton2.PerformClick();
                //aktiviert die Möglichkeit zu speichern und zu bearbeiten
                materialButton6.Enabled = true; materialButton8.Enabled = true;
            }

        }

        //leert die Textfelder und checkboxen
        private void materialButton4_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txtfrage.Text = "";

            materialCheckbox1.Checked = false;
            materialCheckbox2.Checked = false;
            materialCheckbox3.Checked = false;
            materialCheckbox4.Checked = false;
            materialCheckbox5.Checked = false;
            materialCheckbox6.Checked = false;
            materialCheckbox7.Checked = false;

        }

        //zeigt das komplette Quiz im JSON Format
        public void materialButton5_Click(object sender, EventArgs e)
        {
            string JSON = JsonConvert.SerializeObject(Quiz, Formatting.Indented);

            txtausgabe.Text = JSON;

        }
        //speichert den Txtasugabe Text als ein neues File
        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (Quiz.test.Count == 0)
            { txtspeicher.Text = "Es ist noch kein Speicherbares Quiz vorhanden"; }

            else
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string JSON = JsonConvert.SerializeObject(Quiz, Formatting.Indented);
                    File.AppendAllText(saveFileDialog.FileName, JSON);

                }
            }


        }

        //der nach Links button
        private void materialButton7_Click(object sender, EventArgs e)
        {
            Fragezähler--;
            //bearbeitungsknopf, sorgt dafür, dass die Textfelder ausgefüllt werden
            materialButton8.PerformClick();
        }

        //soll die Fragen, Choices und checkboxen zurück in die Vorlage laden um sie bearbeiten zu können und dann wieder zurück
        private void materialButton8_Click(object sender, EventArgs e)
        {
            //eine Vorsichtsmaßnahme. Falls jemand mit den Buttons rumspielt bevor ein Quiz da ist
            if (Quiz.test.Count > 0)
            {
                //stellt die Farbe des Buttons um, ist nur eine spielerei
                if (materialButton8.UseAccentColor == false) { materialButton1.UseAccentColor = true; }
                //deaktiviert den Frage hinzufügen Button
                materialButton1.Enabled = false;
                //aktiviert die Buttons um ziwschen den Positionen zu switchen
                materialButton7.Enabled = true; materialButton9.Enabled = true;
                //aktiviert den Button Änderung bestätigen
                materialButton10.Enabled = true;
                //die Stellle in der Testliste wird bestimmt, so dass sie nicht größer als die Liste und nicht kleiner 0 ist
                int stelle;
                stelle = Quiz.test.Count + Fragezähler - 1;
                //verhindert stellen größer als die Liste
                if (stelle >= Quiz.test.Count) { stelle = Quiz.test.Count - 1; Fragezähler = 0; }
                //verhindert stellen kleiner als die 0 in der Liste
                if (stelle <= 0) { stelle = 0; Fragezähler = -Quiz.test.Count + 1; }
                //ein neues Frageblock Objekt wird wird aus dem Quiz instanziiert, damit wir darauf zugreifen können
                FrageKlasse.Frageblock frageblock2 = Quiz.test.ElementAt(stelle);

                int i = frageblock2.choices.Count;
                //die choicelabel objekte müssen instanziiert werden
                Question question2 = frageblock2.question.ElementAt(0);
                Choicelabel choicelabelA2 = frageblock2.choices.ElementAt(0);
                Choicelabel choicelabelB2 = frageblock2.choices.ElementAt(1);
                Choicelabel choicelabelC2 = frageblock2.choices.ElementAt(2);
                Choicelabel choicelabelD2 = frageblock2.choices.ElementAt(3);
                if (i > 4) { Choicelabel choicelabelE2 = frageblock2.choices.ElementAt(4); txt5.Text = choicelabelE2.text; }
                if (i > 5) { Choicelabel choicelabelF2 = frageblock2.choices.ElementAt(5); txt6.Text = choicelabelF2.text; }
                if (i > 6) { Choicelabel choicelabelG2 = frageblock2.choices.ElementAt(6); txt7.Text = choicelabelG2.text; }
                //die Textboxen werden wiederhergestellt
                // if formulierungen, da nicht alle fragen 7 antworten haben
                txtfrage.Text = question2.text;
                txt1.Text = choicelabelA2.text;
                txt2.Text = choicelabelB2.text;
                txt3.Text = choicelabelC2.text;
                txt4.Text = choicelabelD2.text;
                //der Status der Checkboxen wird wiederhergestellt
                if (frageblock2.answer.ElementAt(0) == true) { materialCheckbox1.Checked = true; } else { materialCheckbox1.Checked = false; }
                if (frageblock2.answer.ElementAt(1) == true) { materialCheckbox2.Checked = true; } else { materialCheckbox2.Checked = false; }
                if (frageblock2.answer.ElementAt(2) == true) { materialCheckbox3.Checked = true; } else { materialCheckbox3.Checked = false; }
                if (frageblock2.answer.ElementAt(3) == true) { materialCheckbox4.Checked = true; } else { materialCheckbox4.Checked = false; }
                if (i > 4 && frageblock2.answer.ElementAt(4) == true) { materialCheckbox5.Checked = true; } else { materialCheckbox5.Checked = false; }
                if (i > 5 && frageblock2.answer.ElementAt(5) == true) { materialCheckbox6.Checked = true; } else { materialCheckbox6.Checked = false; }
                if (i > 6 && frageblock2.answer.ElementAt(6) == true) { materialCheckbox7.Checked = true; } else { materialCheckbox7.Checked = false; }
            }


        }

        //der eins nach Rechts Button
        private void materialButton9_Click(object sender, EventArgs e)
        {
            Fragezähler++;
            //bearbeitungsknopf, sorgt dafür, dass die Textfelder ausgefüllt werden
            materialButton8.PerformClick();
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            //ändert die Farbe des Bearbeitungsbuttons, ist eine Spielerei
            materialButton1.UseAccentColor = false; 
            //disabled die Buttons zum rum switchen wieder
            materialButton7.Enabled = false; materialButton9.Enabled = false;
            //die Stellle in der Testliste wird bestimmt, so dass sie nicht größer als die Liste und nicht kleiner 0 ist
            int stelle;
            stelle = Quiz.test.Count + Fragezähler - 1;
            //verhindert stellen größer als die Liste
            if (stelle >= Quiz.test.Count) { stelle = Quiz.test.Count - 1; Fragezähler = 0; }
            //verhindert stellen kleiner als die 0 in der Liste
            if (stelle <= 0) { stelle = 0; Fragezähler = -Quiz.test.Count + 1; }

            //  kontrolle ob Häkchen gesetzt wurden
            if (materialCheckbox1.Checked == false && materialCheckbox2.Checked == false && materialCheckbox3.Checked == false && materialCheckbox4.Checked == false && materialCheckbox5.Checked == false && materialCheckbox6.Checked == false && materialCheckbox7.Checked == false)
            {
                txtspeicher.Text = "Es wurde noch keine Antwort als richtig markiert";
            }
            else
            {
                FrageKlasse.Frageblock Frageblock1 = new FrageKlasse.Frageblock();

                string A = txt1.Text;
                string B = txt2.Text;
                string C = txt3.Text;
                string D = txt4.Text;
                string E = txt5.Text;
                string F = txt6.Text;
                string G = txt7.Text;
                string Frage = txtfrage.Text;



                //die Checkboxen werden kontrolliert
                if (materialCheckbox1.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox2.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox3.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox4.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox5.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox6.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }
                if (materialCheckbox7.Checked == true) { Frageblock1.answer.Add(true); } else { Frageblock1.answer.Add(false); }


                //die Question und die Labels müssen instanziiert werden
                Question question = new Question(1, Frage);
                Frageblock1.question.Add(question);

                Choicelabel labelA = new Choicelabel("A", A);
                Choicelabel labelB = new Choicelabel("B", B);
                Choicelabel labelC = new Choicelabel("C", C);
                Choicelabel labelD = new Choicelabel("D", D);
                Choicelabel labelE = new Choicelabel("E", E);
                Choicelabel labelF = new Choicelabel("F", F);
                Choicelabel labelG = new Choicelabel("G", G);



                Frageblock1.choices.Add(labelA);
                Frageblock1.choices.Add(labelB);
                Frageblock1.choices.Add(labelC);
                Frageblock1.choices.Add(labelD);
                if (E != "") { Frageblock1.choices.Add(labelE); }
                if (F != "") { Frageblock1.choices.Add(labelF); }
                if (G != "") { Frageblock1.choices.Add(labelG); }

                if (G == "") { Frageblock1.answer.RemoveAt(6); }
                if (F == "") { Frageblock1.answer.RemoveAt(5); }
                if (E == "") { Frageblock1.answer.RemoveAt(4); }
                //Kontrolliert ob wenigsten 4 choicemöglichkeiten gegeben sind
                if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "" || txt4.Text == "") { txtspeicher.Text = "Die ersten 4 Felder müssen ausgefüllt sein"; }

                else
                {
                    //hier wird die änderung übernommen
                    Quiz.test.Remove(Quiz.test.ElementAt(stelle));
                    Quiz.test.Insert(stelle, Frageblock1);
                    //zeigt die oderntliche Vorschau
                    materialButton2.PerformClick();
                    //leert die Forlage
                    materialButton4.PerformClick();
                    //aktiviert die Frage hinzufügen Möglichkeit wieder
                    materialButton1.Enabled = true;
                }
            }
        }

        private void txtspeicher_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
