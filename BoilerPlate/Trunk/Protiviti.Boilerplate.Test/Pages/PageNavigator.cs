using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Pages
{
    public static class PageNavigator
    {
        public static void NavigatePage(string pageName)
        {
            switch (pageName)
            {
                case "Home":
                    DashboardPage.GoTo();
                    break;
                case "Dashboard":
                    DashboardPage.GoTo();
                    break;
                case "Employee":
                    EmployeePage.GoTo();
                    break;
                case "DemoGrid":
                    GridDemoPage.GoTo();
                    break;
                case "CDS Initiatives":
                    CDSInitiativesPage.GoTo();
                    break;
                case "Register":
                    RegistrationPage.GoTo();
                    break;
            }
        }
    }
}
