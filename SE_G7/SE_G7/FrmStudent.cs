using SE_G7.Models;
using SE_G7.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;






namespace SE_G7
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            ShowInfoStudent();
        }


        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                Student student = GetStudent(id);
                if (student != null)
                {
                    FrmInfo frmStudentModify = new FrmInfo(student);
                    frmStudentModify.ShowDialog();
                    MessageBox.Show("Camarche pas");
                }




            }
            else
            {
                MessageBox.Show("You have to select a student to modify");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            string name = "NULL";
            string surname = "NULL";
            string email = "NULL";
            string phone = "NULL";
            string home_university = "NULL";
            string faculty_address = "NULL";
            string field_of_study = "NULL";
            int id = 452;
            while (id < 1000)
            {
                //id = id + 1;
                //int id = 1452;
                //int id = random.Next(1, 101);
                //int id = GenerateRandomNumber();

                string sql = $"INSERT INTO InfoStudent (Id, Name, Surname, Email, Phone, Home_university, Faculty_address, Field_of_study) " +
                             $"VALUES ('{id}', '{name}', '{surname}', '{email}', '{phone}', '{home_university}', '{faculty_address}', '{field_of_study}')";


                DB.OpenConnection();
                DB.ExecuteCommand(sql);
                MessageBox.Show("New line added");
                LoadDataGridView();

                DB.CloseConnection();
            }

        }

        private void ShowInfoStudent()
        {
            List<Student> students = StudentRepository.GetStudents();
            dataGridView1.DataSource = students;

            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Surname"].DisplayIndex = 2;
            dataGridView1.Columns["Email"].DisplayIndex = 3;
            dataGridView1.Columns["Phone"].DisplayIndex = 4;
            dataGridView1.Columns["Home_university"].DisplayIndex = 5;
            dataGridView1.Columns["Faculty_address"].DisplayIndex = 6;
            dataGridView1.Columns["Field_of_study"].DisplayIndex = 7;
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Student GetStudent(int Id_stu)
        {
            string connectionString = "Data Source=31.147.204.119\\PISERVER,1433;" +
                                      "Initial Catalog=IPS23_afeydel23;" +
                                      "User ID=afeydel23;" +
                                      "Password=zE@;4Zm(;";

            string sql = $"SELECT * FROM InfoStudent WHERE Id = @Id";
            Student student = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id_stu);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new Student
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Surname = reader["Surname"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Home_university = reader["Home_university"].ToString(),
                                    Faculty_address = reader["Faculty_address"].ToString(),
                                    Field_of_study = reader["Field_of_study"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

            return student;
        }

        private void LoadDataGridView()
        {
            // Assurez-vous d'avoir une référence à System.Data dans votre projet.

            // Supprimez les lignes existantes dans la DataGridView
            dataGridView1.Rows.Clear();

            // Obtenez les données mises à jour à partir de votre source de données (par exemple, une base de données)
            DataTable dataTable = GetData();

            // Parcourez les lignes du DataTable et ajoutez-les à la DataGridView
            foreach (DataRow row in dataTable.Rows)
            {
                // Ajoutez une nouvelle ligne à la DataGridView
                int index = dataGridView1.Rows.Add();

                // Remplissez les cellules de la nouvelle ligne avec les valeurs du DataRow
                dataGridView1.Rows[index].Cells["Id"].Value = row["Id"];
                dataGridView1.Rows[index].Cells["Name"].Value = row["Name"];
                dataGridView1.Rows[index].Cells["Surname"].Value = row["Surname"];
                dataGridView1.Rows[index].Cells["Email"].Value = row["Email"];
                dataGridView1.Rows[index].Cells["Phone"].Value = row["Phone"];
                dataGridView1.Rows[index].Cells["Home_university"].Value = row["Home_university"];
                dataGridView1.Rows[index].Cells["Faculty_address"].Value = row["Faculty_address"];
                dataGridView1.Rows[index].Cells["Field_of_study"].Value = row["Field_of_study"];

                // Répétez ces deux lignes pour chaque colonne que vous souhaitez afficher
            }
        }


        private DataTable GetData()
        {
            // Chaîne de connexion à la base de données
            string connectionString = "Data Source=31.147.204.119\\PISERVER,1433;" +
                                          "Initial Catalog=IPS23_afeydel23;" +
                                          "User ID=afeydel23;" +
                                          "Password=zE@;4Zm(;";

            // Nom de la table que vous souhaitez récupérer les données
            string nomTable = "InfoStudent";

            // Créer une DataTable pour stocker les données
            DataTable dataTable = new DataTable();

            // Créer une connexion à la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Créer une requête SQL pour récupérer les données de la table
                    string query = $"SELECT * FROM InfoStudent";

                    // Créer un adaptateur de données pour exécuter la requête et remplir la DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Remplir la DataTable avec les données du résultat de la requête
                        adapter.Fill(dataTable);
                    }
                }
                catch (SqlException ex)
                {
                    // Gérer les exceptions liées à la base de données
                    Console.WriteLine($"Error : {ex.Message}");
                }
                finally
                {
                    // Fermer la connexion
                    connection.Close();
                }
            }

            // Retourner la DataTable contenant les données récupérées
            return dataTable;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Id"].Value);

                string sql = $"DELETE FROM InfoStudent WHERE Id = {id}";

                DB.OpenConnection();
                DB.ExecuteCommand(sql);
                MessageBox.Show("Line removed");
                LoadDataGridView();

                DB.CloseConnection();

            }
        }
    }
}
