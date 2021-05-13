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
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public LinkToAddCommand LinkToAddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public LinkToEditCommand LinkToEditCommand { get; set; }
        public ProductSetRepository ProductSetRepository { get; set; }

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
                GetSets();
                RefreshMeals();
            }
        }
        public User CurrentAccount { get; set; }
        public List<UserHistory> Histories { get; set; }
        public List<UserHistory> UserHistories { get; set; }
        public HistoryRepository HistoryRepository { get; set; }
        public UserHistory History { get; set; }
        public DiaryViewModel()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            ProductSets = new List<ProductSet>();
            ProductSetRepository = new ProductSetRepository();
            ProductSet = new ProductSet();

            History = new UserHistory();
            Histories = new List<UserHistory>();
            UserHistories = new List<UserHistory>();
            HistoryRepository = new HistoryRepository();

            Breakfasts = new List<ProductSet>();
            Lunches = new List<ProductSet>();
            Dinners = new List<ProductSet>();
            Snacks = new List<ProductSet>();

            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            LinkToAddCommand = new LinkToAddCommand(this);
            LinkToEditCommand = new LinkToEditCommand(this);
            DeleteCommand = new DeleteCommand(this);
            EditCommand = new EditCommand(ProductSet);

            GetSets();
            GetHistories();
            RefreshMeals();
        }

        public void RefreshMeals()
        {
            GetBreakfasts();
            GetLunches();
            GetDinners();
            GetSnacks();
        }

        public void GetSets()
        {
            ProductSets = (List<ProductSet>)ProductSetRepository.List();
        }
        public void GetHistories()
        {
            Histories = (List<UserHistory>)HistoryRepository.List();
            UserHistories = Histories.Where(x => x.IDUser == CurrentAccount.ID).ToList();
        }
        public void GetBreakfasts()
        {
            Breakfasts = (List<ProductSet>)ProductSetRepository.List();
            if (UserHistories.Count != 0)
                foreach (UserHistory history in UserHistories)
                    Breakfasts = ProductSets.Where(x => x.MealType.MealName == "Завтрак" && x.Date.ToString("MM/dd/yyyy") == Date.ToString("MM/dd/yyyy") && x.ID == history.IDProductSet).ToList();
            else
                Breakfasts = null;
        }
        public void GetLunches()
        {
            Lunches = (List<ProductSet>)ProductSetRepository.List();
            if (UserHistories.Count != 0)
                foreach (UserHistory history in UserHistories)
                    Lunches = ProductSets.Where(x => x.MealType.MealName == "Обед" && x.Date.ToString("MM/dd/yyyy") == Date.ToString("MM/dd/yyyy") && x.ID == history.IDProductSet).ToList();
            else
                Lunches = null;
        }
        public void GetDinners()
        {
            Dinners = (List<ProductSet>)ProductSetRepository.List();
            if (UserHistories.Count != 0)
                foreach (UserHistory history in UserHistories)
                    Dinners = ProductSets.Where(x => x.MealType.MealName == "Ужин" && x.Date.ToString("MM/dd/yyyy") == Date.ToString("MM/dd/yyyy") && x.ID == history.IDProductSet).ToList();
             else
                Dinners = null;
        }
        public void GetSnacks()
        {
            Snacks = (List<ProductSet>)ProductSetRepository.List();
            if (UserHistories.Count != 0)
                foreach (UserHistory history in UserHistories)
                    Snacks = Snacks.Where(x => x.MealType.MealName == "Перекус/другое" && x.Date.ToString("MM/dd/yyyy") == Date.ToString("MM/dd/yyyy") && x.ID == history.IDProductSet).ToList();
             else
                Snacks = null;
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
