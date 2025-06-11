namespace EsercizioClassi
{
    internal class Program
    {
        enum Materia
        {
            Italiano,
            Inglese,
            Matematica,
            Informatica,
            Tipsit,
            Sistemi,
            Storia,
            Motoria,
            Telecomunicazioni
        }

        class Alunno
        {
            private string nome;
            private string cognome;
            private string annoDiNascita;
            private List<List<float>> voti;

            public Alunno(string nome, string cognome, string annoDiNascita, int voti)
            {
                this.nome = nome;
                this.cognome = cognome;
                this.annoDiNascita = annoDiNascita;
                this.voti!.Capacity = voti;
            }

            public void AddGrade(Materia materia, float voto) { voti![(int)materia].Add(voto); }
            public float GetAverageForSubject(Materia materia)
            {
                float average = 0;
                for (int i = 0; i < voti[(int)materia].Count; i++)
                    average += voti[(int)materia][i];
                return average / voti[(int)materia].Count;
            }
            public float GetAverage() { return 0.0F;  }
        }

        static void Main(string[] args)
        {
            Alunno alunno = new Alunno("alan", "bovo", "numero", (int)Materia.Telecomunicazioni + 1);

        }
    }
}
