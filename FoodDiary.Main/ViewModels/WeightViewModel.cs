using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Main.ViewModels
{
    public class WeightViewModel : BaseViewModel
    {
        public List<ChangeWeight> ChangesWeight { get; set; }
        public ChangeWeightRepository ChangeWeightRepository { get; set; }
        private int _lastChange { get; set; }
        public int LastChange
        {
            get
            {
                return _lastChange;
            }
            set
            {
                _lastChange = value;
                OnPropertyChanged(nameof(LastChange));
            }
        }
        
        public int FirstWeight { get; set; }
        public WeightViewModel()
        {
            ChangesWeight = new List<ChangeWeight>();
            ChangeWeightRepository = new ChangeWeightRepository();

            GetChanges();

            LastChange = (int)ChangesWeight.Last().UserWeight;
            FirstWeight = (int)ChangesWeight.First().UserWeight;


        }
        public void GetChanges()
        {
            ChangesWeight = (List<ChangeWeight>)ChangeWeightRepository.List();
        }
    }
}
