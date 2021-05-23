﻿using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using FoodDiary.Infrastructure;

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
                CheckHistory(Date);
                if (ProductSetCollectionView != null)
                    RefreshProductSetCollectionView();
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
                RefreshProductSetCollectionView();
            }
        }
        public UnitOfWork UnitOfWork { get; set; }
        public UserHistory History { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }
        public List<ProductSetProducts> ProductSetProducts { get; set; }
        public ProductSetProducts ProductSetProduct { get; private set; }
        public List<Activity> Activities { get; set; }
        private int _caloriesBalance { get; set; }
        public int CaloriesBalance
        {
            get { return _caloriesBalance; }
            set
            {
                _caloriesBalance = value;
                OnPropertyChanged(nameof(CaloriesBalance));
                //RefreshProductSetCollectionView();
            }
        }
        private int _caloriesLeft { get; set; }
        public int CaloriesLeft
        {
            get { return _caloriesLeft; }
            set
            {
                _caloriesLeft = value;
                OnPropertyChanged(nameof(CaloriesLeft));
               // RefreshProductSetCollectionView();

            }
        }
        public DiaryViewModel()
        {
            History = new UserHistory();
            UnitOfWork = new UnitOfWork();
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;

            GetHistory(Date);

            CaloriesLeft = 0;
            CaloriesBalance = (int)CurrentAccount.UserCalories;

            ProductSets = new List<ProductSet>();
            ProductSetProducts = new List<ProductSetProducts>();
            ProductSet = new ProductSet();
            ProductSetProduct = new ProductSetProducts();

            Activities = new List<Activity>();

            BindProductSets();
            BindActivities();
            //GetCaloriesBalance();

            ActivityTypes = new List<ActivityType>();
       
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            LinkToAddCommand = new LinkToAddCommand(this);
            LinkToEditCommand = new LinkToEditCommand(this);
            DeleteCommand = new DeleteCommand(this);
            EditCommand = new EditCommand(ProductSetProduct);
            RefreshProductSetCollectionView();
            GetActivityTypes();
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

        public void GetCaloriesBalance()
        {
            ProductSetCollectionView.Refresh();
            ProductSetProducts = (List<ProductSetProducts>)UnitOfWork.ProductSetProductsRepository.List();
            foreach(ProductSetProducts productSetProducts in ProductSetProducts)
            {
                foreach(ProductSet productSet in ProductSets)
                {
                    if (productSetProducts.ProductSetID == productSet.ID)
                    {
                        CaloriesLeft += (int)(productSetProducts.ProductWeight / 100 * productSetProducts.Product.Calories);
                    }
                }
            }
            CaloriesBalance = (int)(CurrentAccount.UserCalories - CaloriesLeft);

        }
        public void GetActivityTypes()
        {
             ActivityTypes = (List<ActivityType>)UnitOfWork.ActivityTypeRepository.List(); 
        }

        public void GetHistory(DateTime date) 
        {
            CheckHistory(date);
            History = UnitOfWork.HistoryRepository.GetByDate(date);
        }

        public void BindProductSets()
        {
            List<UserHistoryProductSets> UserHistoryProductSets = new List<UserHistoryProductSets>();

            UserHistoryProductSets = (List<UserHistoryProductSets>)UnitOfWork.UserHistoryProductSetsRepository.List(x => x.UserHistoryID == History.ID);
            ProductSets = new List<ProductSet>();

            foreach (UserHistoryProductSets userHistoryProductSet in UserHistoryProductSets)
            {
                ProductSets.Add(userHistoryProductSet.ProductSet);
            }

            ProductSetProducts = new List<ProductSetProducts>();
            
            foreach (ProductSet productSet in ProductSets)
            {
                ProductSetProduct = new ProductSetProducts();
                ProductSetProduct.ID = Guid.NewGuid();
                ProductSetProduct.ProductSet = productSet;
                ProductSetProducts.Add(ProductSetProduct);

            }
        }

        public void BindActivities()
        {
            List<UserHistoryActivities> UserHistoryActivities = new List<UserHistoryActivities>();

            UserHistoryActivities = (List<UserHistoryActivities>)UnitOfWork.UserHistoryActivitiesRepository.List(x => x.UserHistoryID == History.ID);

            Activities = new List<Activity>();

            foreach (UserHistoryActivities userHistoryActivities in UserHistoryActivities)
            {
                Activities.Add(userHistoryActivities.Activity);
            }
        }

        public IEnumerable<Product> Products { get; set; }
        public void RefreshProductSetCollectionView()
        {
            using (FoodDiaryContext db = new FoodDiaryContext())
            {
                var result = (from history in db.UsersHistories
                              join historySets in db.UserHistoryProductSets on history.ID equals historySets.UserHistoryID into hist
                              from h in hist.DefaultIfEmpty()
                              join sets in db.ProductSets on h.ProductSetID equals sets.ID into set
                              from s in set.DefaultIfEmpty()
                              join setsProducts in db.ProductSetProducts on s.ID equals setsProducts.ProductSetID into prodS
                              from p in prodS.DefaultIfEmpty()
                              join product in db.Products on p.ProductID equals product.ID into prod
                              from pr in prod.DefaultIfEmpty()
                              join mealType in db.MealTypes on s.IDType equals mealType.ID 
                              select new
                                {
                                  ProductSetProducts = p,
                                  ProductID = pr.ID,
                                  ProductName = pr.NameProduct,
                                  ProductSetID = s.ID,
                                  MealType = s.MealType,
                                  HistoryID = history.ID,
                                  Weight = p.ProductWeight
                              }).Where(x => x.HistoryID == History.ID).ToList();
                ProductSetCollectionView = CollectionViewSource.GetDefaultView(result);
                ProductSetCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(("MealType")));
                ProductSetCollectionView.Refresh();
               
            }
            ProductSetCollectionView.Refresh();
            GetCaloriesBalance();
        }
    }
}
