using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;

namespace GolfClubWebsite.Pages.MembershipCommittee
{
    public class SubmitMembershipApplicationModel : PageModel
    {
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string AlternatePhone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public DateTime DateOfBirth { get; set; }
        [BindProperty]
        public string Occupation { get; set; }
        [BindProperty]
        public string CompanyName { get; set; }
        [BindProperty]
        public string CompanyAddress { get; set; }
        [BindProperty]
        public string CompanyPostalCode { get; set; }
        [BindProperty]
        public string CompanyPhone { get; set; }
        [BindProperty]
        public DateTime ApplicationDate { get; set; }
        [BindProperty]
        public string FirstShareholderName { get; set; }
        [BindProperty]
        public string SecondShareholderName { get; set; }

        [BindProperty]
        public string RequestedRole { get; set; }

        BGC RequestDirector = new BGC();

        bool Confirmation;

        public string Message { get; set; }

        public MembershipApplication NewApplication = new MembershipApplication();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (LastName == null || LastName.Length <= 0)
            {
                ModelState.AddModelError("LastName", "Enter Last Name");
            }

            if(FirstName == null || FirstName.Length <=0)
            {
                ModelState.AddModelError("FirstName", "Enter First Name");
            }

            if (Address == null || Address.Length <= 0)
            {
                ModelState.AddModelError("Address", "Enter Address");
            }
            if (PostalCode == null || PostalCode.Length <= 0)
            {
                ModelState.AddModelError("PostalCode", "Enter Postal Code");
            }
            if (Phone == null || Phone.Length <= 0)
            {
                ModelState.AddModelError("Phone", "Enter Phone Number");
            }
            if (AlternatePhone == null || AlternatePhone.Length <= 0)
            {
                ModelState.AddModelError("AlternatePhone", "Enter Alternate Phone Number");
            }
            if (Email == null || Email.Length <= 0)
            {
                ModelState.AddModelError("Email", "Enter Email");
            }
            if (DateOfBirth.ToString() == null || DateOfBirth.ToString().Length <= 0)
            {
                ModelState.AddModelError("DateOfBirth", "Enter Date of Birth");
            }
            if (Occupation == null || Occupation.Length <= 0)
            {
                ModelState.AddModelError("Occupation", "Enter Occupation");
            }
            if (CompanyName == null || CompanyName.Length <= 0)
            {
                ModelState.AddModelError("CompanyName", "Enter Company Name");
            }
            if (CompanyAddress == null || CompanyAddress.Length <= 0)
            {
                ModelState.AddModelError("CompanyAddress", "Enter Company Name");
            }
            if (CompanyPostalCode == null || CompanyPostalCode.Length <= 0)
            {
                ModelState.AddModelError("CompanyPostalCode", "Enter Company Postal Code");
            }
            if (CompanyPhone == null || CompanyPhone.Length <= 0)
            {
                ModelState.AddModelError("CompanyPhone", "Enter Company Phone Number");
            }
            if (ApplicationDate.ToString() == null || ApplicationDate.ToString().Length <= 0)
            {
                ModelState.AddModelError("ApplicationDate", "Enter Application Date");
            }
            if (FirstShareholderName == null || FirstShareholderName.Length <= 0)
            {
                ModelState.AddModelError("FirstShareholderName", "Enter First Shareholder Name");
            }
            if (SecondShareholderName == null || SecondShareholderName.Length <= 0)
            {
                ModelState.AddModelError("SecondShareholderName", "Enter Second Shareholder Name");
            }
            else
            {
                NewApplication.LastName = LastName;
                NewApplication.FirstName = FirstName;
                NewApplication.Address = Address;
                NewApplication.PostalCode = PostalCode;
                NewApplication.Phone = Phone;
                NewApplication.AlternatePhone = AlternatePhone;
                NewApplication.Email = Email;
                NewApplication.DateOfBirth = DateOfBirth;
                NewApplication.Occupation = Occupation;
                NewApplication.CompanyName = CompanyName;
                NewApplication.CompanyAddress = CompanyAddress;
                NewApplication.CompanyPostalCode = CompanyPostalCode;
                NewApplication.CompanyPhone = CompanyPhone;
                NewApplication.ApplicationDate = ApplicationDate;
                NewApplication.FirstShareholderName = FirstShareholderName;
                NewApplication.SecondShareholderName = SecondShareholderName;
                NewApplication.RequestedRole = RequestedRole;
                Confirmation = RequestDirector.SubmitMembershipApplications(NewApplication);

                if (Confirmation == true)
                {
                    Message = "Application Submitted Successfully";
                }
                else
                {
                    Message = "Failed to submit application";
                }
            }
            
        }

    }
}
