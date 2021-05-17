using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class User: Entity<Guid>
    {
        public string UserName { get; set; }
        public double UserWeight { get; set; }
        public double UserHeight { get; set; }
        public int UserAge { get; set; }
        public string UserSex { get; set; }
        public Guid IDLifestyle { get; set; }
        public UserLifestyle UserLifestyle { get; set; }
        public double UserCalories { get; set; }
        public string Password { get; set; }
        private string _photoSource { get; set; }
        public string PhotoSource
        {
            get { return _photoSource; }
            set
            {
                _photoSource = value;
                OnPropertyChanged(nameof(PhotoSource));
            }
        }
        public ICollection<UserHistory> UserHistories { get; set; }
        public ICollection<ChangeWeight> ChangesWeight { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
