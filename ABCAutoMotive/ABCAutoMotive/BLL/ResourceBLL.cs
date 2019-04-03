using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;
using SQLLayer;
using Types;
using System.Data;
using Model.Lists;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class ResourceBLL
    {
        public List<ValidationError> ResourceErrors = new List<ValidationError>();

        #region Getting Data or Sending Data
        /// <summary>
        /// Retrieve a resource based off resourceId
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Resource GetResource(string resourceId)
        {
           ResourceDB db = new ResourceDB();
           return db.RetrieveResource(resourceId);         
        }

        /// <summary>
        /// Retrieve all resource info
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public Resource GetResourceComplete(string resourceId)
        {
            ResourceDB db = new ResourceDB();
            return db.RetrieveAllResourceInfo(resourceId);
        }


        /// <summary>
        /// Check out a resource if all validations pass
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int CheckOutResource(Student student, List<Loans> loans, Resource resource)
        {   
            //Working with parameters
            ResourceDB resourceDB = new ResourceDB();
            return resourceDB.CheckOutResource(loans);
        }

        /// <summary>
        /// Set a resources status to reserved and pass in a student id to indicate who is reserving the resource
        /// </summary>
        /// <param name="student"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ReserveResource(Student student, Resource resource)
        {
            ResourceDB db = new ResourceDB();
            Validate(student, resource);

            if (ResourceErrors.Count == 0)
            {
                return db.ReserveResource(student, resource);
            }
            return 0;
        }

        /// <summary>
        /// Change the resource status
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int ChangeResourceStatus(Resource resource)
        {
            if (CheckResourceStatusIsNotOnLoan(resource))
            {
                ResourceDB db = new ResourceDB();
                return db.ChangeResourceStatus(resource);
            }
            return 0;
        }

        /// <summary>
        /// Add a resource to the database
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int AddResource(Resource resource)
        {
            ResourceDB db = new ResourceDB();

            if (ValidateResourceObject(resource) && CheckForCorrectInsertResourceStatus(resource))
            {
                return db.AddResource(resource);
            }

            return 0;
        }

        #endregion

        #region Validation
        /// <summary>
        /// You cannot change a resources status to on loan
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool CheckResourceStatusIsNotOnLoan(Resource resource)
        {
            if(resource.ResourceStatus == (ResourceStatus)1)
            {
                ResourceErrors.Add(new ValidationError("You cannot change a resources status to on loan"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ensuring that a user cannot insert a resource with a status of on loan
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool CheckForCorrectInsertResourceStatus(Resource resource)
        {
            if(resource.ResourceStatus == (ResourceStatus)1)
            {
                ResourceErrors.Add(new ValidationError("You may not set the status of a new resource to on loan"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checking to see if the reserve status of this resource is already reserved
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool CheckReserveStatus(Resource resource)
        {
            if(resource.ReserveStatus == 0)
            {
                ResourceErrors.Add(new ValidationError("This resource is already reserved"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checking to make sure the resource is available for loan before it can be reserved
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool CheckResourceStatus(Resource resource)
        {
            if (resource.ResourceStatus == (ResourceStatus)2)
            {
                ResourceErrors.Add(new ValidationError("This resource is not available for loan, and therefore cannot be reserved"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checking that the student is still active
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private bool CheckStudentActivityStatus(Student student)
        {
            if(student.Status == 0)
            {
                ResourceErrors.Add(new ValidationError("This student is inactive and may not reserve a resource"));
                return false;
            }
            return true;
        }

        private void Validate(Student student, Resource resource)
        {
            CheckStudentActivityStatus(student);
            CheckResourceStatus(resource);
            CheckReserveStatus(resource);
        }

        /// <summary>
        /// Checks the data annotations for resource to ensure the resource object is correct
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private bool ValidateResourceObject(Resource resource)
        {
            ValidationContext context = new ValidationContext(resource, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(resource, context, results);

            //If the object isn't valid go through the list of validation results and add them to the resource errors
            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    ResourceErrors.Add(new ValidationError(validationResult.ErrorMessage));
                }
                return false;
            }
            return true;
        }
        #endregion

    }
}
