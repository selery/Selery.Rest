using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.BO.Entity.Workout;

namespace Selery.BO.Entity.Registration
{
    public class User
    {
        public int UserID { get; set; }
        public long FacebookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        string ResetPasswordToken { get; set; }
        DateTime ResetPasswordRequestDate { get; set; }
        /// <summary>
        /// 1 Hombre 2 Mujer
        /// </summary>
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal Heigh { get; set; }
        public int HeighInt { get; set; }
        public int HeighDec { get; set; }
        public int ActivityID { get; set; }
        public string Description { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public Boolean IsApproved { get; set; }
        public Boolean IsLockedOut { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public UserProgram CurrentProgram { get; set; }
        public Boolean IsProfileComplete { get; set; }
        public Goal Goal { get; set; }
        public decimal BMI { get; set; }
        public decimal Calories { get; set; }

        /// <summary>
        /// El peso actual del usuario
        /// </summary>
        public decimal Weight { get; set; }
    

       
    }
}
