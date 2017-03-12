using System;
using System.Windows.Forms;

namespace LabForms1
{
    public class Carriage
    {
        #region Блок данних
        // Приватні поля - характеристики вагона
        private string type;
        private int number;

        // Масив значень, що відповідають типу вагону
        private readonly string[] CarriageType = new[]
        {
            "Вантажний",
            "Пасажирський"
        };

        // Попередній вагон
        public Carriage Previous;
        #endregion

        #region Конструктори
        /// <summary>
        /// Конструктор створює об'єкт вагона із довільним типом
        /// </summary>
        public Carriage()
        {
            SetType();
        }

        /// <summary>
        /// Конструктор створює об'єкт вагона із вказаним типом
        /// </summary>
        /// <param name="atype"></param>
        public Carriage(string atype)
        {
            if (atype != "")
            {
                if (atype.Contains(CarriageType[0]) || atype.Contains(CarriageType[1])) SetType(atype);
                else
                {
                    MessageBox.Show("Введенного типу \"" + atype + "\" не існує в базі\nТип буде задано автоматично");
                    SetType();
                }
            }
            else SetType();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Метод повертає тип вагона
        /// </summary>
        /// <returns>Змінна типу string</returns>
        public string GetTypeValue()
        {
            return type;
        }

        /// <summary>
        /// Метод задає номер вагона
        /// </summary>
        /// <param name="index">Змінна типу int</param>
        public void SetNumber(int index)
        {
            number = index;
        }

        /// <summary>
        /// Метод повертає номер вагона
        /// </summary>
        /// <returns>Змінна типу int</returns>
        public int GetNumber()
        {
            return number;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Метод задає тип вагона випадково
        /// </summary>
        private void SetType()
        {
            Random rand = new Random();

            type = CarriageType[rand.Next(0, 2)];
        }

        /// <summary>
        /// Метод задає тип вагона вказаним в аргументі \atype\
        /// </summary>
        /// <param name="atype">Змінна типу string - тип вагона</param>
        private void SetType(string atype)
        {
            if (atype.Contains("Вантажний")) type = CarriageType[0];
            else type = CarriageType[1];
        }
        #endregion

        ~Carriage()
        {

        }
    }
}
