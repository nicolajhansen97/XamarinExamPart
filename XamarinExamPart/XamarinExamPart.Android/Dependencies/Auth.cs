using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using XamarinExamPart.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//Made by Nicolaj
[assembly: Dependency(typeof(XamarinExamPart.Droid.Dependencies.Auth))]
namespace XamarinExamPart.Droid.Dependencies
{
    class Auth : IAuth
    {
        //Firebase handle this for us, we just call for the currentuser ID
        public string GetCurrentUserId()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

        //Firebase handle this for us, we just call if we are Authenticated.
        public bool IsAuthenticated()
        {
            return FirebaseAuth.Instance.CurrentUser != null;
        }

        //We use the information we get, and try to create a user through firebase.
        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception("There is no user record corresponding to this identifier");
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error.");
            }
        }

        //We register the user through firebase with the parameters we got from the user.
        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

         //       FirebaseUser currentUser = FirebaseAuth.Instance.CurrentUser;
         //       currentUser.SendEmailVerification();

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error.");
            }
        }
    }
}