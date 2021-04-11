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

namespace milestone1
{
    /// <summary>
    /// Interaction logic for noa.xaml
    /// </summary>
    public partial class noa : UserControl
    {
        private FlightGearViewModel vm;
        string path;
        volatile Boolean playFlag;
        volatile Boolean stopFlag;

        public noa()
        {
            InitializeComponent();
            vm = new FlightGearViewModel(new MyFlightGearModel(new MyTelnetClient()));
            DataContext = vm;
            playFlag = false;
            stopFlag = false;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);

        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (stopFlag)
            {
                vm = null;
                // creating new instance of vm
                vm = new FlightGearViewModel(new MyFlightGearModel(new MyTelnetClient()));
                DataContext = vm;
                playFlag = false;
                stopFlag = false;
                vm.VM_connect("localhost", 5400);
                vm.VM_start(path);
                playFlag = true;
            }

            else if (!playFlag)
            {
                vm.VM_connect("localhost", 5400);
                vm.VM_start(path);
                playFlag = true;
            }
            else // pauseFlag is pressed
            {
                vm.VM_resume();
            }
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_pause();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            stopFlag = true;
            vm.VM_stop();
        }

        private void goRight_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goRight();

        }

        private void goLeft_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goLeft();
        }

        private void goToEnd_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goToEnd();
        }

        private void goToStart_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goToStart();
        }

        private void LabelplaySpeed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SimulatorSpeed_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double newSpeed = Convert.ToDouble(SimulatorSpeed.Text);
                vm.VM_SimulatorSpeed = newSpeed;
                speedSlider.Value = newSpeed;
            }
            catch { }
        }

        private void SimulatorSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SimulatorSpeed.Text = String.Format("{0:0.00}", e.NewValue);
        }

    }
}