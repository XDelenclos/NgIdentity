using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using NgCooking.Models;

namespace NgCooking
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Indiquez votre service de messagerie ici pour envoyer un e-mail.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Connectez votre service SMS ici pour envoyer un message texte.
            return Task.FromResult(0);
        }
    }

    // Configurer l'application que le gestionnaire des utilisateurs a utilisée dans cette application. UserManager est défini dans ASP.NET Identity et est utilisé par l'application.
    public class CommunauteManager : UserManager<Communaute, int>
    {
        public CommunauteManager(IUserStore<Communaute, int> store)
            : base(store)
        {
        }

        public static CommunauteManager Create(IdentityFactoryOptions<CommunauteManager> options, IOwinContext context) 
        {
            var manager = new CommunauteManager(new CustomUserStore(context.Get<ApplicationDbContext>()));
            // Configurer la logique de validation pour les noms d'utilisateur
            manager.UserValidator = new UserValidator<Communaute, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configurer la logique de validation pour les mots de passe
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configurer les valeurs par défaut du verrouillage de l'utilisateur
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Inscrire les fournisseurs d'authentification à 2 facteurs. Cette application utilise le téléphone et les e-mails comme procédure de réception de code pour confirmer l'utilisateur
            // Vous pouvez écrire votre propre fournisseur et le connecter ici.
            manager.RegisterTwoFactorProvider("Code téléphonique ", new PhoneNumberTokenProvider<Communaute, int>
            {
                MessageFormat = "Votre code de sécurité est {0}"
            });
            manager.RegisterTwoFactorProvider("Code d'e-mail", new EmailTokenProvider<Communaute, int>
            {
                Subject = "Code de sécurité",
                BodyFormat = "Votre code de sécurité est {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Communaute, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configurer le gestionnaire de connexion d'application qui est utilisé dans cette application.
    public class ApplicationSignInManager : SignInManager<Communaute, int>
    {
        public ApplicationSignInManager(CommunauteManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(Communaute user)
        {
            return user.GenerateUserIdentityAsync((CommunauteManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<CommunauteManager>(), context.Authentication);
        }

        


        //Personnalisation de la vérification du Password afin de correspondre au model
        public async Task<SignInStatus> PasswordSignInAsync(string userName, string password)
        {
            if (UserManager == null)
                return SignInStatus.Failure;

            Communaute user = UserManager.FindByEmail(userName);

            bool isAuth = await UserManager.CheckPasswordAsync(user, password);
            if (!isAuth)
                return SignInStatus.Failure;

            user = await UserManager.FindByNameAsync(userName);
            await base.SignInAsync(user, false, false);
            return SignInStatus.Success;
        }


    }
}
