using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Main.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public UnitOfWork UnitOfWork { get; set; }
        public DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(ProductSets));
                CheckHistory(Date);
                GetSets();
            }
        }
     
        private ChartValues<int> _breakfastCal { get; set; }
        public ChartValues<int> BreakfastCal
        {
            get { return _breakfastCal; }
            set
            {
                _breakfastCal = value;
                OnPropertyChanged(nameof(BreakfastCal));
            }
        }
        private ChartValues<int> _lunchCal { get; set; }
        public ChartValues<int> LunchCal
        {
            get { return _lunchCal; }
            set
            {
                _lunchCal = value;
                OnPropertyChanged(nameof(LunchCal));
            }
        }
        private ChartValues<int> _dinnerCal { get; set; }
        public ChartValues<int> DinnerCal
        {
            get { return _dinnerCal; }
            set
            {
                _dinnerCal = value;
                OnPropertyChanged(nameof(DinnerCal));
            }
        }
        private ChartValues<int> _snackCal { get; set; }
        public ChartValues<int> SnackCal
        {
            get { return _snackCal; }
            set
            {
                _snackCal = value;
                OnPropertyChanged(nameof(SnackCal));
            }
        }
        public int breakfast { get; set; }
        public int lunch { get; set; }
        public int dinner { get; set; }
        public int snack { get; set; }
        public UserHistory History { get; set; }
        public User CurrentAccount { get; set; }
        private List<ProductSet> _productSets { get; set; }
        public List<ProductSet> ProductSets
        {
            get { return _productSets; }
            set
            {
                _productSets = value;
                OnPropertyChanged(nameof(ProductSets));
                CheckHistory(Date);

            }
        }
        public List<ProductSetProducts> ProductSetProducts { get; set; }
        public List<UserHistoryProductSets> UserHistoryProductSets { get; set; }
        public ReportsViewModel()
        {
            UnitOfWork = new UnitOfWork();
            History = new UserHistory();
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;
            GetHistory(Date);
            UnitOfWork = new UnitOfWork();
            ProductSets = new List<ProductSet>();
            ProductSetProducts = new List<ProductSetProducts>();
            UserHistoryProductSets = new List<UserHistoryProductSets>();
            BreakfastCal = new ChartValues<int> { 0 };
            LunchCal = new ChartValues<int>{ 0 };
            DinnerCal = new ChartValues<int> { 0 };
            SnackCal = new ChartValues<int> { 0 };
            GetSets();


        }
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
                History = history;
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
                foreach (ProductSet ProductSet in productSets)
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
        public void GetHistory(DateTime date)
        {
            CheckHistory(date);
            History = UnitOfWork.HistoryRepository.GetByDate(date);
        }
        public void GetSets()
        {
            GetHistory(Date);
            BreakfastCal.Clear();
            LunchCal.Clear();
            DinnerCal.Clear();
            SnackCal.Clear();
            breakfast = 0;
            lunch = 0;
            dinner = 0;
            snack = 0;
            
            List<ProductSetProducts> ProductSetProducts = new List<ProductSetProducts>();
            ProductSetProducts = (List<ProductSetProducts>)UnitOfWork.ProductSetProductsRepository.List();

            List<UserHistoryProductSets> UserHistoryProductSets = new List<UserHistoryProductSets>();
            UserHistoryProductSets = (List<UserHistoryProductSets>)UnitOfWork.UserHistoryProductSetsRepository.List(x => x.UserHistoryID == History.ID);
            foreach (UserHistoryProductSets userHistoryProductSets in UserHistoryProductSets)
            {
                foreach (ProductSetProducts productSetProducts in ProductSetProducts)
                {
                    if (userHistoryProductSets.ProductSetID == productSetProducts.ProductSetID && productSetProducts.ProductSet.MealType.MealName == "Завтрак")
                    {
                        BreakfastCal.Clear();
                        breakfast += (int)(productSetProducts.Product.Calories / 100 * productSetProducts.ProductWeight);
                    }
                    else if (userHistoryProductSets.ProductSetID == productSetProducts.ProductSetID && productSetProducts.ProductSet.MealType.MealName == "Обед")
                    {
                        LunchCal.Clear();
                        lunch += (int)(productSetProducts.Product.Calories / 100 * productSetProducts.ProductWeight);
                    }
                    else if (userHistoryProductSets.ProductSetID == productSetProducts.ProductSetID && productSetProducts.ProductSet.MealType.MealName == "Ужин")
                    {
                        DinnerCal.Clear();
                        dinner += (int)(productSetProducts.Product.Calories / 100 * productSetProducts.ProductWeight);
                    }
                    else if (userHistoryProductSets.ProductSetID == productSetProducts.ProductSetID && productSetProducts.ProductSet.MealType.MealName == "Перекус/другое")
                    {
                        SnackCal.Clear();
                        snack += (int)(productSetProducts.Product.Calories / 100 * productSetProducts.ProductWeight);
                    }

                }
            }
            BreakfastCal.Add(breakfast);
            LunchCal.Add(lunch);
            DinnerCal.Add(dinner);
            SnackCal.Add(snack);

        }
    }
}
