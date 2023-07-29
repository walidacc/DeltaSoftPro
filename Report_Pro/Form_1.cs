﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Report_Pro
{
    public partial class Form_1 : Form
    {
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();

        public Form_1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Syria));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.S));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Tunisia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Gold));

            cboCurrency.DataSource = currencies;

            cboCurrency_DropDownClosed(null, null);
        }

        private void cboCurrency_DropDownClosed(object sender, EventArgs e)
        {
            txtNumber_TextChanged(null, null);
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ToWord toWord = new ToWord(Convert.ToDecimal(txtNumber.Text), currencies[Convert.ToInt32(cboCurrency.SelectedValue)]);
                txtEnglishWord.Text = toWord.ConvertToEnglish();
                txtArabicWord.Text = toWord.ConvertToArabic();
            }
            catch (Exception ex)
            {
                txtEnglishWord.Text = String.Empty;
                txtArabicWord.Text = String.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
