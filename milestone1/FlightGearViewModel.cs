﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using System.Reflection;

namespace milestone1
{
    class FlightGearViewModel : INotifyPropertyChanged
    {
        private IFlightGearModel model;
        public PlotModel VM_PlotModelCurrent
        {
            get { return model.PlotModelCurrent; }
            set { model.PlotModelCurrent = value; NotifyPropertyChanged("PlotModel"); }
        }
        public PlotModel VM_PlotModelRegression
        {
            get { return model.PlotModelRegression; }
            set { model.PlotModelRegression = value; NotifyPropertyChanged("PlotModel"); }
        }
        public PlotModel VM_PlotModelCurrentCorrelation
        {
            get { return model.PlotModelCurrentCorrelation; }
            set { model.PlotModelCurrentCorrelation = value; NotifyPropertyChanged("PlotModel"); }
        }

        public PlotModel VM_PlotModelForDll
        {
            get { return model.PlotModelForDll; }
            set { model.PlotModelForDll = value; NotifyPropertyChanged("PlotModelForDll"); }
        }
        public PlotModel VM_PlotModelAnomalies
        {
            get
            {
                return model.PlotModelAnomalies;
            }
            set
            {
                model.PlotModelAnomalies = value;
                NotifyPropertyChanged("PlotModelAnomalies");
            }
        }


        public double VM_SliderValue
        {
            get
            {
                return model.SliderValue;
            }
            set
            {
                model.moveSlider(value);
            }
        }

        public double VM_SimulatorSpeed
        {
            get
            {
                return model.SimulatorSpeed;
            }
            set
            {
                model.moveSimulatorSpeed(value);
            }
        }

        public FlightGearViewModel(IFlightGearModel model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public void VM_connect(string ip, int port)
        {
            model.connect(ip, port);
        }


        public void VM_start()
        {
            model.start();
        }

        public void VM_pause()
        {
            model.pause();
        }

        public void VM_resume()
        {
            model.resume();
        }

        public void VM_stop()
        {
            VM_goToEnd();
            model.stop();
        }

        public void VM_goRight()
        {
            if (VM_SliderValue < 96)
                VM_SliderValue += 4;
            else
                VM_SliderValue = 99.5;
        }

        public void VM_goLeft()
        {
            if (VM_SliderValue > 4)
                VM_SliderValue -= 4;
            else
                VM_SliderValue = 0;
        }

        public void VM_goToStart()
        {
            VM_SliderValue = 0;
        }
        public void VM_goToEnd()
        {
            VM_SliderValue = 99.5;
        }

        public void VM_initializingComponentsByPath(string path, string mode)
        {
            model.initializingComponentsByPath(path, mode);
        }

        public void VM_sendAssembly(Assembly assembly, string learnFilePath, string testFilePath)
        {
            model.initAssembly(assembly, learnFilePath, testFilePath);
        }

        public double VM_Altitude
        {
            get { return model.Altitude; }
            set {; }
        }

        public double VM_AirSpeed
        {
            get { return model.AirSpeed; }
            set {; }

        }

        public double VM_HeadingDeg
        {
            get { return model.HeadingDeg; }
            set {; }

        }

        public double VM_PitchDeg
        {
            get { return model.PitchDeg; }
            set {; }

        }

        public double VM_RollDeg
        {
            get { return model.RollDeg; }
            set {; }

        }

        public double VM_YawDeg
        {
            get { return model.YawDeg; }
            set {; }

        }
        public double VM_Aileron
        {
            get { return model.Aileron; }
            set {; }
        }
        public double VM_Elevator
        {
            get { return model.Elevator; }
            set {; }
        }
        public double VM_Rudder
        {
            get { return model.Rudder; }
            set {; }
        }
        public double VM_Throttle
        {
            get { return model.Throttle; }
            set {; }
        }

        public string[] VM_Properties
        {
            get
            {
                return model.Properties;
            }
        }

        public string VM_CurrerntChoice
        {
            get
            {
                return model.CurrerntChoice;
            }
            set
            {
                model.CurrerntChoice = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
