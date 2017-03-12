using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabForms1
{
    public partial class SortForm : Form
    {
        public SortForm()
        {
            InitializeComponent();
        }

        public void UpdateList(Stack first, Stack second)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();

            Carriage carriage = first.GetLast();

            while (carriage != null)
            {
                listView1.Items.Add(carriage.GetNumber() + " вагон").SubItems.AddRange(new[]
                {
                    carriage.GetTypeValue()
                });

                carriage = carriage.Previous;
            }

            carriage = second.GetLast();

            while (carriage != null)
            {
                listView2.Items.Add(carriage.GetNumber() + " вагон").SubItems.AddRange(new[]
                {
                    carriage.GetTypeValue()
                });

                carriage = carriage.Previous;
            }
        }
    }
}
