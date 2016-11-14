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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Kalkulator.xaml
    /// </summary>
    public partial class Kalkulator : Window
    {
        enum Operation
        {
            none = 0, // brak operacji
            addition, // dodawanie
            subtraction, // odejmowanie
            multiplication, // mnożenie
            division, // dzielenie
            result // wynik
        }
        private Operation m_eLastOperationSelected = Operation.none;
        public Kalkulator()
        {
            InitializeComponent();
            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.result == m_eLastOperationSelected)
            {
                txtDisplay.Text = string.Empty;
                m_eLastOperationSelected = Operation.none;
            }
            Button oButton = (Button)sender;
            txtDisplay.Text += oButton.Content;
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
            txtDisplayOperation.Text = string.Empty;
            m_eLastOperationSelected = Operation.none;
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Operation.result == m_eLastOperationSelected) ||
        (Operation.none == m_eLastOperationSelected))
            {
                return;
            }
            if (string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = "0";
            }
            switch (m_eLastOperationSelected)
            {
                case Operation.addition:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) +
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.subtraction:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) -
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.multiplication:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) *
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
                case Operation.division:
                    txtDisplay.Text = (double.Parse(txtDisplayMemory.Text) /
                        double.Parse(txtDisplay.Text)).ToString();
                    break;
            }
            m_eLastOperationSelected = Operation.result;
            txtDisplayOperation.Text = string.Empty;
            txtDisplayMemory.Text = string.Empty;
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (Operation.result == m_eLastOperationSelected)
            {
                txtDisplay.Text = string.Empty;
                m_eLastOperationSelected = Operation.none;
            }
            if ((txtDisplay.Text.Contains(',')) ||
                (0 == txtDisplay.Text.Length))
            {
                return;
            }
            txtDisplay.Text += ",";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Operation.none != m_eLastOperationSelected) || (Operation.result != m_eLastOperationSelected))
            {
                ResultButton_Click(this, e);
            }
            Button oButton = (Button)sender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    m_eLastOperationSelected = Operation.addition;
                    break;
                case "-":
                    m_eLastOperationSelected = Operation.subtraction;
                    break;
                case "*":
                    m_eLastOperationSelected = Operation.multiplication;
                    break;
                case "/":
                    m_eLastOperationSelected = Operation.division;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            txtDisplayMemory.Text = txtDisplay.Text;
            txtDisplayOperation.Text = oButton.Content.ToString();
            txtDisplay.Text = string.Empty;
        }


      

       
    }
}
