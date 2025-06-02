using System;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;
using MimeKit; // Thêm để xử lý nội dung email

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        private MimeMessage[] allMessages; // Lưu toàn bộ messages

        public Form2()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.listView1.DoubleClick += new EventHandler(this.listView1_DoubleClick); // Bắt sự kiện click đúp
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, sslErrors) => true;
                    client.Connect("127.0.0.1", 143, false); // dùng kết nối không mã hóa

                    client.Authenticate(textBox1.Text.Trim(), textBox2.Text.Trim());

                    if (!client.IsAuthenticated)
                    {
                        MessageBox.Show("Đăng nhập thất bại: Sai tài khoản hoặc mật khẩu.");
                        return;
                    }

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    label4.Text = inbox.Count.ToString();
                    label6.Text = inbox.Recent.ToString();

                    listView1.Items.Clear();
                    listView1.Columns.Clear();
                    listView1.Columns.Add("Email", 200);
                    listView1.Columns.Add("From", 200);
                    listView1.Columns.Add("Thời gian", 150);
                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;
                    listView1.GridLines = true;

                    allMessages = new MimeMessage[inbox.Count];

                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        allMessages[i] = message;
                        var item = new ListViewItem(message.Subject ?? "(Không có tiêu đề)");
                        item.SubItems.Add(message.From.ToString());
                        item.SubItems.Add(message.Date.DateTime.ToString("dd/MM/yyyy HH:mm"));
                        listView1.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                if (index >= 0 && index < allMessages.Length)
                {
                    var message = allMessages[index];
                    MessageBox.Show(message.TextBody ?? message.HtmlBody ?? "(Không có nội dung)", "Nội dung Email");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
