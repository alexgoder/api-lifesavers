using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Ip_API.Models
{
    public class Pacient
    {
        [Key]
        public string CNP { get; set; }

        [Column(TypeName = "varchar(255)")]
        public int Cod_medic { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Nume { get; set; }

        [Column(TypeName = "int")]
        public int Varsta { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Afectiune { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Recomandari { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Numar_telefon { get; set; }


        public static bool verifyCNP(string CNP)
        {
            if (CNP.Length < 13)
                return false;
            else
            {
                for (int i = 0; i < CNP.Length; i++)
                {
                    if (!verifyIfDigit(CNP[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool verifyIfDigit(char c)
        {
            if (c < '9' && c > '0')
                return true;
            return false;
        }
    }

    
}
