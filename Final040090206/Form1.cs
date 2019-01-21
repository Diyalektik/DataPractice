using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
// Onur Açarlar 040090206
namespace Final040090206
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                this.dataGridView1.Rows.Clear();
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".csv") == 0)
                {
                    try
                    {


                        string[] readText = File.ReadAllLines(filePath, Encoding.UTF8);
                        List<Data> dataList = new List<Data>();
                        
                        textBox1.Text = filePath;

                        
                        for (int i = 1; i < readText.Length; i++)
                        {
                            
                                string[] temp = readText[i].Trim(new char[] {';'}).Split(';');


                            
                                if (temp.Length==13) //formata uygun olmayan satırların hata yaratmaması için (2-3 satırda böyle bir durum var.
                                {
                                    Data data = new Data(temp[0], temp[1], temp[2], temp[3], (temp[4]), (temp[5]), (temp[6]), (temp[7]), (temp[8]), (temp[9]), (temp[10]), Convert.ToDouble(temp[11]), Convert.ToDouble(temp[12]));
                                    dataList.Add(data);
                                }

                               
                            
                           
                            
                               
                                
                            
                        }


                        string[] row = new string[13];
                        dataGridView1.ColumnCount = 14;
                        dataGridView1.Columns[0].Name = "";
                        dataGridView1.Columns[1].Name = "Brand";
                        dataGridView1.Columns[2].Name = "Store Number";
                        dataGridView1.Columns[3].Name = "Store Name";
                        dataGridView1.Columns[4].Name = "Ownership Type";
                        dataGridView1.Columns[5].Name = "Street Adress";
                        dataGridView1.Columns[6].Name = "City";
                        dataGridView1.Columns[7].Name = "State/Province";
                        dataGridView1.Columns[8].Name = "Country";
                        dataGridView1.Columns[9].Name = "Postcode";
                        dataGridView1.Columns[10].Name = "Phone Number";
                        dataGridView1.Columns[11].Name = "Timezone";
                        dataGridView1.Columns[12].Name = "Longitude";
                        dataGridView1.Columns[13].Name = "Latitude";







                        int j = 1;
                        foreach (var item in dataList) //eğer bir sırada herhangi bir columnda boşluk yakalarsa o sırayı almıyor.
                        {
                            if (checkBox1.Checked)
                            {
                                if ((item.brand == "") || (item.storeNumber == "") || (item.storeName == "")||(item.ownershipType=="")||(item.streetAdress=="")||(item.city=="")||(item.state=="")||(item.country=="")||(item.postCode=="")||(item.phone=="")||(item.timezone=="")||(item.longitude==0)||(item.latitude==0))
                                {
                                  
                                }
                                else
                                {
                                    row = new string[] { j + "", item.brand, item.storeNumber, item.storeName, item.ownershipType, item.streetAdress, item.city, item.state, item.country, item.postCode, item.phone, item.timezone, item.longitude + "", item.latitude + "" };
                                    dataGridView1.Rows.Add(row);
                                    j++;
                                }
                                
                            }
                            else
                            {
                                row = new string[] { j + "", item.brand, item.storeNumber, item.storeName, item.ownershipType, item.streetAdress, item.city, item.state, item.country, item.postCode, item.phone, item.timezone, item.longitude + "", item.latitude + "" };
                                dataGridView1.Rows.Add(row);
                                j++;
                            }
                        }

                        
                        
                      





                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .csv file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sorting ASC
                this.dataGridView1.Sort(this.dataGridView1.Columns[comboBox1.SelectedItem + ""], ListSortDirection.Ascending);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //mean, standart deviation, variance
            double k=0;
            double j=0;
            double p=0;
            int r = dataGridView1.Rows.Count - 1;
            for (int i = 0; i < r; i++)
            {
                k += Convert.ToDouble(dataGridView1.Rows[i].Cells[13].FormattedValue);
            }
            label2.Text=(k / r).ToString();

            for (int i = 0; i < r; i++)
            {
                j += ((Convert.ToDouble(dataGridView1.Rows[i].Cells[13].FormattedValue) - (k / r)) * (Convert.ToDouble(dataGridView1.Rows[i].Cells[13].FormattedValue) - (k / r)));
            }
            label3.Text = Math.Sqrt(j/r)+"";
            double lelli = Math.Sqrt(j/r);
            p = lelli * lelli;
            label7.Text = p.ToString();



            double k2 = 0;
            double j2 = 0;
            double p2 = 0;
            
            for (int i = 0; i < r; i++)
            {
                k2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[12].FormattedValue);
            }
            label10.Text = (k2 /r).ToString();

            for (int i = 0; i < r; i++)
            {
                j2 += ((Convert.ToDouble(dataGridView1.Rows[i].Cells[12].FormattedValue) - (k2 / r)) * (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].FormattedValue) - (k2 / r)));
            }
            label11.Text = Math.Sqrt(j2/r) + "";
            double lelli2 = Math.Sqrt(j2 / r);
            p2 = lelli2 * lelli2;
            label12.Text = p2.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            // setup for export
           dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.SelectAll();
            // hiding row headers to avoid extra \t in exported text
            var rowHeaders = dataGridView1.RowHeadersVisible;
            dataGridView1.RowHeadersVisible = false;

            // ! creating text from grid values
            string content = dataGridView1.GetClipboardContent().GetText();

            // restoring grid state
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = rowHeaders;

            System.IO.File.WriteAllText(dialog.FileName, content);
            MessageBox.Show(@"Text file was created.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            string content = "Latitude's; mean value: " + label2.Text + ", standart deviation: " + label3.Text + ", variance: " + label7.Text+". "+ "Longitude's; mean value: " + label10.Text + ", standart deviation: " + label11.Text + ", variance: " + label12.Text + ". ";

                 System.IO.File.WriteAllText(dialog.FileName, content);
            MessageBox.Show(@"Text file was created.");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Sort(this.dataGridView1.Columns[comboBox2.SelectedItem + ""], ListSortDirection.Descending);
            //sorting DESC
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            DataGridView x = dataGridView1;
        }
    }
}
