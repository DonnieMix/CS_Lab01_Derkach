using System;
using System.Windows;
using System.Windows.Controls;
using Lab01_Derkach.Views;

namespace Lab01_Derkach.ViewModels
{
    class CalendarViewModel
    {
        private readonly CalendarView _calendarView;

        public CalendarView CalendarView
        {
            get => _calendarView;
        }

        public CalendarViewModel(CalendarView view)
        {
            this._calendarView = view;
        }

        public void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
            if (date != null)
            {
                showStatistics(picker);
            }
        }

        public void showStatistics(DatePicker picker)
        {
            try
            {
                string age = CalculateAge(picker.SelectedDate.Value).ToString();
                if (int.Parse(age) >= 135) throw new System.ArgumentOutOfRangeException();
                CalendarView.LAge.Visibility = Visibility.Visible;
                CalendarView.TbAge.Visibility = Visibility.Visible;
                CalendarView.TbAge.Text = age;
                if (picker.SelectedDate.Value.Day != DateTime.Now.Day ||
                    picker.SelectedDate.Value.Month != DateTime.Now.Month)
                {
                    CalendarView.LHappyBirthday.Visibility = Visibility.Hidden;
                }
                else
                {
                    CalendarView.LHappyBirthday.Visibility = Visibility.Visible;
                }

                CalendarView.LWestZodiac.Visibility = Visibility.Visible;
                CalendarView.TbWestZodiac.Visibility = Visibility.Visible;
                CalendarView.LChineseZodiac.Visibility = Visibility.Visible;
                CalendarView.TbChineseZodiac.Visibility = Visibility.Visible;
                switch (picker.SelectedDate.Value.Month)
                {
                    case 1: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 20) ? "Capricorn" : "Aquarius"; break;
                    case 2: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 19) ? "Aquarius" : "Pisces"; break;
                    case 3: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 20) ? "Pisces" : "Aries"; break;
                    case 4: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 20) ? "Aries" : "Taurus"; break;
                    case 5: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 21) ? "Taurus" : "Gemini"; break;
                    case 6: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 21) ? "Gemini" : "Cancer"; break;
                    case 7: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 22) ? "Cancer" : "Leo"; break;
                    case 8: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 23) ? "Leo" : "Virgo"; break;
                    case 9: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 23) ? "Virgo" : "Libra"; break;
                    case 10: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 23) ? "Libra" : "Scorpio"; break;
                    case 11: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 22) ? "Scorpio" : "Sagittarius"; break;
                    case 12: CalendarView.TbWestZodiac.Text = (picker.SelectedDate.Value.Day <= 23) ? "Sagittarius" : "Capricorn"; break;
                }
                switch (picker.SelectedDate.Value.Year % 12)
                {
                    case 0: CalendarView.TbChineseZodiac.Text = "Monkey"; break;
                    case 1: CalendarView.TbChineseZodiac.Text = "Rooster"; break;
                    case 2: CalendarView.TbChineseZodiac.Text = "Dog"; break;
                    case 3: CalendarView.TbChineseZodiac.Text = "Pig"; break;
                    case 4: CalendarView.TbChineseZodiac.Text = "Rat"; break;
                    case 5: CalendarView.TbChineseZodiac.Text = "Bull"; break;
                    case 6: CalendarView.TbChineseZodiac.Text = "Tiger"; break;
                    case 7: CalendarView.TbChineseZodiac.Text = "Rabbit"; break;
                    case 8: CalendarView.TbChineseZodiac.Text = "Dragon"; break;
                    case 9: CalendarView.TbChineseZodiac.Text = "Snake"; break;
                    case 10: CalendarView.TbChineseZodiac.Text = "Horse"; break;
                    case 11: CalendarView.TbChineseZodiac.Text = "Goat"; break;
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                MessageBox.Show("Write your real date of birth!");
                picker.SelectedDate = null;
                CalendarView.LAge.Visibility = Visibility.Hidden;
                CalendarView.TbAge.Visibility = Visibility.Hidden;
                CalendarView.LHappyBirthday.Visibility = Visibility.Hidden;
                CalendarView.LWestZodiac.Visibility = Visibility.Hidden;
                CalendarView.TbWestZodiac.Visibility = Visibility.Hidden;
                CalendarView.LChineseZodiac.Visibility = Visibility.Hidden;
                CalendarView.TbChineseZodiac.Visibility = Visibility.Hidden;
            }
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            return new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
        }
    }
}
