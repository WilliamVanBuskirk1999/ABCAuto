using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Types
{
    
    public struct ParmStruct
    {
        public ParmStruct(string name, object value, int size, SqlDbType dbType, ParameterDirection direction)
        {
            Name = name;
            Value = value;
            Size = size;
            DataType = dbType;
            Direction = direction;
        }

        public string Name;
        public object Value;
        public int Size;
        public SqlDbType DataType;
        public ParameterDirection Direction;
    }

    #region Enums
    public enum ProgramOptions
    {
        Regular_Program,
        Block_Release
    }

    public enum StudentStatus
    {
        Inactive, 
        Active
        
    }

    public enum ResourceStatus
    {
       Available,
       On_Loan,
       Not_Available_For_Loan
    }
    public enum ReserveStatus
    {
        Reserved,
        Not_Reserved
    }

    
    public enum ResourceType
    {
        Manufacturers_DVD,
        Manufacturers_Reference_Manual,
        Non_Manufacturer_Reference_Book
    }

    public enum PublisherReferenceNum
    {
        Manufacturers_DVD_BarCode,
        Manufacturers_Reference_Manual_ISBN,
        Non_Manufacturer_Reference_Book_ISBN
    }

    public enum LoanStatus
    {
        On_Loan,
        Returned,
        Returned_damaged,
        Not_Returned
    }
    #endregion
}
