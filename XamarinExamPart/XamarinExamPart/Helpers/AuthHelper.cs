using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinExamPart.Helpers
{
    //Everything on this page is made by Nicolaj


    //This is our Interface we use. We use DependencyService for this. The Dependency service will check for everyplace that uses this Interface. 
    //Therefor it will if you use a Android phone take that the interface is used there, and use the code from there.
    //We need to do this, as we dont have access to the code from Firebase.Auth Nugget package, as it is for Android and IOS. 
    public interface IAuth
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> LoginUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }
    public class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();

        //Register user, takes two parameters.
        public static async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                return await auth.RegisterUser(email, password);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }

        //Login user, also takes the email and password as parameter.
        public static async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                return await auth.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }

        //We will use this to check if the user is Authenticated, so we can be sure that the data we add to the database is for the right gardener.
        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }

        //This will give us the currentUserId for the account which we will use to store in the Mongoose db, so we later on can find the data for the right user again.
        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}