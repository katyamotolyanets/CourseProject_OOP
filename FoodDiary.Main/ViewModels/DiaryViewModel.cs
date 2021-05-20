using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class DiaryViewModel : BaseViewModel
    {
        public User CurrentAccount { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public LinkToAddCommand LinkToAddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public LinkToEditCommand LinkToEditCommand { get; set; }
        private ICollectionView _productSetCollectionView { get; set; }
        public ICollectionView ProductSetCollectionView
        {
            get { return _productSetCollectionView; }
            set
            {
                _productSetCollectionView = value;
                OnPropertyChanged(nameof(ProductSetCollectionView));
            }
        }
        private List<ProductSet> _productSets { get; set; }
        public List<ProductSet> ProductSets
        {
            get { return _productSets; }
            set
            {
                _productSets = value;
                OnPropertyChanged(nameof(ProductSets));
                RefreshProductSetCollectionView();
            }
        }

        private List<ProductSet> _breakfast { get; set; }
        public List<ProductSet> Breakfasts
        {
            get { return _breakfast; }
            set
            {
                _breakfast = value;
                OnPropertyChanged(nameof(Breakfasts));
            }
        }
        private List<ProductSet> _lunch { get; set; }
        public List<ProductSet> Lunches
        {
            get { return _lunch; }
            set
            {
                _lunch = value;
                OnPropertyChanged(nameof(Lunches));
            }
        }
        private List<ProductSet> _dinner { get; set; }
        public List<ProductSet> Dinners
        {
            get { return _dinner; }
            set
            {
                _dinner = value;
                OnPropertyChanged(nameof(Dinners));
            }
        }
        private List<ProductSet> _snack { get; set; }
        public List<ProductSet> Snacks
        {
            get { return _snack; }
            set
            {
                _snack = value;
                OnPropertyChanged(nameof(Snacks));
            }
        }

        public ProductSet ProductSet { get; set; }

        public DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(ProductSets));
                CheckHistory(Date);
            }
        }
        public List<UserHistory> Histories { get; set; }
        public List<UserHistory> UserHistories { get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public UserHistory History { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }

        public DiaryViewModel()
        {
            ProductSets = new List<ProductSet>();
            ProductSet = new ProductSet();
            CurrentAccount =  SingleCurrentAccount.GetInstance().Account;
            History = new UserHistory();
            Histories = new List<UserHistory>();
            UserHistories = new List<UserHistory>();

            UnitOfWork = new UnitOfWork();

            Breakfasts = new List<ProductSet>();
            Lunches = new List<ProductSet>();
            Dinners = new List<ProductSet>();
            Snacks = new List<ProductSet>();

            GetHistory(Date);
            BindProductSets();
            GetSets();
            RefreshMeals();

            ActivityTypes = new List<ActivityType>();
       
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            LinkToAddCommand = new LinkToAddCommand(this);
            LinkToEditCommand = new LinkToEditCommand(this);
            DeleteCommand = new DeleteCommand(this);
            EditCommand = new EditCommand(ProductSet);
            RefreshProductSetCollectionView();
            GetActivityTypes();
            //забиндить продактсеты к этой хистори
        }
        //проверка хистори на этот день, если нет, то создать
        public void CheckHistory(DateTime date)
        {
            History = UnitOfWork.HistoryRepository.GetByDate(date);
            if (History == null)
            {
                UserHistory history = new UserHistory();

                history.IDUser = CurrentAccount.ID;
                history.Date = date;
                history.ID = Guid.NewGuid();
                UnitOfWork.HistoryRepository.Create(history);
                List<MealType> mealTypes = new List<MealType>();
                mealTypes = (List<MealType>)UnitOfWork.MealTypesRepository.List();
                //заполнение четырёх продуктсетов
                List<ProductSet> productSets = new List<ProductSet>();

                foreach (MealType mealType in mealTypes)
                {
                    ProductSet productSet = new ProductSet();
                    productSet.ID = Guid.NewGuid();
                    productSet.IDType = mealType.ID;
                    UnitOfWork.ProductSetRepository.Create(productSet);
                    productSets.Add(productSet);
                }
                //заполнение промежуточной бд
                foreach(ProductSet ProductSet in productSets)
                {
                    UserHistoryProductSets userHistoryProductSets = new UserHistoryProductSets();

                    userHistoryProductSets.ID = Guid.NewGuid();
                    userHistoryProductSets.UserHistoryID = history.ID;
                    userHistoryProductSets.ProductSetID = ProductSet.ID;
                    UnitOfWork.UserHistoryProductSetsRepository.Create(userHistoryProductSets);
                    ProductSets.Add(ProductSet);
                }
                
            }
        }
        public void RefreshMeals()
        {
            GetBreakfasts();
            GetLunches();
            GetDinners();
            GetSnacks();
        }
        public void GetActivityTypes()
        {
            ActivityTypes = (List<ActivityType>)UnitOfWork.ActivityTypeRepository.List(); 
        }

        public void GetSets()
        {
            List<UserHistoryProductSets> UserHistoryProductSets = new List<UserHistoryProductSets>();
            UserHistoryProductSets = (List<UserHistoryProductSets>)UnitOfWork.UserHistoryProductSetsRepository.List(x => x.UserHistoryID == History.ID);
            foreach (UserHistoryProductSets userHistoryProductSet in UserHistoryProductSets)
            {
                ProductSets.Add(userHistoryProductSet.ProductSet);
            }
        }
        public void GetHistory(DateTime date) //преобразовать дату 
        {
            CheckHistory(date);
            History = UnitOfWork.HistoryRepository.GetByDate(date);
/*            Histories = (List<UserHistory>)HistoryRepository.List();
            UserHistories = Histories.Where(x => x.IDUser == CurrentAccount.ID).ToList();*/
        }
        public void BindProductSets()
        {
            List<UserHistoryProductSets> UserHistoryProductSets = new List<UserHistoryProductSets>();

            UserHistoryProductSets = (List<UserHistoryProductSets>)UnitOfWork.UserHistoryProductSetsRepository.List(x => x.UserHistoryID == History.ID);
            ProductSets = new List<ProductSet>();

            foreach (UserHistoryProductSets userHistoryProductSet in UserHistoryProductSets)
            {
                ProductSets.Add(userHistoryProductSet.ProductSet);// вохможно будет нулл
            }
        }

        public void GetBreakfasts()
        {
            Breakfasts = (List<ProductSet>)UnitOfWork.ProductSetRepository.List();
            Breakfasts = ProductSets.Where(x => x.MealType.MealName == "Завтрак").ToList();
        }
        public void GetLunches()
        {
            Lunches = (List<ProductSet>)UnitOfWork.ProductSetRepository.List();
            Lunches = ProductSets.Where(x => x.MealType.MealName == "Обед").ToList();
        }
        public void GetDinners()
        {
            Dinners = (List<ProductSet>)UnitOfWork.ProductSetRepository.List();
            Dinners = ProductSets.Where(x => x.MealType.MealName == "Ужин").ToList();

        }
        public void GetSnacks()
        {
            Snacks = (List<ProductSet>)UnitOfWork.ProductSetRepository.List();
            Snacks = ProductSets.Where(x => x.MealType.MealName == "Перекус/другое").ToList();
        }

        public class DateTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null)
                {
                    throw new NullReferenceException("value can not be null");
                }
                DateTime date = (DateTime)value;
                return date.ToString("MM/dd/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }

        public class MealTypeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                MealType mealtype = (MealType)value;

                if (value == null)
                {
                    return mealtype;
                }
                return mealtype;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
        public void RefreshProductSetCollectionView()
        {
            ProductSetCollectionView = CollectionViewSource.GetDefaultView(ProductSets);
            ProductSetCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(ProductSet.MealType), new MealTypeConverter()));
            ProductSetCollectionView.SortDescriptions.Add(new SortDescription("IDType", ListSortDirection.Descending));
            ProductSetCollectionView.Refresh();
        }





        //private RelayCommand showSnack;
        //public RelayCommand ShowSnackCommand
        //{
        //    get
        //    {
        //        return showSnack ?? (showSnack = new RelayCommand(obj =>
        //        {
        //            Snacks = (List<ProductSet>)ProductSetRepository.List();
        //            Snacks = Snacks.Where(x => x.MealType.ID == Guid.Parse("000205a2-e914-4469-853e-90eb8b17210d")).ToList();
        //        }));

        //    }
        //}
    }
}
