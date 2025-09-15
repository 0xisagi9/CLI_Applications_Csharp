using Contact_Manager_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Application.Utilities;

internal class UserDataFactory
{

    public static Address AddressHelper()
    {
        return new Address
        {
            HomeAddress = InputUtility.ReadInput("Enter Home Address: "),
            Type = InputUtility.ReadInput("Enter Address Type: "),
            Description = InputUtility.ReadInput("Enter Address Description: ")

        };
    }

    public static Phone PhoneHelper()
    {
        return new Phone
        {
            PhoneNumber = InputUtility.ReadInput("Enter Phone Number : "),
            Type = InputUtility.ReadInput("Enter Phone Type: "),
            Description = InputUtility.ReadInput("Enter Phone Description: ")
        };

    }

    public static EmailAddress EmailHepler()
    {
        return new EmailAddress
        {
            Email = InputUtility.ReadInput("Enter Email Address: "),
            Type = InputUtility.ReadInput("Enter Email Type: "),
            Description = InputUtility.ReadInput("Enter Email Description: ")
        };
    }
}
