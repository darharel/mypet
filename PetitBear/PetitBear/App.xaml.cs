using PetitBear.DB;
using PetitBear.Models;
using PetitBear.Services;
using PetitBear.Views;
using PetitBear.Views.Menu;
using SQLite;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PetitBear
{
    public partial class App : Application
    {
        //static SQLiteAsyncConnection connection = DependencyService.Get<ISQLiteDB>().GetConnection();
        private static TokenController tokenDB;
        private static UserController userDB;
        private static MyPetsController myPetsDB;
        private static MyVetController myVetDB;
        private static TreatmentsController treatmentsDB;
        static object locker = new object();
        public const string webUrl = "https://api.myjson.com/bins/vf4ma";
        // this is for API Usage
        static RestService restService;
        public static object TimerSpan { get; private set; }

        //public static SQLiteAsyncConnection _sqlconnection;
        private static Label labelScreen;
        private static bool HasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        public App()
        {
            InitializeComponent();

            //MainPage = new LoginPage();

            MainPage = new MasterDetail();

            //MainPage = new NavigationPage(new MasterPage());
            //MainPage = new PetProfilePage();
            //MainPage = new NavigationPage(new ProfileSupplierPage(new SupplierModel { Address = "Tel Aviv", Name = "Steve - O", City = "Tel Aviv", Phone = "0548354304", Profession = "Best Vet" }));
            //MainPage = new NavigationPage(new MyVetPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        // Below is for LOCAL SQLite Usage
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                    restService = new RestService();
                return restService;
            }
        }
        public static UserController UserController
        {
            get
            {
                if (userDB == null)
                    userDB = new UserController();
                return userDB;
            }
        }
        public static TokenController TokenController
        {
            get
            {
                if (tokenDB == null)
                    tokenDB = new TokenController();
                return tokenDB;
            }
        }
        public static MyPetsController MyPetsController
        {
            get
            {
                if (myPetsDB == null)
                    myPetsDB = new MyPetsController();
                return myPetsDB;
            }
        }
        public static MyVetController MyVetController
        {
            get
            {
                if (myVetDB == null)
                    myVetDB = new MyVetController();
                return myVetDB;
            }
        }
        public static TreatmentsController TreatmentsController
        {
            get
            {
                if (treatmentsDB == null)
                    treatmentsDB = new TreatmentsController();
                return treatmentsDB;
            }
        }




        //**************** Internet Connection ***********************
        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            HasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(20).TotalMilliseconds);


            }

        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (HasInternet)
                        {
                            if (!noInterShow)
                            {
                                HasInternet = false;
                                labelScreen.IsVisible = true;
                                await ShowDisplayAlert();
                            }
                        }
                    });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    HasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "device Has No Internet, Please Reconnect", "OK");
            noInterShow = false;
        }
    }
}
