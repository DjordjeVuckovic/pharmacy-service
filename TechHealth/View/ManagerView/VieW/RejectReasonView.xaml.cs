﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for RejectReasonView.xaml
    /// </summary>
    public partial class RejectReasonView : UserControl
    {
        public RejectReasonView()
        {
            InitializeComponent();
            //this.DataContext = new RejectReasonViewModel();
        }
    }
}
