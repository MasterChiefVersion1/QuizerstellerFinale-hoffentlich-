using quizersteller2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizersteller
{
    public class FrageKlasse
    {
        //der Kopfteil des Quizes
        public author author;
        public string createdAt = "2019-03-05T08:06:29.168Z";
        public string title = "Übungsexam";
        public string description = "";
        public string code = "000-000";
        public int pass = 60;
        public int time = 60;
        public string image = "";
        public List<string> cover { get; }


        //test ist eine Liste der Fragen und ihrer Antworten, kurz eine Liste von Frageblöcken
        public List<Frageblock> test { get; set; }
        //die Objekte werden an dieser Stelle schonmal instanziiert, das spart später Arbeit
        public FrageKlasse()
        {
            test = new List<Frageblock>();
            author = new author();
            cover = new List<string>();
        }

        //der Frageblock. Die Eigenschaften sind Listen, damit das ordentlich ins JSON formatiert wird
        public class Frageblock
        {

            public List<bool> answer { get; set; }
            public List<Question> question { get; set; }



            public List<Choicelabel> choices { get; set; }

            public List<Explanation> explanation;
            //hier wieder die Instanziierung
            public Frageblock()
            {
                answer = new List<bool>();
                question = new List<Question>();
                choices = new List<Choicelabel>();
                explanation = new List<Explanation>();
                question = new List<Question>();
            }




            //eine Variable die der Exam Simulator benötigt zum funktionieren
            public int variant = 1;

        }
    }


}

