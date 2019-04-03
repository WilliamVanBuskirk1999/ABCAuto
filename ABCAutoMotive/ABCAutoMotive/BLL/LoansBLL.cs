using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Types;

namespace BLL
{
    public class LoansBLL
    {
        public List<Loans> loans = new List<Loans>();
        public List<ValidationError> errors = new List<ValidationError>();
        public DataTable RetrieveLoans(Student student)
        {
            LoanDB db = new LoanDB();
            return db.RetrieveLoanInfo(student);
        }
        /// <summary>
        /// Getting the list of loans to be checked in
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public List<Loans> GetListOfLoansForCheckIn(string resourceId, Student student)
        {
            LoanDB db = new LoanDB();
            return db.GetListOfLoans(db.RetrieveResourcesStudentCheckedOut(resourceId,student));
        }
        /// <summary>
        /// Add to the list of resources to be borrowed
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public bool AddToLoansList(Resource resource, Student student)
        {
            ValidateForAddToLoans(student, resource);
            if (errors.Count == 0)
            {
                if (resource.ResourceStatus == (ResourceStatus)0)
                {
                    Loans newLoan = new Loans();

                   
                    newLoan.ResourceId = resource.ResourceId;
                    newLoan.StudentId = student.StudentId;
                    newLoan.Title = resource.Title;
                    newLoan.Type = resource.Type;

                    //If this loans in the list, don't add it. Throw an error
                    foreach(Loans loan in loans)
                    {
                        if(loan.ResourceId == newLoan.ResourceId)
                        {
                            errors.Add(new ValidationError("This resource is already in the list of resources to be checked out!"));
                            return false;
                        }

                        if(loan.Type == newLoan.Type)
                        {
                            errors.Add(new ValidationError("A resource of this type is already in the list"));
                            return false;
                        }
                    }

                    loans.Add(newLoan);
                    return true;
                }
            }

            return false;
        }
        public int CheckInLoans(List<Loans> loans, Student student)
        {
            LoanDB db = new LoanDB();
            return db.CheckInResources(loans, student);
        }

        /// <summary>
        /// Removes an item from list of loans to be checked out
        /// </summary>
        /// <param name="index"></param>
        public void RemoveFromLoansList(int index)
        {
            loans.RemoveAt(index);
        }

        #region Validation

        /// <summary>
        /// Checking to see if this student has a resource of this type
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public bool CheckIfStudentHasResource(Student student, Resource resource)
        {
            LoanDB loansdb = new LoanDB();

            if(loansdb.ReturnStudentLoanTypes(student, resource) > 0)
            {
                errors.Add(new ValidationError("This student cannot have two resources of the same type. They may not have returned a resource with this loan type"));
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
        /// If the student has no overdue items, return true
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private bool CheckIfStudentHasNoOverDueItems(Student student)
        {
            LoanDB db = new LoanDB();

            decimal result = db.CheckForOverdueItems(student);

            if (result > 0)
            {
                errors.Add(new ValidationError("This student has an overdue item, they may not checkout this resource"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks to see if the student is inactive, if they are return false
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private bool CheckIfStudentIsInactive(Student student)
        {
            LoanDB db = new LoanDB();

            int result = db.ReturnStudentActivityStatus(student);

            if(result == 0)
            {
                errors.Add(new ValidationError("This student is inactive, they may not checkout resources"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// If this resource is reserved check that it is reserved by the correct student
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool CheckIfResourceIsReservedForThisStudent(Student student, Resource resource)
        {
            LoanDB db = new LoanDB();

            int result = db.ReturnIfStudentHasThisResourceReserved(student, resource);

            if(result == 0)
            {
                errors.Add(new ValidationError("This resource is reserved by another student"));
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// This validation must pass to allow a student to add something to their resource list
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private void ValidateForAddToLoans(Student student, Resource resource)
        {
            CheckBalanceDueIsNotZero(student);
            CheckIfStudentHasNoOverDueItems(student);
            CheckIfStudentHasResource(student, resource);
            CheckIfStudentIsInactive(student);
            CheckIfResourceIsReservedForThisStudent(student,resource);



        }

        #endregion

    }
}
