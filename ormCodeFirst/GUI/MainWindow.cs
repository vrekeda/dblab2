using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace dblab2
{
    public partial class MainWindow : Form
    {
        dblab2Context db = new dblab2Context();

        string curTable;

        public MainWindow()
        {
            InitializeComponent();
            PrintExecutingTables();
        }
        private void PrintExecutingTables()
        {
            //db.Clients.Add(new Client { Firstname = "Peter", Lastname = "Ivanov", Birthdate = new DateTime(1999, 12, 20), Gender = true });
            //db.Clients.Add(new Client { Firstname = "Peter", Lastname = "Ivanov", Birthdate = new DateTime(2999, 12, 20), Gender = true });
            //db.SaveChanges();
            executingTablesView.Items.Add("Clients");
            executingTablesView.Items.Add("Tours");
            executingTablesView.Items.Add("TravelAgencies");
            //List<Tour> tours = db.Tours.FromSql("select * from tour").ToList();
            Console.WriteLine();
        }

        void SqlFullTextSearch(string text, char c)
        {
            string[] words = text.Split(' ');
            StringBuilder textToSql = new StringBuilder();
            string str;
            if (c == '!')
            {
                str = "& !";
                textToSql.Append("'!");
            }
            else
            {
                str = "& ";
                textToSql.Append("'");
            }
            textToSql.Append(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                textToSql.Append(str);
                textToSql.Append(words[i]);
            }
            textToSql.Append("'");
            try
            {

                List<Tour> tours = db.Tours.FromSql($@"select tour.* FROM
                                                                    tour
                                                                    WHERE
                                                                    to_tsvector(tour.description) @@ to_tsquery({textToSql.ToString()})").ToList();
                FillTableGridHeader(typeof(Tour).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                int i = 0;
                foreach (Tour tour in tours)
                {
                    TableDataGrid.Rows.Add();
                    TableDataGrid.Rows[i].Cells[0].Value = tour.Id;
                    TableDataGrid.Rows[i].Cells[1].Value = tour.Price;
                    TableDataGrid.Rows[i].Cells[2].Value = tour.Tourdate;
                    TableDataGrid.Rows[i].Cells[3].Value = tour.City;
                    TableDataGrid.Rows[i].Cells[4].Value = tour.IdTA;
                    TableDataGrid.Rows[i].Cells[5].Value = tour.Description;
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                errorWindow.Show();
                //ErrorForm errorForm = new ErrorForm(ex.Message);
                //errorForm.Show();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (!f) return;

            AddWindow addWindow;
            DataGridViewRow newRow;
            switch (curTable)
            {
                case "Clients":
                    addWindow = new AddWindow(typeof(Client).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                    addWindow.ShowDialog();
                    if (addWindow.DialogResult == DialogResult.OK && addWindow.save)
                    {
                        try
                        {
                            newRow = addWindow.newRow;
                            Client client = new Client();
                            client.Firstname = newRow.Cells[0].Value.ToString();
                            client.Lastname = newRow.Cells[1].Value.ToString();
                            client.Birthdate = Convert.ToDateTime(newRow.Cells[2].Value.ToString());
                            client.Gender = Convert.ToBoolean(newRow.Cells[3].Value.ToString());
                            db.Clients.Add(client);
                            db.SaveChanges();
                            FillTableGridInfo(curTable);
                        }
                        catch (Exception ex)
                        {
                            ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                            errorWindow.Show();
                        }
                    }
                    break;
                case "Tours":
                    addWindow = new AddWindow(typeof(Tour).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                    addWindow.ShowDialog();
                    if (addWindow.DialogResult == DialogResult.OK && addWindow.save)
                    {
                        try
                        {
                            newRow = addWindow.newRow;
                            Tour tour = new Tour();
                            tour.Price = decimal.Parse(newRow.Cells[0].Value.ToString());
                            tour.Tourdate = Convert.ToDateTime(newRow.Cells[1].Value.ToString());
                            tour.City = newRow.Cells[2].Value.ToString();
                            tour.IdTA = Int32.Parse(newRow.Cells[3].Value.ToString());
                            tour.Description = newRow.Cells[4].Value.ToString();
                            db.Tours.Add(tour);
                            db.SaveChanges();
                            FillTableGridInfo(curTable);
                        }
                        catch (Exception ex)
                        {
                            ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                            errorWindow.Show();
                        }
                    }
                    break;
                case "TravelAgencies":
                    addWindow = new AddWindow(typeof(TravelAgency).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                    addWindow.ShowDialog();
                    if (addWindow.DialogResult == DialogResult.OK && addWindow.save)
                    {
                        try
                        {
                            newRow = addWindow.newRow;
                            TravelAgency travelAgency = new TravelAgency();
                            travelAgency.Name = newRow.Cells[0].Value.ToString();
                            travelAgency.Adress = newRow.Cells[1].Value.ToString();
                            db.TravelAgencies.Add(travelAgency);
                            db.SaveChanges();
                            FillTableGridInfo(curTable);
                        }
                        catch (Exception ex)
                        {
                            ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                            errorWindow.Show();
                        }
                    }
                    break;
            }

        }

        private void TableDataView_Click(object sender, DataGridViewCellEventArgs e)
        {
            //if (!f) return;
            if (e.ColumnIndex == TableDataGrid.ColumnCount - 2)
            {
                EditWindow editWindow = new EditWindow(TableDataGrid.Rows[e.RowIndex], typeof(Client).GetProperties()
                            .Select(property => property.Name)
                            .ToList());
                editWindow.ShowDialog();
                if (editWindow.save)
                {
                    DataGridViewRow newRow = editWindow.editedRow;
                    switch (curTable)
                    {
                        case "Clients":
                            try
                            {
                                Client client = db.Clients
                    .Where(c => c.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault();
                                client.Firstname = newRow.Cells[0].Value.ToString();
                                client.Lastname = newRow.Cells[1].Value.ToString();
                                client.Birthdate = Convert.ToDateTime(newRow.Cells[2].Value.ToString());
                                client.Gender = Convert.ToBoolean(newRow.Cells[3].Value.ToString());
                                db.SaveChanges();
                                FillTableGridInfo("Clients");
                            }
                            catch (Exception ex)
                            {
                                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                                errorWindow.Show();
                            }
                            break;
                        case "Tours":
                            try
                            {
                                Tour tour = db.Tours
                    .Where(c => c.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault();
                                tour.Price = decimal.Parse(newRow.Cells[0].Value.ToString());
                                tour.Tourdate = Convert.ToDateTime(newRow.Cells[1].Value.ToString());
                                tour.City = newRow.Cells[2].Value.ToString();
                                tour.IdTA = Int32.Parse(newRow.Cells[3].Value.ToString());
                                tour.Description = newRow.Cells[4].Value.ToString();
                                db.SaveChanges();
                                FillTableGridInfo("Tours");
                            }
                            catch (Exception ex)
                            {
                                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                                errorWindow.Show();
                            }
                            break;
                        case "TravelAgencies":
                            try
                            {
                                TravelAgency travelAgency = db.TravelAgencies
                    .Where(c => c.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault();
                                travelAgency.Name = newRow.Cells[0].Value.ToString();
                                travelAgency.Adress = newRow.Cells[1].Value.ToString();
                                db.SaveChanges();
                                FillTableGridInfo("TravelAgencies");
                            }
                            catch (Exception ex)
                            {
                                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                                errorWindow.Show();
                            }
                            break;
                    }
                }

            }
            else
            if (e.ColumnIndex == TableDataGrid.ColumnCount - 1)
            {
                DeleteWindow deleteWindow = new DeleteWindow();
                if (deleteWindow.ShowDialog() == DialogResult.OK && deleteWindow.delete)
                {
                    try
                    {
                        switch (curTable)
                        {
                            case "Clients":
                                Client client = db.Clients
                    .Where(c => c.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault();
                                db.Clients.Remove(client);
                                db.SaveChanges();
                                FillTableGridInfo("Clients");
                                break;
                            case "Tours":
                                db.Tours.Remove(db.Tours
                    .Where(t => t.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault());
                                db.SaveChanges();
                                FillTableGridInfo("Tours");
                                break;
                            case "TravelAgencies":
                                db.TravelAgencies.Remove(db.TravelAgencies
                    .Where(ta => ta.Id == Int32.Parse(TableDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    .FirstOrDefault());
                                db.SaveChanges();
                                FillTableGridInfo("TravelAgencies");
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                        errorWindow.Show();
                    }
                }
            }
        }

        private void executingTablesView_MouseDoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedtable in executingTablesView.SelectedItems/*checkedListBox1.SelectedItems*/)
            {
                string tableName = selectedtable.Text.ToString();
                switch (tableName)
                {
                    case "Clients":
                        curTable = "Clients";
                        FillTableGridHeader(typeof(Client).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                        FillTableGridInfo("Clients");
                        break;
                    case "Tours":
                        curTable = "Tours";
                        FillTableGridHeader(typeof(Tour).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                        FillTableGridInfo("Tours");
                        break;
                    case "TravelAgencies":
                        curTable = "TravelAgencies";
                        FillTableGridHeader(typeof(TravelAgency).GetProperties()
                        .Select(property => property.Name)
                        .ToList());
                        FillTableGridInfo("TravelAgencies");
                        break;
                }
            }
        }

        private void FillTableGridInfo(string tableName)
        {

            TableDataGrid.Rows.Clear();
            int i = 0;
            switch (tableName)
            {
                case "Clients":
                    foreach (Client client in db.Clients)
                    {
                        TableDataGrid.Rows.Add();
                        TableDataGrid.Rows[i].Cells[0].Value = client.Id;
                        TableDataGrid.Rows[i].Cells[1].Value = client.Firstname;
                        TableDataGrid.Rows[i].Cells[2].Value = client.Lastname;
                        TableDataGrid.Rows[i].Cells[3].Value = client.Birthdate;
                        TableDataGrid.Rows[i].Cells[4].Value = client.Gender;
                        i++;
                    }
                    break;
                case "Tours":
                    foreach (Tour tour in db.Tours)
                    {
                        TableDataGrid.Rows.Add();
                        TableDataGrid.Rows[i].Cells[0].Value = tour.Id;
                        TableDataGrid.Rows[i].Cells[1].Value = tour.Price;
                        TableDataGrid.Rows[i].Cells[2].Value = tour.Tourdate;
                        TableDataGrid.Rows[i].Cells[3].Value = tour.City;
                        TableDataGrid.Rows[i].Cells[4].Value = tour.IdTA;
                        TableDataGrid.Rows[i].Cells[5].Value = tour.Description;
                        i++;
                    }
                    break;
                case "TravelAgencies":
                    foreach (TravelAgency travelAgency in db.TravelAgencies)
                    {
                        TableDataGrid.Rows.Add();
                        TableDataGrid.Rows[i].Cells[0].Value = travelAgency.Id;
                        TableDataGrid.Rows[i].Cells[1].Value = travelAgency.Name;
                        TableDataGrid.Rows[i].Cells[2].Value = travelAgency.Adress;
                        i++;
                    }
                    break;
                default:
                    break;
            }
        }
        private void FillTableGridHeader(List<string> colNames)
        {
            btnAdd.Enabled = true;
            TableDataGrid.Rows.Clear();
            TableDataGrid.Columns.Clear();
            int width = (TableDataGrid.Width - 65) / (colNames.Count);
            for (int j = 0; j < colNames.Count - 2; j++)
            {
                DataGridViewColumn column = new DataGridViewColumn
                {
                    HeaderText = colNames[j],
                    Width = width,
                    ReadOnly = true,
                    Name = colNames[j],
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                TableDataGrid.Columns.Add(column);
            }
            DataGridViewButtonColumn editClmn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                ReadOnly = true,
                Name = "Edit",
                Text = "Edit",
                Width = width,
                UseColumnTextForButtonValue = true
            };
            TableDataGrid.Columns.Add(editClmn);
            DataGridViewButtonColumn delClmn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                ReadOnly = true,
                Name = "Delete",
                Text = "Delete",
                Width = width,
                UseColumnTextForButtonValue = true
            };
            TableDataGrid.Columns.Add(delClmn);
        }
        private void executingTablesView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFullTextSearch_Click(object sender, EventArgs e)
        {
            SqlFullTextSearch(fullTextSearchBox.Text, '&');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlFullTextSearch(fullTextSearchBox.Text, '!');
        }

        private void attrSearch_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            TableDataGrid.Rows.Clear();
            TableDataGrid.Columns.Clear();
            List<string> clientColNames = typeof(Client).GetProperties()
                        .Select(property => property.Name)
                        .ToList();
            List<string> tourColNames = typeof(Tour).GetProperties()
                        .Select(property => property.Name)
                        .ToList();
            int width = (TableDataGrid.Width - 65) / (clientColNames.Count + tourColNames.Count - 4);
            for (int j = 0; j < clientColNames.Count - 2; j++)
            {
                DataGridViewColumn column = new DataGridViewColumn
                {
                    HeaderText = clientColNames[j],
                    Width = width,
                    ReadOnly = true,
                    Name = clientColNames[j],
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                TableDataGrid.Columns.Add(column);
            }
            for (int j = 0; j < tourColNames.Count - 2; j++)
            {
                DataGridViewColumn column = new DataGridViewColumn
                {
                    HeaderText = tourColNames[j],
                    Width = width,
                    ReadOnly = true,
                    Name = tourColNames[j],
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                TableDataGrid.Columns.Add(column);
            }
            if (genderSearch.Text != "" && citiesSearch.Text != "")
            {
                List<Client> clientsWithTour = db.Clients.Where(cl => cl.Gender == Convert.ToBoolean(genderSearch.Text))
                    .Include(c => c.ClientToTour).ThenInclude(t => t.Tour).ToList();
                int i = 0;
                foreach (Client client in clientsWithTour)
                {
                    foreach (ClientToTour clientTour in client.ClientToTour)
                    {
                        if (citiesSearch.Text.Contains(clientTour.Tour.City))
                        {
                            TableDataGrid.Rows.Add();
                            TableDataGrid.Rows[i].Cells[0].Value = client.Id;
                            TableDataGrid.Rows[i].Cells[1].Value = client.Firstname;
                            TableDataGrid.Rows[i].Cells[2].Value = client.Lastname;
                            TableDataGrid.Rows[i].Cells[3].Value = client.Birthdate;
                            TableDataGrid.Rows[i].Cells[4].Value = client.Gender;
                            TableDataGrid.Rows[i].Cells[5].Value = clientTour.Tour.Id;
                            TableDataGrid.Rows[i].Cells[6].Value = clientTour.Tour.Price;
                            TableDataGrid.Rows[i].Cells[7].Value = clientTour.Tour.Tourdate;
                            TableDataGrid.Rows[i].Cells[8].Value = clientTour.Tour.City;
                            TableDataGrid.Rows[i].Cells[9].Value = clientTour.Tour.IdTA;
                            TableDataGrid.Rows[i].Cells[10].Value = clientTour.Tour.Description;
                            i++;
                        }
                    }
                }

            }
        }

        private void RandFillBtn_Click(object sender, EventArgs e)
        {
            RandomFilling randomFilling = new RandomFilling(db);
            switch (curTable)
            {
                case "Clients":
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            Client client = randomFilling.GetRandClient();
                            db.Clients.Add(client);
                            db.SaveChanges();
                            ClientToTour clientToTour = new ClientToTour() { ClientId = client.Id, TourId = randomFilling.GetRandomTourId() };
                            db.ClientToTours.Add(clientToTour);
                            client.ClientToTour.Add(clientToTour);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    FillTableGridInfo("Clients");
                    break;
                case "Tours":
                    for (int i = 0; i < 10; i++)
                    {
                        Tour tour = randomFilling.GetRandTour();
                        db.Tours.Add(tour);
                        db.SaveChanges();
                    }
                    FillTableGridInfo("Tours");
                    break;
                case "TravelAgencies":
                    for (int i = 0; i < 10; i++)
                    {
                        TravelAgency travelAgency = randomFilling.GetRandTravelAgency();
                        db.TravelAgencies.Add(travelAgency);
                        db.SaveChanges();
                        TravelAgencyToClient travelAgencyToClient = new TravelAgencyToClient() { ClientId = randomFilling.GetRandomClientId(), TravelAgencyId = travelAgency.Id };
                        db.TravelAgencyToClients.Add(travelAgencyToClient);
                        travelAgency.TravelAgencyToClient.Add(travelAgencyToClient);
                        db.SaveChanges();
                    }
                    FillTableGridInfo("TravelAgencies");
                    break;
            }
        }
    }
}
