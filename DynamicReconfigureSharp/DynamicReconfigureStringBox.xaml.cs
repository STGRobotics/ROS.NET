﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DynamicReconfigure;
using Messages.dynamic_reconfigure;

namespace DynamicReconfigureSharp
{
    /// <summary>
    /// Interaction logic for DynamicReconfigureStringDropdown.xaml
    /// </summary>
    public partial class DynamicReconfigureStringBox : UserControl
    {
        private DynamicReconfigureInterface dynamic;
        private string name;
        private string def;
        private bool ignore = true;

        public DynamicReconfigureStringBox(DynamicReconfigureInterface dynamic, ParamDescription pd, string def)
        {
            this.def = def;
            name = pd.name.data;
            this.dynamic = dynamic;
            InitializeComponent();
            description.Content = name;
            JustTheTip.Content = pd.description.data;
            dynamic.Subscribe(name, changed);
            ignore = false;
        }

        private void changed(string newstate)
        {
            ignore = true;
            Dispatcher.Invoke(new Action(() => Box.Text = newstate));
            ignore = false;
        }

        private void commit()
        {
            dynamic.Set(name, Box.Text);
        }

        private void Box_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                commit();
        }

        private void Box_OnLostFocus(object sender, RoutedEventArgs e)
        {
            commit();
        }
    }
}
