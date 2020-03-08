using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class DeathSaves
    {
        [Key]
        public int Id {get;set;}
        public bool[] SuccessfulSaves { get; set; } = new bool[3];
        public bool[] FailedSaves { get; set; } = new bool[3];

        public void AddSuccessfulSave()
        {
            for(int i = 0; i < SuccessfulSaves.Length; i++)
            {
                if (!SuccessfulSaves[i])
                {
                    SuccessfulSaves[i] = true;
                    break;
                }
            }
        }

        public void RemoveSuccessfulSave()
        {
            for (int i = SuccessfulSaves.Length - 1; i >= 0; i--)
            {
                if (SuccessfulSaves[i])
                {
                    SuccessfulSaves[i] = false;
                    break;
                }
            }
        }

        public void ResetSuccessfulSaves()
        {
            for (int i = 0; i < SuccessfulSaves.Length; i++)
            {
                if (SuccessfulSaves[i])
                {
                    SuccessfulSaves[i] = false;
                }
            }
        }

        public void AddFailedSave()
        {
            for (int i = 0; i < FailedSaves.Length; i++)
            {
                if (!FailedSaves[i])
                {
                    FailedSaves[i] = true;
                    break;
                }
            }
        }

        public void RemoveFailedSave()
        {
            for (int i = FailedSaves.Length - 1; i >= 0; i--)
            {
                if (FailedSaves[i])
                {
                    FailedSaves[i] = false;
                    break;
                }
            }
        }

        public void ResetFailedSaves()
        {
            for (int i = 0; i < FailedSaves.Length; i++)
            {
                if (FailedSaves[i])
                {
                    FailedSaves[i] = false;
                }
            }
        }

        public void ResetAllSaves()
        {
            ResetSuccessfulSaves();
            ResetFailedSaves();
        }
    }
}
