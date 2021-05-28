using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Infrastructure;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodDiary.Main
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            InsertData();
            //SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            //currentAccount.Account = new AccountRepository().GetByName("katya");
            base.OnStartup(e);
        }
        public void InsertData()
        {
            MealTypesRepository mealTypesRepository = new MealTypesRepository();
            List<MealType> meals = new List<MealType>();
            meals = (List<MealType>)mealTypesRepository.List();
            if (meals.Count == 0)
            {
                MealType breakfast = new MealType() { ID = Guid.Parse("11111111-1111-1111-1111-111111111111"), MealName = "Завтрак" };
                mealTypesRepository.Create(breakfast);
                MealType lunch = new MealType() { ID = Guid.Parse("22222222-2222-2222-2222-222222222222"), MealName = "Обед" };
                mealTypesRepository.Create(lunch);
                MealType dinner = new MealType() { ID = Guid.Parse("33333333-3333-3333-3333-333333333333"), MealName = "Ужин" };
                mealTypesRepository.Create(dinner);
                MealType snack = new MealType() { ID = Guid.Parse("44444444-4444-4444-4444-444444444444"), MealName = "Перекус/другое" };
                mealTypesRepository.Create(snack);
            }
            ActivityTypeRepository activityTypeRepository = new ActivityTypeRepository();
            List<ActivityType> activityTypes = new List<ActivityType>();
            activityTypes = (List<ActivityType>)activityTypeRepository.List();
            if (activityTypes.Count == 0)
            {
                ActivityType activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Сон", ActivityCalories = 55.75, IconSource = @"..\Assets\Exercises\sleep.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Бег трусцой (8 км/час)", ActivityCalories = 496, IconSource = @"..\Assets\Exercises\jogging.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Отжимания", ActivityCalories = 496, IconSource = @"..\Assets\Exercises\pushUp.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Езда на велосипеде", ActivityCalories = 352, IconSource = @"..\Assets\Exercises\bycicle.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Бадминтон", ActivityCalories = 303, IconSource = @"..\Assets\Exercises\badminton.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Баскетбол", ActivityCalories = 330, IconSource = @"..\Assets\Exercises\basketball.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Альпинизм", ActivityCalories = 319, IconSource = @"..\Assets\Exercises\mountain.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Аквааэробика", ActivityCalories = 292, IconSource = @"..\Assets\Exercises\wAerobics.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Йога", ActivityCalories = 149, IconSource = @"..\Assets\Exercises\yoga.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Пеший туризм", ActivityCalories = 237, IconSource = @"..\Assets\Exercises\hiking.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Ходьба", ActivityCalories = 237, IconSource = @"..\Assets\Exercises\walking.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Силовая тренировка", ActivityCalories = 330, IconSource = @"..\Assets\Exercises\arm.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Биатлон", ActivityCalories = 550, IconSource = @"..\Assets\Exercises\biathlon.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Плавание", ActivityCalories = 319, IconSource = @"..\Assets\Exercises\swimming.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Бейсбол", ActivityCalories = 138, IconSource = @"..\Assets\Exercises\baseball.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Бокс, спарринг", ActivityCalories = 429, IconSource = @"..\Assets\Exercises\boxing.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Бокс с боксёрской грушей", ActivityCalories = 303, IconSource = @"..\Assets\Exercises\boxing2.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Верховая езда", ActivityCalories = 303, IconSource = @"..\Assets\Exercises\horseback.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Волейбол", ActivityCalories = 165, IconSource = @"..\Assets\Exercises\volleyball.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Гандбол", ActivityCalories = 440, IconSource = @"..\Assets\Exercises\handball.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Гимнастика", ActivityCalories = 209, IconSource = @"..\Assets\Exercises\gymnastics.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Гребля", ActivityCalories = 154, IconSource = @"..\Assets\Exercises\rowing.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Гребля быстрая", ActivityCalories = 319, IconSource = @"..\Assets\Exercises\rowing.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Дайвинг", ActivityCalories = 385, IconSource = @"..\Assets\Exercises\diving.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Дартс", ActivityCalories = 220, IconSource = @"..\Assets\Exercises\darts.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Каратэ", ActivityCalories = 292, IconSource = @"..\Assets\Exercises\karate.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Катание на роликах", ActivityCalories = 462, IconSource = @"..\Assets\Exercises\rollerSkating.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Пилатес", ActivityCalories = 165, IconSource = @"..\Assets\Exercises\pilates.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Планка", ActivityCalories = 209, IconSource = @"..\Assets\Exercises\plank.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Подъём по лестнице", ActivityCalories = 495, IconSource = @"..\Assets\Exercises\stairs.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Подтягивания", ActivityCalories = 193, IconSource = @"..\Assets\Exercises\pullUp.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Приседания", ActivityCalories = 275, IconSource = @"..\Assets\Exercises\squat.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Прогулка с собакой", ActivityCalories = 193, IconSource = @"..\Assets\Exercises\dogWalk.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Разгибание рук", ActivityCalories = 330, IconSource = @"..\Assets\Exercises\arm.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Скандинавская ходьба", ActivityCalories = 264, IconSource = @"..\Assets\Exercises\nordicWalk.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Скручивания", ActivityCalories = 193, IconSource = @"..\Assets\Exercises\twisting.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Теннис", ActivityCalories = 402, IconSource = @"..\Assets\Exercises\tennis.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Фехтование", ActivityCalories = 330, IconSource = @"..\Assets\Exercises\fencing.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Фигурное катание", ActivityCalories = 303, IconSource = @"..\Assets\Exercises\figureSkating.png" };
                activityTypeRepository.Create(activityType);
                activityType = new ActivityType() { ID = Guid.NewGuid(), ActivityName = "Футбол", ActivityCalories = 385, IconSource = @"..\Assets\Exercises\football.png" };
                activityTypeRepository.Create(activityType);
            }

            ProductsRepository productsRepository = new ProductsRepository();
            List<Product> products = new List<Product>();
            products = (List<Product>)productsRepository.List();
            if (products.Count == 0)
            {
                Product product = new Product();
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Брынза", EnergyValue = 1042, Calories = 249, Proteins = 21.05, Fats = 18.22, Carbohydrates = 0.2, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Сулугуни", EnergyValue = 1178, Calories = 282, Proteins = 20.33, Fats = 22.07, Carbohydrates = 0.24, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Пармезан", EnergyValue = 1640, Calories = 392, Proteins = 35.75, Fats = 25.83, Carbohydrates = 3.22, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Гауда", EnergyValue = 1490, Calories = 356, Proteins = 24.94, Fats = 27.44, Carbohydrates = 2.22, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Российский", EnergyValue = 1508, Calories = 360, Proteins = 25.35, Fats = 29.27, Carbohydrates = 0.91, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Маасдам", EnergyValue = 1455, Calories = 348, Proteins = 24.85, Fats = 26.95, Carbohydrates = 1.13, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Голландский", EnergyValue = 1464, Calories = 350, Proteins = 2.75, Fats = 26.8, Carbohydrates = 1.13, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Камамбер", EnergyValue = 1255, Calories = 300, Proteins = 19.8, Fats = 24.26, Carbohydrates = 0.46, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр Фета", EnergyValue = 1105, Calories = 264, Proteins = 14.21, Fats = 21.28, Carbohydrates = 4.09, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сыр творожный", EnergyValue = 1135, Calories = 271, Proteins = 7, Fats = 25.7, Carbohydrates = 3, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Плавленный сыр", EnergyValue = 1038, Calories = 248, Proteins = 9.57, Fats = 22.34, Carbohydrates = 2.85, IconSource = @"..\Assets\Products\cheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творожная запеканка", EnergyValue = 544, Calories = 130, Proteins = 12.01, Fats = 4.32, Carbohydrates = 10.24, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творожная запеканка с манкой", EnergyValue = 568, Calories = 136, Proteins = 12.06, Fats = 4.32, Carbohydrates = 11.61, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творожная запеканка с изюмом", EnergyValue = 665, Calories = 159, Proteins = 10.53, Fats = 4.12, Carbohydrates = 20.69, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Диетическая творожная запеканка", EnergyValue = 387, Calories = 92, Proteins = 11.39, Fats = 2.37, Carbohydrates = 5.78, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творожная запеканка с яблоками", EnergyValue = 528, Calories = 126, Proteins = 10.26, Fats = 4.08, Carbohydrates = 11.96, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Овощная запеканка", EnergyValue = 304, Calories = 73, Proteins = 4.97, Fats = 3.15, Carbohydrates = 6.83, IconSource = @"..\Assets\Products\casserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Запеканка с Рикоттой", EnergyValue = 619, Calories = 148, Proteins = 10.38, Fats = 7.57, Carbohydrates = 9.34, IconSource = @"..\Assets\Products\cheeseCasserole.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Макароны отварные", EnergyValue = 429, Calories = 103, Proteins = 3.77, Fats = 0.6, Carbohydrates = 20.04, IconSource = @"..\Assets\Products\pasta.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Макароны по-флотски", EnergyValue = 814, Calories = 195, Proteins = 7.16, Fats = 9, Carbohydrates = 21.25, IconSource = @"..\Assets\Products\pasta.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Фасолевый суп", EnergyValue = 226, Calories = 54, Proteins = 2.6, Fats = 1.58, Carbohydrates = 7.6, IconSource = @"..\Assets\Products\soupSh.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Рассольник", EnergyValue = 168, Calories = 40, Proteins = 1.15, Fats = 1.55, Carbohydrates = 5.75, IconSource = @"..\Assets\Products\soupChicken.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Грибной суп", EnergyValue = 222, Calories = 53, Proteins = 0.95, Fats = 3.68, Carbohydrates = 3.81, IconSource = @"..\Assets\Products\soupMashroom.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Куриный суп", EnergyValue = 130, Calories = 31, Proteins = 1.68, Fats = 1.02, Carbohydrates = 3.88, IconSource = @"..\Assets\Products\soupChicken.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Борщ", EnergyValue = 134, Calories = 32, Proteins = 1.37, Fats = 1.64, Carbohydrates = 3.37, IconSource = @"..\Assets\Products\soupBorsch.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творог 1%", EnergyValue = 360, Calories = 86, Proteins = 18, Fats = 1, Carbohydrates = 1.3, IconSource = @"..\Assets\Products\cottageCheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творог 3%", EnergyValue = 421, Calories = 101, Proteins = 17, Fats = 3, Carbohydrates = 1.04, IconSource = @"..\Assets\Products\cottageCheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творог 5%", EnergyValue = 490, Calories = 117, Proteins = 16.5, Fats = 5, Carbohydrates = 1.5, IconSource = @"..\Assets\Products\cottageCheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Творог 9%", EnergyValue = 615, Calories = 147, Proteins = 15, Fats = 9, Carbohydrates = 1.5, IconSource = @"..\Assets\Products\cottageCheese.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Сырники", EnergyValue = 734, Calories = 175, Proteins = 14.44, Fats = 7.98, Carbohydrates = 11.5, IconSource = @"..\Assets\Products\vareniki.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Зелёное яблоко", EnergyValue = 217, Calories = 52, Proteins = 0.26, Fats = 0.17, Carbohydrates = 13.78, IconSource = @"..\Assets\Products\appleG.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Красное яблоко", EnergyValue = 198, Calories = 47, Proteins = 0.24, Fats = 0.15, Carbohydrates = 12.55, IconSource = @"..\Assets\Products\appleR.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Банан", EnergyValue = 372, Calories = 89, Proteins = 1.09, Fats = 0.33, Carbohydrates = 22.84, IconSource = @"..\Assets\Products\banana.png" };
                productsRepository.Create(product);
                product = new Product() { ID = Guid.NewGuid(), NameProduct = "Варёная куриная грудка", EnergyValue = 564, Calories = 135, Proteins = 2.08, Fats = 4, Carbohydrates = 0, IconSource = @"..\Assets\Products\chicken.png" };
                productsRepository.Create(product);
            }

            LifestyleRepository lifestyleRepository = new LifestyleRepository();
            List<UserLifestyle> lifestyles = new List<UserLifestyle>();
            lifestyles = (List<UserLifestyle>)lifestyleRepository.List();
            if (lifestyles.Count == 0)
            {
                UserLifestyle userLifestyle = new UserLifestyle();
                userLifestyle = new UserLifestyle() { ID = Guid.Parse("11111111-1111-1111-1111-111111111111"), LifestyleName = "Сидячий, без нагрузок", Coefficient = 1.2 };
                lifestyleRepository.Create(userLifestyle);
                userLifestyle = new UserLifestyle() { ID = Guid.Parse("22222222-2222-2222-2222-222222222222"), LifestyleName = "Тренировки 1-3 раза в неделю", Coefficient = 1.375 };
                lifestyleRepository.Create(userLifestyle);
                userLifestyle = new UserLifestyle() { ID = Guid.Parse("33333333-3333-3333-3333-333333333333"), LifestyleName = "Занятия 3-5 дней в неделю", Coefficient = 1.55 };
                lifestyleRepository.Create(userLifestyle);
                userLifestyle = new UserLifestyle() { ID = Guid.Parse("44444444-4444-4444-4444-444444444444"), LifestyleName = "Итенсивные тренировки(6-7 в неделю)", Coefficient = 1.725 };
                lifestyleRepository.Create(userLifestyle);
                userLifestyle = new UserLifestyle() { ID = Guid.Parse("55555555-5555-5555-5555-555555555555"), LifestyleName = "Упражнения чаще, чем раз в день", Coefficient = 1.9 };
                lifestyleRepository.Create(userLifestyle);
            }
        }
    }
}

