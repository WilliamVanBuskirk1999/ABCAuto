using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLayer;
using Model;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class StudentBLL
    {
        public List<ValidationError> errors = new List<ValidationError>();

        /// <summary>
        /// Gets a student by their student id or partial last name
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student GetStudent(string studentId)
        {
            StudentsDB db = new StudentsDB();
            return db.GetStudentById(studentId);
        }

        /// <summary>
        /// Gets the student info of a student checking in a resource
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Student GetStudentCheckingInResource(string resourceId)
        {
            StudentsDB db = new StudentsDB();
            return db.GetStudentCheckingInResource(resourceId);
        }
        /// <summary>
        /// Inserts a student into the database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(Student student)
        {
            StudentsDB db = new StudentsDB();

            Validate(student);
            if (errors.Count == 0)
            {
                return db.InsertStudent(student);
            }

            return 0;
        }

        /// <summary>
        /// Updates a student. Returns 0 on failure
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(Student student)
        {
            StudentsDB db = new StudentsDB();

            Validate(student);
            if (errors.Count == 0)
            {
                return db.UpdateStudent(student);
            }
            return 0;
        }

        /// <summary>
        /// Deletes a student. Returns 0 on failure
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int DeleteStudent(Student student)
        {
            StudentsDB db = new StudentsDB();

            if (!CheckIfStudentWasMadeInError(student) || !CheckBalanceDueIsNotZero(student))
            {
                return 0;
            }
            return db.DeleteStudent(student);
        }

        /// <summary>
        /// Make a payment for a student. The students amount due is reduced by the payment amount and the payment is logged in the payments table
        /// </summary>
        /// <param name="student"></param>
        /// <param name="paymentAmount"></param>
        /// <returns></returns>
        public int MakePayment(Student student, decimal paymentAmount)
        {
            StudentsDB db = new StudentsDB();
            return db.MakePayments(student, paymentAmount);
            
        }
        #region Validations

        /// <summary>
        /// Validates that the student is a valid student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool ValidateStudentObject(Student student)
        {
            ValidationContext context = new ValidationContext(student,null,null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(student, context, results);

            //If the object isn't valid 
            if (!isValid)
            {
                foreach(var validationResult in results)
                {
                    errors.Add(new ValidationError(validationResult.ErrorMessage));
                }
                return false;
            }
            return true;

        }

        /// <summary>
        /// Check if the student has a balance due of zero. If so, return true
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private bool CheckBalanceDueIsNotZero(Student student)
        {
            if (student.AmountDue != 0)
            {
                errors.Add(new ValidationError("This student has a balance due, therefore they may not checkout this resource"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that the end date is 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private bool ValidateEndDate(Student student)
        {
            if(student.EndDate < student.StartDate)
            {
                errors.Add(new ValidationError("The end date of a student cannot be before the start date of the student"));
                return false;
            }

            return true;
        }

        private bool CheckIfStudentWasMadeInError(Student student)
        {
            StudentsDB db = new StudentsDB();

            if (db.CheckIfStudentWasMadeInError(student) == false)
            {
                errors.Add(new ValidationError("This student has records associated with them and therefore may not be deleted"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Performs all validations and ensures each one passes
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private void Validate(Student student)
        {
            ValidateStudentObject(student);
            ValidateEndDate(student);
        }


        #endregion
    }
}
