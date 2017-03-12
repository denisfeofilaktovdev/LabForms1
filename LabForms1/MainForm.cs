using System;
using System.Windows.Forms;

namespace LabForms1
{
    public partial class MainForm : Form
    {
        private Stack Train = new Stack();

        private Stack First;
        private Stack Second;

        public MainForm()
        {
            InitializeComponent();
        }

        // Додати вагон у головний стек
        private void AddEvent(object sender, EventArgs e)
        {
            if (txtType.Text != "")
            {
                Train.Add(txtType.Text);
            }
            else
            {
                Train.Add();
            }

            UpdateList(Train);
        }

        // Оновити інформацію про вагони в головному потязі
        private void UpdateList(Stack stack)
        {
            listView1.Items.Clear();

            Carriage carriage = stack.GetLast();

            while (carriage != null)
            {
                listView1.Items.Add(carriage.GetNumber() + " вагон").SubItems.AddRange(new[]
                {
                    carriage.GetTypeValue()
                });

                carriage = carriage.Previous;
            }

            txtType.Text = "";
            txtCount.Text = stack.Count.ToString();
        }

        // Видалити останній вагон головного потягу
        private void DeleteEvent(object sender, EventArgs e)
        {
            Train.RemoveLast();
            UpdateList(Train);
        }

        // Сортувати вагони за типом і відобразити інформацію
        private void SortEvent(object sender, EventArgs e)
        {
            Carriage carriage = Train.GetLast();
            First = new Stack();
            Second = new Stack();

            while (carriage != null)
            {
                if (carriage.GetTypeValue() == "Пасажирський")
                {
                    First.Add(carriage.GetTypeValue());
                    First.GetLast().SetNumber(carriage.GetNumber());
                }

                else if (carriage.GetTypeValue() == "Вантажний")
                {
                    Second.Add(carriage.GetTypeValue());
                    Second.GetLast().SetNumber(carriage.GetNumber());
                }

                carriage = carriage.Previous;
            }

            SortForm sort = new SortForm();
            sort.UpdateList(First, Second);
            sort.ShowDialog();
            sort.Dispose();
        }
    }
}
